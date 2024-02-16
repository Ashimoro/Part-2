using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ResolutionScript : MonoBehaviour
{
    public void SetResolution1()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    public void SetResolution2()
    {
        Screen.SetResolution(1280, 720, false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
