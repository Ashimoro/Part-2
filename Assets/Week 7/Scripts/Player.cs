using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
  SpriteRenderer spriteRenderer;
    bool selected = false;
    bool self = false;

    Rigidbody2D rigibody;

    public float speed = 100;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Selected(false);
        rigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Move(Vector2 direction)
    {
        rigibody.AddForce(direction * speed);
    }

    public void Selected(bool selected)
    {
        if (selected)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color = Color.red;
        }
    }



}
