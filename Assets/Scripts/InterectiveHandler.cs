using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterectiveHandler : MonoBehaviour
{
    public const string expansion = "Expansion";

    private List<GameObject> expansions = new List<GameObject>();

    public GameObject actionObject = null;
    public GameObject manualyObject = null;

    public GameObject actionButton;
    public GameObject objDescription;
    public GameObject positionText;
    public List<GameObject> objectsToHint = new List<GameObject>();

    void Start()
    {
        expansions = GameObject.FindGameObjectsWithTag(expansion).ToList();

        objectsToHint.Add(actionButton);

        objectsToHint.ForEach((it) =>
        {
            it.SetActive(false);
        });
    }

    void Update()
    {
        if (manualyObject != null)
        {
            actionObject = manualyObject;
            positionText.GetComponent<TextMeshProUGUI>().text = actionObject.name;
            return;
        }

        actionObject = null;

        expansions.ForEach(obj =>
        {
            if (Vector3.Distance(Camera.main.transform.position, obj.transform.position) < 0.5)
            {
                actionObject = obj;
                return;
            }
        });
        
        if (actionObject == null)
        {
            objectsToHint.ForEach((it) =>
            {
                it.SetActive(false);
            });
            return;
        }

        objectsToHint.ForEach((it) =>
        {
            it.SetActive(true);
        });

        positionText.GetComponent<TextMeshProUGUI>().text = actionObject.name;
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
