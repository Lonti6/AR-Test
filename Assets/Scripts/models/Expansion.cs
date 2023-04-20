using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class Expansion : MonoBehaviour
{
    public string description;
    public bool isRotate = false;

    public float rotationSpeed = 5f;

    InterectiveHandler handler = null;


    private void Start()
    {
        handler = FindObjectsOfType<InterectiveHandler>()[0];
    }

    private void Update()
    {
        if (isRotate)
        {
            transform.eulerAngles += Vector3.up * Time.deltaTime * rotationSpeed;
        }
    }

    private void OnMouseDown()
    {

        if (handler.manualyObject == this.gameObject)
        {
            handler.manualyObject = null;
            return;
        }

        handler.manualyObject = this.gameObject;
    }
}
