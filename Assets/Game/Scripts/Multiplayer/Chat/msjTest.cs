using UnityEngine;
using Photon.Pun;
using TMPro;

public class msjTest : MonoBehaviourPun
{

    public PhotonView _photonView;
    public TMP_InputField _inputMsj;
    public TextMeshProUGUI _text;
    public bool sendMSJ;

    public string id;
    public string msj;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        id =  NetworkingManager.Instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        if (sendMSJ)
        {
            msj = _inputMsj.text;
            object[] data = new object[] { id, msj };

            photonView.RPC("RPC_SendMensaje", RpcTarget.All, data);

            _inputMsj.text = "";
            sendMSJ = false;
        }
    }

    [PunRPC]
    void RPC_SendMensaje(object[] data)
    {

        _text.text = (string)data[0] + ": " + (string)data[1];
    }


    public void SendMensaje()
    {
        sendMSJ = true;
    }
}
