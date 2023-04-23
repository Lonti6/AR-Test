using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoShower : MonoBehaviour
{
    InterectiveHandler handler = null;
    private void Start()
    {
        handler = FindObjectsOfType<InterectiveHandler>()[0];
    }

    private void OnMouseDown()
    {
        handler.ChangeDescVisible();
    }
}
