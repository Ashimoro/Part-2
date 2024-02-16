using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void takeDamage(float damage)
    {
        slider.value -= damage;
    }

    public void UpdateHealth(int health) 
    {
        slider.value = health;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
