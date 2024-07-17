using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create_A_Baking_Task_For_The_Player", menuName = "Siena SO's/Give A Baking Task", order = 1)]
public class Collection_Of_BakingTasks : ScriptableObject
{
    public List<OneBakingTask> bakingTask = new List<OneBakingTask>(); //Referring to the "OneBakingTask" class within the "Baking_Manager" script
}
