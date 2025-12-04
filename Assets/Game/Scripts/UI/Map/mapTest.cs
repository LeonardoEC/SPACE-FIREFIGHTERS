using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapTest : MonoBehaviour
{
    [SerializeField] private AreaType _area;

    public int hola;
   
    public bool addLevel;
    public bool substractLevel;

    [Space(10)]

    public bool resetLevel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (addLevel)
        {
            UIMapManager.Instance.AddLevelArea(_area);
            addLevel = false;
        }
        if (substractLevel)
        {
            UIMapManager.Instance.SubstractLevelArea(_area);
            substractLevel = false;
        }
        if (resetLevel)
        {
            UIMapManager.Instance.ResetLevelArea(_area);
            resetLevel = false;
        }
        
    }
}
