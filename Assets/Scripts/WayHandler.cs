using System.Collections.Generic;
using UnityEngine;

public class WayHandler : MonoBehaviour
{
    int totalNodes = 0;

    Node startNode;
    Node previousNode;

    List<Node> nodesList = new List<Node>();

    public GameObject arrowPrefab;

    void Start()
    {
        startNode = new Node(Camera.main.transform.position, "startNode", null);
        nodesList.Add(startNode);
        previousNode = startNode;
    }

    void Update()
    {

        Vector3 currentPosition = Camera.main.transform.position;

        if (Vector3.Distance(currentPosition, previousNode.position) > 1)
        {
            //спавним узел пути
            GameObject nodeObject = Instantiate(arrowPrefab, currentPosition, Quaternion.identity);
            nodeObject.transform.LookAt(previousNode.position);

            //цепл€ем на него компонент узла
            Node currentNode = nodeObject.AddComponent(typeof(Node)) as Node;

            currentNode.ChangeData(Camera.main.transform.position, "node_" + totalNodes++, startNode);
            nodesList.Add(currentNode);

            previousNode = currentNode;
        }
    }
}
