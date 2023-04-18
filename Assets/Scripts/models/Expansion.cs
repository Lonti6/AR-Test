using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Expansion : MonoBehaviour
{
    public string description;
    public bool isRotate = false;

    public float rotationSpeed = 5f;

    private void Update()
    {
        if (isRotate)
        {
            transform.eulerAngles += Vector3.up * Time.deltaTime * rotationSpeed;
        }
    }
}
