using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class UIHandler : MonoBehaviour
{
    [SerializeField] private Image targetImage; // Assign the UI Image in the inspector
    [SerializeField] private Sprite one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen,fourteen,fifteen,sixteen,seventeen,eightteen;

    private Dictionary<string, Sprite> spriteMappings;

    private void Awake()
    {
        // Initialize the dictionary with the mappings
        spriteMappings = new Dictionary<string, Sprite>
        {
            { "EggBowl", one },
            { "EOilBowl", two },
            { "WetBowl3", three },
            { "WetBowl4", four },
            {"WetBowl5", five },
            {"WetBowl6", six },
            {"WetBowl", seven },
            {"FlourBowl", eight },
            {"CocoBowl", nine },
            {"BakingBowl", ten },
            {"SugarBowl", eleven },
            {"SaltBowl", twelve },
            {"PSugarBowl", thirteen },
            {"CakeBatter", fourteen },
            {"CakeBatterPan", fifteen  },
            {"Cake", sixteen },
            {"IceCreamCake", seventeen },
            {"OreoIceCreamCake", eightteen },
          
        };
    }

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
        // Check if the new item's tag exists in the dictionary
        if (spriteMappings.TryGetValue(newItem.tag, out Sprite newSprite))
        {
            targetImage.sprite = newSprite; // Set the UI image to the corresponding sprite
        }
        else
        {
            UnityEngine.Debug.LogWarning($"No sprite mapping found for tag: {newItem.tag}");
        }
    }
}
