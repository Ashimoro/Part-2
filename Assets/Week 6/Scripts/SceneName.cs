using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class SceneName : MonoBehaviour
{
    TextMeshProUGUI sceneNameLabel;
    void Start()
    {
        sceneNameLabel = GetComponent<TextMeshProUGUI>();
        sceneNameLabel.text = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
