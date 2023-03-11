using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Vector3 position;

    public string nodeName;

    public Node parentNode;

    public bool isCreated;

    public Node(Vector3 position, string nodeName, Node parentNode, bool isCreated)
    {
        this.position = position;
        this.nodeName = nodeName;
        this.parentNode = parentNode;
        this.isCreated = isCreated;
    }
}
