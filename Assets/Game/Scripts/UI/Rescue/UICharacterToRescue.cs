using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterToRescue : MonoBehaviour
{

    public static UICharacterToRescue Instance;

    [Range(0f,1f)]
    [SerializeField]
    private float lifeCharacter;

    [SerializeField] private int _indexImg;

    [Space(10)]
    [SerializeField] private List<Image> _imgList;

    private Image _currentImg;
    private int _currentIndex;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Image img in _imgList)
        {
            img.fillAmount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (_currentIndex != _indexImg)
        {
            _currentImg = _imgList[_indexImg];
            lifeCharacter = _currentImg.fillAmount;
            _currentIndex = _indexImg;
        }

        if (_currentImg != null && _currentImg.fillAmount != lifeCharacter)
        {
            _currentImg.fillAmount = lifeCharacter;
        }

    }

    public void SendlifeCharacteToRescue(int index, float life)
    {
        _imgList[index].fillAmount = life;
    }
}
