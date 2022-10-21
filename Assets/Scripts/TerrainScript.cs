using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    PoolingGeneration pooling;

    Transform playerPos;


    void Start()
    {
        pooling = GameObject.FindGameObjectWithTag("Pooling").GetComponent<PoolingGeneration>();

    }

    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        
        if ((int)playerPos.position.x == (int)gameObject.transform.GetChild(0).position.x)
        {
            pooling.PoolingPlatform(gameObject);
        }
    }
}
