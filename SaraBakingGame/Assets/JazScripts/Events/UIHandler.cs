using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class UIHandler : MonoBehaviour
{
    [SerializeField] private Image targetImage; // Assign the UI Image in the inspector
    [SerializeField] private Sprite butterBowlSprite; // Reference for the butter bowl sprite
    [SerializeField] private Sprite eggBowlSprite; // Reference for the egg bowl sprite

    private void OnEnable()
    {
        if (MergeEventManager.Instance != null)
        {
            MergeEventManager.Instance.OnItemMerged += UpdateUI; // Subscribe to the event
        }
        else
        {
            UnityEngine.Debug.LogError("MergeEventManager instance is not available.");
        }
    }

    private void OnDisable()
    {
        if (MergeEventManager.Instance != null)
        {
            MergeEventManager.Instance.OnItemMerged -= UpdateUI; // Unsubscribe from the event
        }
    }

    private void UpdateUI(GameObject newItem)
    {
        // Check the tag or name of the new item to determine which sprite to use
        if (newItem.CompareTag("EggBowl"))
        {
            targetImage.sprite = butterBowlSprite; // Set the UI image to butter bowl sprite
        }
        else if (newItem.CompareTag("WetBowl3"))
        {
            targetImage.sprite = eggBowlSprite; // Set to another sprite if needed
        }
        // Add more conditions for other merged items as needed
    }
}
