using UnityEngine;
using UnityEngine.EventSystems;

public class UISafeInit : MonoBehaviour
{
    void Awake()
    {
        EventSystem[] systems = FindObjectsOfType<EventSystem>();

        for (int i = 1; i < systems.Length; i++)
        {
            Destroy(systems[i].gameObject);
        }
    }
}