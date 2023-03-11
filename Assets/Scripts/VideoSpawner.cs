using System.Collections.Generic;
using UnityEngine;

public class VideoSpawner : MonoBehaviour
{
    public GameObject videoObject;
    public List<GameObject> objectsToHidden = new List<GameObject>();
    public List<GameObject> objectsToRemove = new List<GameObject>();
    private static GameObject lastPlayer;

    public void SpawnVideoPlayer()
    {   
        Destroy(lastPlayer);
        lastPlayer = Instantiate(videoObject, new Vector3(0, 0, 1), Quaternion.identity);

        objectsToHidden.ForEach(obj =>
        {
            obj.SetActive(false);
        });

        objectsToRemove.ForEach(obj =>
        {
            Destroy(obj);
        });

    }
}
