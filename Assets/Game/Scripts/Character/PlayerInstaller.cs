using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstaller : MonoBehaviour
{
    public static PlayerInstaller Instance;

    [SerializeField] private List<PlayerConfig> _prefabsPlayerList;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }


    public void InstallPlayer(PlayerTest _player)
    {
        _player.Configure(
            NetworkingManager.Instance.playerName,
            _player.rollPlayer
            );

    }

    public GameObject GetPrefabById(RollDropDown id)
    {
        GameObject objReturn = new();

        foreach (PlayerConfig item in _prefabsPlayerList) {
            if (item.id == id) {
                objReturn = item.prefab;
            }
        }

        return objReturn;
    }
}
