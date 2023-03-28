using Assets.Scripts;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    public GameObject textObject;

    private TextMeshProUGUI textMeshPro;

    public GameObject startObject;

    public GameObject arrowObject;

    List<Node> nodes;

    private Node previousNode;

    string waysFileName = "NodesWay";

    private void Start()
    {
        textMeshPro = textObject.GetComponent<TextMeshProUGUI>();

        var tmpNodes = Utils.ReadXmlFile<Node>(waysFileName);

        Instantiate(this.startObject, tmpNodes[0].position, Quaternion.identity);
        previousNode = tmpNodes[0];

        for (int i = 1; i < tmpNodes.Count; i++)
        {
            var tmpNode = tmpNodes[i];

            var obj = Instantiate(this.arrowObject, tmpNode.position, Quaternion.identity);
            obj.transform.LookAt(previousNode.position);

            previousNode = tmpNode;
        }

    }

    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        textMeshPro.text = cameraPosition.ToString();

        if (nodes != null && previousNode != null && Vector3.Distance(cameraPosition, previousNode.position) > 2)
        {
            GameObject obj = Instantiate(arrowObject, Camera.main.transform.position, Quaternion.identity);

            obj.transform.LookAt(previousNode.position);

            Node node = new Node();

            previousNode = node;

            nodes.Add(node);
        }
    }

    public void StartOrStopWrite()
    {

        if (nodes != null)
        {
            Utils.WriteToXmlFile<Node>(nodes, waysFileName);
            nodes = null;

            return;
        }

        nodes = new List<Node>();
        Node node = new Node();

        Instantiate(this.startObject, node.position, Quaternion.identity);

        previousNode = node;
        nodes.Add(previousNode);
    }
}
