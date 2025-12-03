using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkingManager : MonoBehaviourPunCallbacks
{
    

    public static NetworkingManager Instance { get; private set; }

    public delegate void LobbyGame();
    public event LobbyGame OnLobbyGame;

    public bool _readyMultiplayer;
    public string roomName = "danitest"; 
    public string playerName = "playerName";

    void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Conexion al servidor");
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public override void OnConnectedToMaster()
    {
        Debug.Log("Unirnos a un lobby");
        PhotonNetwork.JoinLobby();
        OnLobbyGame?.Invoke();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("estamos listos para multijugador");
        _readyMultiplayer = true;
    }

    public void FindMatch()
    {
        Debug.Log("Buscando una sala");
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        MakeRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Cargando Scena de juego");
        SceneManager.LoadScene(1);
    }


    private void MakeRoom()
    {
        //int randomRoomName = Random.Range(0, 5000);

        RoomOptions roomOptions = new RoomOptions()
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 6,
            PublishUserId = true
        };

        PhotonNetwork.CreateRoom(roomName, roomOptions);
        Debug.Log($"Sala Creada: {roomName}");
    }





}
