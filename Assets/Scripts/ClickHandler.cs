using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    Animator animator;

    GameObject eventSystem;

    public GameObject dialog;

    //int currentId = 0;
    //List<string> animations = new List<string>() {"Idle", "Walk", "Run", "Eat", "Turn Head" };

    public void OnPointerClick(PointerEventData eventData)
    {
        dialog.SetActive(true);

        eventSystem.GetComponent<VideoSpawner>().objectsToRemove.Add(this.gameObject);
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("Eat", true);

        eventSystem = GameObject.Find("EventSystem");

        dialog = Resources
        .FindObjectsOfTypeAll<GameObject>()
        .FirstOrDefault(g => g.CompareTag("dialog"));
    }
}
