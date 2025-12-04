using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public Transform[] playerSpawnPoints;
    public Transform[] npcSpawnPoints;

    public static SpawnPointManager instance;

    private void Awake()
    {
        instance = this;
    }

}
