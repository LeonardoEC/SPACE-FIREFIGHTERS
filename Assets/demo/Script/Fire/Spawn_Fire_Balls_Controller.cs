using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Fire_Balls_Controller : MonoBehaviour
{
    public GameObject miniFire;
    float spawnLimitXLeft = 17f;
    float spawnLimitXRight = -11f;
    float spawnLimitPosTopY = 8.5f;
    float spawnLimitPosDownY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireInstancie", 1f, Random.Range(1f, 10f));
    }


    void FireInstancie()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), Random.Range(spawnLimitPosTopY, spawnLimitPosDownY), transform.position.z);

        Instantiate(miniFire, spawnPos, Quaternion.identity);
    }
}
