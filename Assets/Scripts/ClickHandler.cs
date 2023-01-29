using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    private int clickCount = 0;
    private MeshRenderer render;

    public float soilMoisture = 0;



    void Start()
    {
        Debug.Log("StartMessage");
        render = GetComponent<MeshRenderer>();
    }

    void Update()
    {
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Color color = new Color(Random.Range(0, 255)/255f, Random.Range(0, 255)/255f, Random.Range(0, 255)/255f);
            render.material.color = color;
            ++clickCount;
        }
    }
}
