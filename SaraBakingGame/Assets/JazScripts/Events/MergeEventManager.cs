using System;
using UnityEngine;

public class MergeEventManager : MonoBehaviour
{
    public static MergeEventManager Instance { get; private set; }

    public event Action<GameObject> OnItemMerged; // Event to notify when an item is merged

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes if needed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ItemMerged(GameObject newItem)
    {
        OnItemMerged?.Invoke(newItem); // Invoke the event
    }
}
