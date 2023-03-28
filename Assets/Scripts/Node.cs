using UnityEngine;

public class Node
{
    static int counter = 1;

    public Vector3 position;

    public string nodeTag;

    public Node()
    {
        this.position = Camera.main.transform.position;
        this.nodeTag = (counter++).ToString();
    }
}
