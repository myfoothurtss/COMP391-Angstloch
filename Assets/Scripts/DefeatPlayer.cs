using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D Player)
    {
        SceneManager.LoadScene(sceneName:"DefeatScreen");
    }   
}