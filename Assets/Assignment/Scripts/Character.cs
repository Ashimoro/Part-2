using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEditor.Build;

public class Character : MonoBehaviour
{
    public float speed = 3;
    public float health = 3;
    float moveTime;

    bool dead = false;

    public Animator animator;
    public AnimationCurve curve;
    Rigidbody2D rigibody;

    Vector2 movement;
    Vector2 destination;
    Vector2 startPosition;
    Vector2 endPosition;

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
        if (dead) return;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            startPosition = transform.position;
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveTime = 0;
        }

        movement = destination - (Vector2)transform.position;
        animator.SetFloat("Horizontal", destination.x);
        animator.SetFloat("Vertical", destination.y);
        animator.SetFloat("Speed", movement.magnitude);

    }

    private void FixedUpdate()
    {
        if (dead) return;
       

        if (movement.magnitude < 0.1f)
        {
            movement = Vector2.zero;
        }
        else
        {
            moveTime += Time.deltaTime;
            float curveMove = curve.Evaluate(moveTime);
            endPosition = Vector2.Lerp(startPosition, destination, curveMove);

            rigibody.MovePosition(endPosition);
        }

    }

    public void DamageReceived(int damage)
    {
        health -= damage;

        speed -= damage;

        if (health >= 2)
        {
            Debug.Log("It Hurts!");
        }
        else
        {
            Debug.Log("I'm almost dead!");
        }
        if (health <= 0)
        {
            dead = true;
            transform.Rotate(0, 0, 90);
            transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            animator.SetBool("Dead", true);

        }

    }

}
