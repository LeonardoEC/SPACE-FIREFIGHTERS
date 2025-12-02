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

    Fire_Wall_Controller wallFireController;

    int poolFire = 5;
    List<GameObject> firePool;

    private void Awake()
    {
        wallFireController = GetComponentInParent<Fire_Wall_Controller>();
        FirePoolStart();
    }


    void Start()
    {
        InvokeRepeating("FireInstancie", 1f, Random.Range(1f, 2f));
    }


    void FirePoolStart()
    {
        firePool = new List<GameObject>();
        for(int i = 0; i < poolFire; i++)
        {
            GameObject fire = Instantiate(miniFire);
            fire.SetActive(false);
            firePool.Add(fire);
        }
    }

    GameObject GetFire()
    {
        foreach(var fire in firePool)
        {
            if(!fire.activeInHierarchy)
            {
                return fire;
            }
        }
        return null;
    }

    void FireInstancie()
    {
        GameObject poolFire = GetFire();
        if (wallFireController != null)
        {
            if(wallFireController.isPaused)
            {
                if (poolFire != null)
                {
                    poolFire.transform.position = RandomSpawPosition();
                    poolFire.transform.rotation = Quaternion.identity;
                    poolFire.SetActive(true);
                }
            }
        }


    }


    Vector3 RandomSpawPosition()
    {
        Vector3 spawnPos = new Vector3(
        Random.Range(spawnLimitXLeft, spawnLimitXRight),
        Random.Range(spawnLimitPosTopY, spawnLimitPosDownY),
        transform.position.z
        );

        return spawnPos;
    }
}
