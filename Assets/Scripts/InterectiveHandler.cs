using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InterectiveHandler : MonoBehaviour
{
    public const string expansion = "Expansion";


    private List<GameObject> expansions = new List<GameObject>();

    public GameObject actionObject = null;
    public GameObject manualyObject = null;

    public GameObject positionText;


    public GameObject descObj;
    public TextMeshProUGUI descText;


    public GameObject videoObj;
    public GameObject expansionsObject;
    public GameObject startMenuObject;
    public GameObject backButton;

    void Start()
    {
        expansions = GameObject.FindGameObjectsWithTag(expansion).ToList();

        descObj = GameObject.FindWithTag("Desc");
        descText = GameObject.FindWithTag("DescText").GetComponent<TextMeshProUGUI>();
        backButton = GameObject.FindWithTag("BackButton");

        descObj.SetActive(false);
    }

    void Update()
    {
        if (manualyObject != null)
        {
            actionObject = manualyObject;
            positionText.GetComponent<TextMeshProUGUI>().text = actionObject.GetComponent<Expansion>().expansionName;
            return;
        }

        actionObject = null;

        expansions.ForEach(obj =>
        {
            if (Vector3.Distance(Camera.main.transform.position, obj.transform.position) < 0.5)
            {
                actionObject = obj;
                return;
            }
        });
        
        if (actionObject == null)
        {
            return;
        }

        var exp = actionObject.GetComponent<Expansion>();

        positionText.GetComponent<TextMeshProUGUI>().text = exp.expansionName;
        descText.text = exp.description;
    }

    public void SetManualyObject(GameObject obj)
    {
        this.manualyObject = obj;
        var exp = obj.GetComponent<Expansion>();

        positionText.GetComponent<TextMeshProUGUI>().text = exp.expansionName;

        descObj.SetActive(true);
        descText.text = exp.description;
    }

    public void ChangeDescVisible()
    {
        descObj.SetActive(!descObj.activeSelf);
    }

    public void SetMode(int modeNumber)
    {
        startMenuObject.SetActive(false);
        backButton.SetActive(true);

        if (modeNumber == 0)
        {
            videoObj.SetActive(false);
            expansionsObject.SetActive(true);
        }
        if (modeNumber == 2)
        {
            expansionsObject.SetActive(false);
            videoObj.SetActive(true);
            GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>().Stop();
        }
    }

    public void ShowMenu()
    {
        videoObj.SetActive(false);
        expansionsObject.SetActive(false);
        backButton.SetActive(false);

        startMenuObject.SetActive(true);
    }
}
