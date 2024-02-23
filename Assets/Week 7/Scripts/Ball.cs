using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Ball : MonoBehaviour
{

    Rigidbody2D rigibody;

    float y = -1.3f;
    // Start is called before the first frame update


    private void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.score++;
        ResetBall();
    }

    
    

    private void ResetBall()
    {
        this.transform.position = new Vector2(0,y);
        this.rigibody.velocity = Vector3.zero;
        
    }
}
