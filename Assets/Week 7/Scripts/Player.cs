using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
  SpriteRenderer spriteRenderer;
    public Color selectColor;
    public Color unSelectColor;
    bool selected = false;
    bool self = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Selected(true);
    }


    public void Selected(bool selected)
    {
        if (selected)
        {
            spriteRenderer.color = selectColor;
        }
        else
        {
            spriteRenderer.color = unSelectColor;
        }
    }



}
