using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.Collections;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    [SerializeField]
    private string _nameCharacterPrefab; 

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

        GameObject pl = PhotonNetwork.Instantiate(_nameCharacterPrefab, Vector3.zero, Quaternion.identity);

        if (pl.GetComponent<PhotonView>().IsMine)
        {
            pl.GetComponent<PlayerTest>().rollPlayer = GetRandomEnum<RollDropDown>();
            PlayerInstaller.Instance.InstallPlayer(pl.GetComponent<PlayerTest>());
        }

    }

    public static T GetRandomEnum<T>()
    {
        var values = System.Enum.GetValues(typeof(T));
        return (T)values.GetValue(Random.Range(0, values.Length));
    }

}
