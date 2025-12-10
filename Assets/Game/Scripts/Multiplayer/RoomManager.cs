using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    public Transform _instantiatePosition;

    public bool prueba;
    public int _numOfIndex;
    [SerializeField] private List<RollDropDown> _rollList;

    [SerializeField]
    private GameObject _baseCharacterNetPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!PhotonNetwork.InRoom) return;


        GameObject pl = PhotonNetwork.Instantiate(_baseCharacterNetPrefab.name, _instantiatePosition.position, Quaternion.identity);

        if (pl.GetComponent<PhotonView>().IsMine)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                //MakeRollList();
                //pl.GetComponent<PlayerInfo>().rollPlayer = GetRandomEnum<RollDropDown>();
                
            }

            _numOfIndex = pl.GetComponent<PhotonView>().ViewID / 1000;

            pl.GetComponent<PlayerInfo>().rollPlayer = _rollList[_numOfIndex - 1];
            PlayerInstaller.Instance.InstallPlayer(pl.GetComponent<PlayerInfo>());

        }

    }

    public static T GetRandomEnum<T>()
    {
        var values = System.Enum.GetValues(typeof(T));
        return (T)values.GetValue(Random.Range(0, values.Length));
    }


    private void Update()
    {
        if (prueba)
        {
            MakeRollList();
            prueba = false;
        }
    }

    private void MakeRollList()
    {
        _rollList.Clear();
        AddRandomsRolls();
        AddRandomsRolls();

    }

    private void AddRandomsRolls()
    {
        int randomInt = Random.Range(0, 2);

        if (randomInt == 0)
        {
            _rollList.Add(RollDropDown.Bombero);
            _rollList.Add(RollDropDown.Medico);

        }
        else if (randomInt == 1)
        {
            _rollList.Add(RollDropDown.Medico);
            _rollList.Add(RollDropDown.Bombero);
        }
    }
}
