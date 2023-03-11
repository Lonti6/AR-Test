using System.Collections.Generic;
using UnityEngine;

public class WayHandler : MonoBehaviour
{
    int totalNodes = 0;

    Node startNode;
    Node previousMarkerNode;

    List<Node> nodesList = new List<Node>();

    public GameObject arrowPrefab;

    void Start()
    {
        startNode = new Node(Camera.main.transform.position, "startNode", null, false);
        previousMarkerNode = startNode;
        nodesList.Add(startNode);
    }

    void Update()
    {
        Node currentNode = new Node(Camera.main.transform.position, "node_" + totalNodes++, startNode, false);

        if (Vector3.Distance(currentNode.position, previousMarkerNode.position) > 1)
        {
            nodesList.Add(currentNode);
            previousMarkerNode = currentNode;
        }

        Node previousNode = startNode;

        nodesList.ForEach(node =>
        {
            if (!node.isCreated)
            {
                GameObject nodeCurrent = Instantiate(arrowPrefab, node.position, Quaternion.identity);

                nodeCurrent.transform.LookAt(previousNode.position);

                node.isCreated = true;
                previousNode = node;
            }
        });
    }
}
