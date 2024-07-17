using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Baking_Manager : MonoBehaviour
{
    public UnityEvent TaskListComplete; 
    public OneBakingTask oneBakingTask; //Referring to the "OneBakingTask" class below
    public Collection_Of_BakingTasks collectionOfBakingTasks; //Referring to the "Collection_Of_BakingTasks" script
    public TMP_Text textForTask;

    [HideInInspector]
    public string recievedIngredient; //This variable will be influeced by the "Single_Baking_Task" script. It simply acts as a placeholder. 

    private string listIndex; 

    private void Update()
    {
        foreach(var bakingTask in collectionOfBakingTasks.bakingTask) 
        //Checking every variable type that's called a "bakingTask" in the Collection_Of_BakingTasks' list
        {
            oneBakingTask.bakingItemName = recievedIngredient; //Accessing the variable named "bakingItemName" from the "oneBakingTask" script, then assigning it "recievedIngredient"

            listIndex = bakingTask.bakingItemName; //Assigning "listIndex" with the variable "bakingItemName" from a "bakingTask" within the list in the "Collection_Of_BakingTasks" script
            
            if(listIndex == recievedIngredient)
            {
                TaskListComplete?.Invoke();
                textForTask.text = string.Format("<s>" + textForTask.text + "<s>"); 
            }
        }
    }

    public void UpdateTasks()
    {

    }
}

[System.Serializable]
public class OneBakingTask
{
    public string bakingInstruction;
    public string bakingItemName;
}