using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class ScemeBLoader : MonoBehaviour
{
    public void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
