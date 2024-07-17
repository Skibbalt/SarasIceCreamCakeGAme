using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MergeRules", menuName = "ScriptableObjects/MergeRules", order = 1)]
public class MergeRules : ScriptableObject
{
    [System.Serializable]
    public struct MergePair
    {
        public GameObject prefab1; //object one to be merged
        public GameObject prefab2; //object two to be merged
        public GameObject resultPrefab; //The end resault of the merge a new object
    }

    public MergePair[] mergePairs;
}