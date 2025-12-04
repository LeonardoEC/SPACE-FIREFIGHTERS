using UnityEngine;
using Photon.Pun;

public class PlayerInfo : MonoBehaviourPun
{
    public PhotonView _photonView;
    public string namePlayer;
    public RollDropDown rollPlayer;
    public int _lifePlayer = 50;

    [Space(10)]
    public Player_Tool_Detector _tool_Detector;

    private int _beforeLife;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (!_photonView.IsMine)
        {
            _photonView.RPC("RPC_GetConfigure", RpcTarget.Others);
            
        }

    }

    private void OnEnable()
    {
        UIGameOver.Instance.resetAction += ResetInfoPlayer;
    }
    private void OnDisable()
    {
        UIGameOver.Instance.resetAction -= ResetInfoPlayer;
    }
    private void OnDestroy()
    {
        UIGameOver.Instance.resetAction -= ResetInfoPlayer;
    }

    private void Update()
    {
        if (!_photonView.IsMine)
            return;

        if (_lifePlayer != _beforeLife)
        {
            _photonView.RPC("RPC_SetPointsOfLife", RpcTarget.Others, _lifePlayer);
            _beforeLife = _lifePlayer;
        }
    }


    public void Configure(string namePlayer, RollDropDown rollPlayer)
    {
        this.namePlayer = namePlayer;
        this.rollPlayer = rollPlayer;
        Instantiate(PlayerInstaller.Instance.GetPrefabById(rollPlayer), _tool_Detector.gameObject.transform);
        //_tool_Detector.ToolDectertor();

        UICircleLifeManager.Instance.SetOwnerPlayer(this);

     
       
    }

    [PunRPC]
    void RPC_SendConfigure(object[] data)
    {
        this.namePlayer = (string)data[0];
        this.rollPlayer = (RollDropDown)data[1];
        //Instantiate(PlayerInstaller.Instance.GetPrefabById(rollPlayer), transform);

        UICircleLifeManager.Instance.SetOhterPlayer(this);
    }

    [PunRPC]
    void RPC_GetConfigure()
    {
        object[] data = new object[] { namePlayer, rollPlayer };
        _photonView.RPC("RPC_SendConfigure", RpcTarget.Others, data);
    }

    [PunRPC]
    void RPC_SetPointsOfLife(int value)
    {
        _lifePlayer = value;
    }


    private void ResetInfoPlayer()
    {
        _lifePlayer = 100;
    }
}
