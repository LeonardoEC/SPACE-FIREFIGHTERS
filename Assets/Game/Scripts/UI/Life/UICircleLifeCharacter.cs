using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICircleLifeCharacter : MonoBehaviour
{
    public PlayerInfo _playerRef;

    [Space(10)]
    [SerializeField] private Image _characterImg;
    [SerializeField] private Image _characterLifeCircle;
    [SerializeField] private TextMeshProUGUI _nameText;
    public int _currentLiveBar = 100;

    [Space(10)]
    public bool moveBar;
    [Range(0, 100)]
    [SerializeField] private int liveBar = 100;

    
    private float _barProgres;

    [Space(10)]
    [SerializeField] private Color _colorA;
    [SerializeField] private Color _colorB;
    [SerializeField] private Color _colorC;
    [SerializeField] private Color _colorD;

    [Space(10)]
    [SerializeField] private int _limitA = 70;
    [SerializeField] private int _limitB = 40;
    [SerializeField] private int _limitC = 25;
    [SerializeField] private int _limitD = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (_playerRef == null)
        {
            if (_characterImg.gameObject.activeSelf) {
                _characterImg.gameObject.SetActive(false);
                _characterLifeCircle.gameObject.SetActive(false);
            }
            return;
        }
        else if (!_characterImg.gameObject.activeSelf){
                _characterImg.gameObject.SetActive(true);
                _characterLifeCircle.gameObject.SetActive(true);
        }


        _currentLiveBar = _playerRef._lifePlayer;

        if (_nameText.text != _playerRef.namePlayer){
            _nameText.text = _playerRef.namePlayer;
        }

        _barProgres = (float)liveBar / 100f;

        if (liveBar != _currentLiveBar && !moveBar)
        {
            StartCoroutine(MoveBar());
        }

        _characterLifeCircle.fillAmount = _barProgres;


        if (liveBar > _limitA) {
            _characterLifeCircle.color = _colorA;
        }
        if (liveBar <= _limitA && liveBar > _limitB) {
            _characterLifeCircle.color = _colorB;
        }
        if (liveBar <= _limitB && liveBar > _limitC) {
            _characterLifeCircle.color = _colorC;
        }
        if (liveBar <= _limitC) {
            _characterLifeCircle.color = _colorD;
        }
        if (liveBar < _limitD)
        {
            _characterImg.color = Color.gray;
        }
        if (liveBar >= _limitD)
        {
            _characterImg.color = Color.white;
        }

    }

    IEnumerator MoveBar()
    {
        moveBar = true;

        while (liveBar > _currentLiveBar)
        {
            yield return new WaitForSeconds(0.03f);
            liveBar--;
        }
        while (liveBar < _currentLiveBar)
        {
            yield return new WaitForSeconds(0.03f);
            liveBar++;
        }

        moveBar = false;

    }
}
