using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WayHandler : MonoBehaviour
{
    Dictionary<string, List<Node>> ways = new Dictionary<string, List<Node>>();

    List<Node> writingWay;
    List<GameObject> currenWay;

    Vector3 previousPosition;

    Node previousNode;

    public GameObject arrowPrefab;
    public GameObject keyPointPrefab;


    private void Start()
    {
        StartWriteWay();
    }

    private void Update()
    {

        Vector3 currentPosition = Camera.main.transform.position;
        
        if (writingWay != null && Vector3.Distance(currentPosition, previousPosition) > 1)
        {
            Node node = CreateNode();

            previousNode = node;
            previousPosition = currentPosition;
        }
        
        
    }

    public void SaveWriteWay(bool onlySave = false, string wayName = null)
    {

        ways.Add(wayName != null ? wayName : "Node" + DateTime.Now.ToString(), writingWay);

        if (!onlySave)
        {
            writingWay = null;
            previousNode = null;
        }
    }

    public void DrawWay(List<Node> way)
    {
        ClearCurrentWay();

        currenWay = new List<GameObject>();

        way.AsParallel().ForAll(node => {
            DrawNode(node);

            previousNode = node;
        });
    }

    public void ClearCurrentWay()
    {
        if (currenWay == null)
            return;

        //асинхронно удаляем все объекты предыдущего пути
        currenWay.AsParallel().ForAll(node =>
        {
            Destroy(node);
        });

        currenWay = null;
    }

    public void StartWriteWay()
    {
        ClearCurrentWay();
        
        writingWay = new List<Node>();

        Node node = CreateNode(true);

        previousNode = node;

        writingWay.Add(node);
    }

    private Node CreateNode(bool isKeyNode = false)
    {
        GameObject nodeObject = SpawnPrefab(isKeyNode);

        Node node = nodeObject.AddComponent<Node>();

        writingWay.Add(node);

        return node;
    }
    
    private GameObject SpawnPrefab(bool isKeyNode,  Vector3? position = null)
    {
        if (position == null)
            position = Camera.main.transform.position;

        GameObject nodeObject = Instantiate(isKeyNode ? keyPointPrefab : arrowPrefab, (Vector3)position, Quaternion.identity);

        if (previousNode != null)
        {
            nodeObject.transform.LookAt(previousNode.position);
        }

        return nodeObject;
    }

    private void DrawNode(Node node)
    {
        GameObject nodeObject = Instantiate(arrowPrefab, node.position, Quaternion.identity);

        if (previousNode != null)
        {
            nodeObject.transform.LookAt(previousNode.position);
        }


        Node objectNode = nodeObject.AddComponent<Node>();
        objectNode = node;
    }
}