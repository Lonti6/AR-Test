using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InterectiveHandler : MonoBehaviour
{
    public const string expansion = "Expansion";

    private List<GameObject> expansions = new List<GameObject>();

    public GameObject actionButton = null;

    public GameObject actionObject = null;

    public GameObject objDescription = null;

    void Start()
    {
        expansions = GameObject.FindGameObjectsWithTag(expansion).ToList();

        actionButton.SetActive(false);

        objDescription.SetActive(false);
    }

    void Update()
    {
        actionObject = null;

        print(expansions.Count);

        expansions.ForEach(obj =>
        {
            if (Vector3.Distance(Camera.main.transform.position, obj.transform.position) < 0.5)
            {
                actionObject = obj;
                actionButton.SetActive(true);
                return;
            }
        });
        
        if (actionObject == null)
        {
            actionButton.SetActive(false);
            return;
        }
    }

    public void changeAction(int actionNumber)
    {
        var exp = actionObject.GetComponent<Expansion>();
        if (actionNumber == 0)
        {
            exp.isRotate = false;
            objDescription.SetActive(false);
        }
        else if (actionNumber == 1)
        {
            exp.isRotate = !exp.isRotate;
        } 
        else if (actionNumber == 2)
        {
            objDescription.SetActive(!objDescription.activeSelf);
            objDescription.GetComponent<TextMeshProUGUI>().text = exp.description;
        }

        
    }
}
