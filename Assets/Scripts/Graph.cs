using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class Graph : MonoBehaviour
{
    private Dictionary<string, List<string>> graf = new Dictionary<string, List<string>>();

    public GameObject obj;
    private TextMeshPro text;

    void Start()
    {
        text = obj.GetComponent<TextMeshPro>();
        text.text = "starts";
        
        line("floor_5_n_9", "floor_5_n_8");
        line("floor_5_n_8", "floor_5_n_7");
        line("floor_5_n_7", "floor_5_n_6");
        line("floor_5_n_6", "floor_5_n_5");
        line("floor_5_n_5", "floor_5_n_4");
        line("floor_5_n_4", "floor_5_n_3");
        line("floor_5_n_3", "floor_5_n_2");
        line("floor_5_n_2", "floor_5_n_1");
    }


    void line(string start, string end)
    {
        if (graf.ContainsKey(start))
        {
            graf[start].Add(end);
        }
        else
        {
            graf[start] = new List<string> { end };
        }
    }

    List<string> findPath(string start, string end)
    {
        HashSet<string> set = new HashSet<string>();
        Dictionary<string, string> prevs = new Dictionary<string, string>();

        set.Add(start);
        bool find = dfs(set, prevs, start, end);
        if (!find)
            return new List<string>();

        List<string> path = new List<string>();
        while (end != start)
        {
            path.Add(end);
            end = prevs[end];
        }
        path.Add(start);
        path.Reverse();
        return path;
    }

    private bool dfs(HashSet<string> set, Dictionary<string, string> prevs, string start, string end)
    {
        List<string> next = graf[start];
        if (next == null) return false;
        List<string> nodes = new List<string>();

        foreach (var node in next)
        {
            if (set.Contains(node)) 
                continue;
            
            prevs[node] = start;
            set.Add(node);

            if (node == end)
                return true;
            
        }
        
        foreach (var n in nodes)
        {
            var res = dfs(set, prevs, n, end);
            if (res)
                return true;
        }

        return false;

    }

    ARTrackedImageManager m_TrackedImageManager;

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void UpdateInfo(ARTrackedImage trackedImage)
    {
        // Set canvas camera


        // Update information about the tracked image
        
        text.text = string.Format(
            "{0}\ntrackingState: {1}\nGUID: {2}\nReference size: {3} cm\nDetected size: {4} cm",
            trackedImage.referenceImage.name,
            trackedImage.trackingState,
            trackedImage.referenceImage.guid,
            trackedImage.referenceImage.size * 100f,
            trackedImage.size * 100f);

        var planeParentGo = trackedImage.transform.GetChild(0).gameObject;
        var planeGo = planeParentGo.transform.GetChild(0).gameObject;

        // Disable the visual plane if it is not being tracked
        if (trackedImage.trackingState != TrackingState.None)
        {
            planeGo.SetActive(true);

            // The image extents is only valid when the image is being tracked
            trackedImage.transform.localScale = new Vector3(trackedImage.size.x, 1f, trackedImage.size.y);
            
        }
        else
        {
            planeGo.SetActive(false);
        }
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Give the initial image a reasonable default scale
            trackedImage.transform.localScale = new Vector3(0.01f, 1f, 0.01f);

            UpdateInfo(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
            UpdateInfo(trackedImage);
    }
}