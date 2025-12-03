using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstaller : MonoBehaviour
{
    public static PlayerInstaller Instance;

    //[SerializeField] private GameObject _playerControllerPrefab;
    [SerializeField] private List<PlayerConfig> _prefabsPlayerList;

    [Space(10)]
    [SerializeField] private List<Transform> _instantateTransformList;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }


    public void InstallPlayer(PlayerInfo _player)
    {
        _player.Configure(
            NetworkingManager.Instance.playerName,
            _player.rollPlayer
            );
        //Instantiate(_playerControllerPrefab, _player.gameObject.transform);

        //solo el componente del roll

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
