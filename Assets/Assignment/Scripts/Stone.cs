using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{

    public GameObject Button;
    public GameObject inventorySlot;
    
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
    }

    public void PickUp()
    {
        inventorySlot.SetActive(true);
        Destroy(gameObject);
    }
}
