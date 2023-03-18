using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CreateImage : MonoBehaviour
{
    public GameObject prefub;

    public Camera camera;

    private ImageTargetBehaviour behaviour;
    // Start is called before the first frame update
    void Start()
    {
        
        
        // behaviour.SetWidth();
    }

    public void AddNewObj()
    {
        string path = SaveScreen();
        string[] ss = path.Split("/");
        string name = ss[^1];
        // GameObject gameObject = Instantiate(prefub, new Vector3(0, 0, 0), Quaternion.identity);
        
        var target = VuforiaBehaviour.Instance.ObserverFactory.CreateImageTarget(path, 0.6f, name);
        target.enabled = true;
        Debug.Log("info ", target);
        target.OnTargetStatusChanged += OnTargetStatusChanged;

    }
    
    void OnTargetStatusChanged(ObserverBehaviour observerbehavour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED && status.StatusInfo == StatusInfo.NORMAL)
        {
            if (prefub != null)
            {
                GameObject myModelTrf = Instantiate(prefub);
                myModelTrf.transform.parent = observerbehavour.transform;
                myModelTrf.transform.localPosition = new Vector3(0f, 0f, 0f);
                myModelTrf.transform.localRotation = Quaternion.identity;
                myModelTrf.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                myModelTrf.transform.gameObject.SetActive(true);
            }
        }
    }

    public String SaveScreen() {
        int width = camera.pixelWidth;
        int height = camera.pixelHeight;
        Texture2D texture = new Texture2D(width, height);

        RenderTexture old = camera.targetTexture;
 
        RenderTexture targetTexture = RenderTexture.GetTemporary(width, height);
 
        camera.targetTexture = targetTexture;
        camera.Render();
 
 
        RenderTexture.active = targetTexture;
 
        Rect rect = new Rect(0, 0, width, height);
        texture.ReadPixels(rect, 0, 0);
        texture.Apply();
        camera.targetTexture = old;
        
        byte[] byteArray = texture.EncodeToJPG();
        string currentTime = Application.persistentDataPath + "/scr-" + DateTime.Now.ToString("MM-dd-yy-HH-mm-ss") + ".jpg";
        Debug.Log("save file " + currentTime);
        System.IO.File.WriteAllBytes(currentTime, byteArray);
        return currentTime;
    }
}
