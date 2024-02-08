using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Knight : MonoBehaviour
{

    Vector2 destination;
    Vector2 movement;

    public float speed = 3;
    public float health;
    public float maxHealth = 5;

    bool clickingSelf = false;

    Rigidbody2D rigibody;
    Animator animator;

    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1 )
        {
            movement = Vector2.zero;
        }
        rigibody.MovePosition(rigibody.position + movement.normalized * speed * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clickingSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Movement", movement.magnitude);

    }

    private void OnMouseDown()
    {
        clickingSelf = true;
        takeDamage(1);
    }
    private void OnMouseUp()
    {
        clickingSelf = false;
    }
    void takeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health == 0)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            animator.SetTrigger("TakeDamage");
        }
    }
}
