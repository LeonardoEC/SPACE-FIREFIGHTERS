using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;
using TMPro;
using UnityEngine.UI;


public class msjTest : MonoBehaviourPun
{

    public PhotonView _photonView;
    public GameObject _panel;
    public TMP_InputField _inputMsj;
    public TextMeshProUGUI _text;
    public bool sendMSJ;

    public string id;
    public string msj;


    public bool _showPanel;

    public List<string> msjList;


    public Recorder _recorder;
    public Button _microButton;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        id =  NetworkingManager.Instance.playerName;
        
        _panel.SetActive(_showPanel);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (_recorder == null)
            {
                _recorder = FindAnyObjectByType<Recorder>();
            }
            _recorder.TransmitEnabled = !_recorder.TransmitEnabled;
            _microButton.interactable = !_microButton.interactable;
        }

        if (Input.GetKeyDown(KeyCode.Return) && _inputMsj.text == "")
        {
            _showPanel = !_showPanel;
            _panel.SetActive(_showPanel);            
        }       

        if (Input.GetKeyDown(KeyCode.Return) && _inputMsj.text != "")
        {
            SendMensaje();
            _inputMsj.ActivateInputField();
        }

        if (_showPanel && !_inputMsj.isFocused)
        {
            _inputMsj.ActivateInputField();
        }
        else if (!_showPanel && _inputMsj.isFocused)
        {
            _inputMsj.text = "";
            _inputMsj.DeactivateInputField();
        }

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
        //hacer la funcion
        //_text.text = (string)data[0] + ": " + (string)data[1];
        HistoryOfChat("<color=yellow>" + (string)data[0] + ": " + "</color>" + (string)data[1]);
    }


    public void SendMensaje()
    {
        sendMSJ = true;
    }

    private void HistoryOfChat(string newMsj)
    {
        msjList.Add(newMsj);
        _text.text = "";

        foreach (string m in msjList)
        {
            _text.text += m + "\n";
        }
    }
    
}
