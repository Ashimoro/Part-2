using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{

    float force;
    public float maxForce = 1f;
    public static int score = 0;

    Vector2 direction;

    public Slider slider;
    public TextMeshProUGUI scoreUI;

    // Start is called before the first frame update
    public static Player SelectedPlayer { get; private set; }
    public static void SetSelectedPlayer(Player player)
    {


        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }

        SelectedPlayer = player;
        SelectedPlayer.Selected(true);
    }


    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            force = 0;
            slider.value = force;
        }
    }

    public void Update()
    {
        scoreUI.text = "Score: " + score;

        if (SelectedPlayer == null) return;

        if(Input.GetKeyDown(KeyCode.Space)) 
        {

            force = 0;
            direction = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {

            force += Time.deltaTime;
            force = Mathf.Clamp(force, 0, maxForce);
            slider.value = force;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)SelectedPlayer.transform.position).normalized * force;
        }


    }
}
