using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Button_Transistion : MonoBehaviour
{
    [SerializeField]
    private string nextSceneToLoad;

    public void OnLoadNextSceneClick()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
