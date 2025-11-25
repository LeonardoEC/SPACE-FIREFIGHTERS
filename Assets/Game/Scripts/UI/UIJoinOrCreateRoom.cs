using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class UIJoinOrCreateRoom : MonoBehaviour
{
    private NetworkingManager _networkingManager;

    [Space(10)]
    public TMP_InputField _roomNameInputText;
    public TMP_InputField _namePlayerinputText;
    public Button _findMatchButton;



    private void Start()
    {
        _networkingManager = NetworkingManager.Instance;
        if (_findMatchButton != null)
            _findMatchButton.onClick.AddListener(_networkingManager.FindMatch);
    }

    // Update is called once per frame
    void Update()
    {
        if (_roomNameInputText.interactable != _networkingManager._readyMultiplayer)
        {
            _roomNameInputText.interactable = _networkingManager._readyMultiplayer;
        }
        
        


        if (_roomNameInputText.text != "")
        {
            _findMatchButton.interactable = true;
            if (_networkingManager.roomName != _roomNameInputText.text)
            {
                _networkingManager.roomName = _roomNameInputText.text;
                _networkingManager.playerName = _namePlayerinputText.text;
            }
        }
        else
        {
            _findMatchButton.interactable = false;
        }

    }
}
