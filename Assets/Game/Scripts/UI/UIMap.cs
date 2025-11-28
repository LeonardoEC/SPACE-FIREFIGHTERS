using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMap : MonoBehaviour
{
    [SerializeField] private Color _colorA;
    [SerializeField] private Color _colorB;
    [SerializeField] private Color _colorC;

    [Space(10)]
    [Range(0,10)]
    public int _line;

    public Image _imgA;

    /*
    por zonas
    y un manager
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_line >= 7)
        {
            _imgA.color = _colorA;
        }
        if (_line < 7 && _line >= 5)
        {
            _imgA.color = _colorB;
        }
        if (_line < 5 && _line >= 2)
        {
            _imgA.color = _colorC;
        }
    }
}
