using System.Collections;
using UnityEngine;

public class Merger : MonoBehaviour
{
    [SerializeField] private MergeRules mergeRules;
    private bool isMerging = false; // Flag to track if the object is currently merging

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if either object is inactive
        if (!gameObject.activeInHierarchy || !collision.gameObject.activeInHierarchy)
            return; // Exit if either object is destroyed or inactive

        // Prevent multiple merges
        if (isMerging || collision.gameObject.GetComponent<Merger>().isMerging)
            return;

        if (mergeRules == null)
        {
            UnityEngine.Debug.LogError("MergeRules is not assigned.");
            return;
        }

        GameObject other = collision.gameObject;
        UnityEngine.Debug.Log($"Collision detected between {gameObject.tag} and {other.tag}");

        foreach (var pair in mergeRules.mergePairs)
        {
            if (pair.prefab1 == null || pair.prefab2 == null || pair.resultPrefab == null)
            {
                UnityEngine.Debug.LogError("One of the merge pairs is not properly assigned.");
                continue;
            }

            if ((gameObject.tag == pair.prefab1.tag && other.tag == pair.prefab2.tag) ||
                (gameObject.tag == pair.prefab2.tag && other.tag == pair.prefab1.tag))
            {
                UnityEngine.Debug.Log($"Merging {gameObject.tag} and {other.tag} to create {pair.resultPrefab.name}");

                // Instantiate the result prefab at the average position
                Vector3 newPosition = (transform.position + other.transform.position) / 2;
                GameObject newPrefab = Instantiate(pair.resultPrefab, newPosition, Quaternion.identity);

                // Trigger the event
                MergeEventManager.Instance.ItemMerged(newPrefab);

                // Mark both objects as merging
                isMerging = true;
                collision.gameObject.GetComponent<Merger>().isMerging = true;

                // Destroy the original prefabs
                Destroy(gameObject);
                Destroy(other);

                // Optionally reset merging state after a short delay
                StartCoroutine(ResetMergingState());

                break; // Exit after a successful merge
            }
        }
    }

    private IEnumerator ResetMergingState()
    {
        yield return new WaitForSeconds(1f); // Adjust duration as needed
        isMerging = false; // Allow merging again
    }
}
