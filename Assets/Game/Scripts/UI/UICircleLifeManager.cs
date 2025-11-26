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

    public List<PlayerTest> _others;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }

    void Start()
    {
        //UpdateLifes = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateLifes)
        {            
            if (_others.Count > 0) {
                int indexOthers = 0;

                foreach (UICircleLifeCharacter item in _othersLifecircle)
                {
                    item._playerRef = _others[indexOthers];
                    indexOthers++;
                }
            }

           
            UpdateLifes = false;
        }
    }

    public void SetOwnerPlayer(PlayerTest obj)
    {
        _ownerUILife._playerRef = obj;
    }
    public void SetOhterPlayer(PlayerTest obj)
    {
        _others.Add(obj);
        _othersLifecircle[_others.Count-1]._playerRef = obj;
        //UpdateLifes = true;
    }
}
