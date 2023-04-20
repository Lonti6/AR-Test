using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMovingObject : MonoBehaviour
{
    Vector3 startPosition;
    void Start()
    {
        startPosition = this.transform.position;
    }

    void Update()
    {
        this.transform.position = startPosition;
    }
}
