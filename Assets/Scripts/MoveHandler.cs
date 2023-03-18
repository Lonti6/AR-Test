using System.Collections.Generic;
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

    private void Start()
    {
        textMeshPro = textObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;


        textMeshPro.text = cameraPosition.ToString();

        if (nodes != null && previousNode != null && Vector3.Distance(cameraPosition, previousNode.position) > 2)
        {
            GameObject obj = Instantiate(arrowObject, Camera.main.transform.position, Quaternion.identity);

            obj.transform.LookAt(previousNode.position);

            Node node = obj.GetComponent<Node>();

            previousNode = node;

            nodes.Add(node);
        }
    }

    public void StartOrStopWrite()
    {

        if (nodes != null)
        {

            nodes = null;

            return;
        }

        nodes = new List<Node>();

        GameObject startObject = Instantiate(this.startObject, Camera.main.transform.position, Quaternion.identity);

        Node node = startObject.GetComponent<Node>();


        previousNode = node;

        nodes.Add(previousNode);
    }
}
