using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMapManager : MonoBehaviour
{
    public static UIMapManager Instance;

    public List<UIMapArea> _areasList;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }


    public void AddLevelArea(AreaType areaType)
    {
        foreach (UIMapArea area in _areasList)
        {
            if (area.areaType == areaType)
            {
                area.SetLevel(1);
            }
        }
    }
    public void SubstractLevelArea(AreaType areaType)
    {
        foreach (UIMapArea area in _areasList)
        {
            if (area.areaType == areaType)
            {
                area.SetLevel(-1);
            }
        }
    }

    public void ResetLevelArea(AreaType areaType)
    {
        foreach (UIMapArea area in _areasList)
        {
            if (area.areaType == areaType)
            {
                area.RestLevel();
            }
        }
    }
}
