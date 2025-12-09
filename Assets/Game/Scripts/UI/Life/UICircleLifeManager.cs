using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICircleLifeManager : MonoBehaviour
{
    public static UICircleLifeManager Instance;

    public UICircleLifeCharacter _ownerUILife;

    [Space(10)]
    public List<UICircleLifeCharacter> _othersLifecircle;

    public bool UpdateLifes;

    public List<PlayerInfo> _others;

    private Queue<PlayerInfo> myQueue = new Queue<PlayerInfo>();

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (UpdateLifes)
        {
            int indexOthers = 0;
            foreach (PlayerInfo player in _others)
            {
                _othersLifecircle[indexOthers]._playerRef = player;
                indexOthers++;
            }
           
            UpdateLifes = false;
        }
    }

    public void SetOwnerPlayer(PlayerInfo obj)
    {
        _ownerUILife._playerRef = obj;
    }
    public void SetOhterPlayer(PlayerInfo obj)
    {
        if (!myQueue.Contains(obj) && !obj._photonView.IsMine)
        {
            myQueue.Enqueue(obj);
            _others.Add(obj);
            UpdateLifes = true;
        }
    }
}
