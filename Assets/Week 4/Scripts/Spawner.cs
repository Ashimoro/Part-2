using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    float timer = 0f;
    float spawnInterval = Random.Range(1,5);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if( timer > spawnInterval)
        {
            Instantiate(prefab,Vector3.up,Quaternion.identity);

            timer = 0f;
            spawnInterval = Random.Range(1,5);
        }
    }
}
