using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 3;

    public Animator animator;
    Rigidbody2D rigibody;

    Vector2 movement;
    Vector2 destination;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigibody = GetComponent<Rigidbody2D>();

        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        movement = destination - (Vector2)transform.position;

        animator.SetFloat("Horizontal", destination.x);
        animator.SetFloat("Vertical", destination.y);
        animator.SetFloat("Speed", movement.magnitude);

    }

    private void FixedUpdate()
    {

        if (movement.magnitude < 0.1f)
        {
            movement = Vector2.zero;
        }
        else
        {
            rigibody.MovePosition(rigibody.position + movement.normalized * speed * Time.deltaTime);
        }

    }
}
