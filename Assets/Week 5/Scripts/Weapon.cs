using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rigibody;

    public float speed = 4;
    float timer = 0;
    float maxTime = 5;
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
        rigibody.position = new Vector2(5, Random.Range(-5,5));
    }

    private void FixedUpdate()
    {
        rigibody.MovePosition(rigibody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("takeDamage", 1);
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            Destroy(gameObject);
        }


        rigibody.transform.position = transform.position;
    }
}
