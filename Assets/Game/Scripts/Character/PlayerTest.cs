using UnityEngine;
using Photon.Pun;


public class PlayerTest : MonoBehaviourPun
{
    public PhotonView _photonView;
    public string namePlayer;
    public RollDropDown rollPlayer;
    public int _lifePlayer = 50;
    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (!_photonView.IsMine)
        {
            _photonView.RPC("RPC_GetConfigure", RpcTarget.Others);
            
        }

    }
    public void Configure(string namePlayer, RollDropDown rollPlayer)
    {
        this.namePlayer = namePlayer;
        this.rollPlayer = rollPlayer;
        Instantiate(PlayerInstaller.Instance.GetPrefabById(rollPlayer), transform);

        switch (rollPlayer)
        {
            case RollDropDown.bombero:
                gameObject.transform.position = new Vector3(-3f, 0, 0);
                break;
            case RollDropDown.guantes:
                gameObject.transform.position = new Vector3(0f, 0, 0);
                break;
            case RollDropDown.hose:
                gameObject.transform.position = new Vector3(3f, 0, 0);
                break;
            default:
                gameObject.transform.position = new Vector3(0f, 0, 0);
                break;
        }

        UICircleLifeManager.Instance.SetOwnerPlayer(this);

        ////no se puede enviar objetos, en el installer se seleccioan cual con id
        //object[] data = new object[] { namePlayer, rollPlayer };
        //_photonView.RPC("RPC_SendConfigure", RpcTarget.Others, data);
    }

    [PunRPC]
    void RPC_SendConfigure(object[] data)
    {
        this.namePlayer = (string)data[0];
        this.rollPlayer = (RollDropDown)data[1];
        Instantiate(PlayerInstaller.Instance.GetPrefabById(rollPlayer), transform);

        switch (rollPlayer)
        {
            case RollDropDown.bombero:
                gameObject.transform.position = new Vector3(-3f, 0, 0);
                break;
            case RollDropDown.guantes:
                gameObject.transform.position = new Vector3(0f, 0, 0);
                break;
            case RollDropDown.hose:
                gameObject.transform.position = new Vector3(3f, 0, 0);
                break;
            default:
                gameObject.transform.position = new Vector3(0f, 0, 0);
                break;
        }

        UICircleLifeManager.Instance.SetOhterPlayer(this);
    }

    [PunRPC]
    void RPC_GetConfigure()
    {
        object[] data = new object[] { namePlayer, rollPlayer };
        _photonView.RPC("RPC_SendConfigure", RpcTarget.Others, data);
    }

}
