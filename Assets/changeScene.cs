using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void GoToMainScene()
    {
        Debug.Log("???????????????????");
        SceneManager.LoadScene(1);
    }
    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
