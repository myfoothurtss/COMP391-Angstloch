using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart ()
    {
        SceneManager.LoadScene(sceneName:"AngstlochLEVEL1");
    }

    public void QuitGame ()
    {
        Debug.Log ("Quit Succesfully!");
        Application.Quit();
    }
}