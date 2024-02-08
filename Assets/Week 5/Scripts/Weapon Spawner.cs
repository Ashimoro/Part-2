using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject knife;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void spawn()
    {
        Instantiate (knife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
