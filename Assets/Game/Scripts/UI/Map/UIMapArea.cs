using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMapArea : MonoBehaviour
{
    public AreaType areaType;

    [SerializeField] private Color _colorA;
    [SerializeField] private Color _colorB;
    [SerializeField] private Color _colorC;
    [SerializeField] private Color _colorD;

    [Space(10)]
    [SerializeField] private int _Limit1 = 7;
    [SerializeField] private int _Limit2 = 5;
    [SerializeField] private int _Limit3 = 2;

    [Space(10)]
    [Range(0, 10)]
    public int _line;

    public Image _imgA;

    private void Start()
    {
        RestLevel();
    }

    public void SetLevel(int value)
    {
        _line += value;
        SetLevelColor();
    }

    void SetLevelColor()
    {
        if (_line >= _Limit1)
        {
            _imgA.color = _colorA;
        }
        if (_line < _Limit1 && _line >= _Limit2)
        {
            _imgA.color = _colorB;
        }
        if (_line < _Limit2 && _line >= _Limit3)
        {
            _imgA.color = _colorC;
        }
        if (_line < _Limit3)
        {
            _imgA.color = _colorD;
        }
    }

    public void RestLevel()
    {
        _line = 10;
        SetLevelColor();
    }
}
