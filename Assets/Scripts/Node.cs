using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Node: MonoBehaviour
{
    public Vector3 position;

    public string nodeName;

    public Node parentNode;
    public Node childNode;

    public bool isKeyNode;

    public TextMeshPro textMeshPro;

    private void Start()
    {
        this.position = Camera.main.transform.position;
        this.isKeyNode = false;
    }

    public void ChangeData(Vector3 position, string nodeName, Node parentNode)
    {
        this.position = position;
        this.nodeName = nodeName;
        this.parentNode = parentNode;
    }

    public void ChangeData(Node node)
    {
        this.position = node.position;
        this.nodeName = node.nodeName;
        this.parentNode = node.parentNode;
    }
}
