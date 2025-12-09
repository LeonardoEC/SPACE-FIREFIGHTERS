using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMapManager : MonoBehaviour
{
    public static UIMapManager Instance;

    public List<UIMapArea> _areasList;

    public int _currentLevel;
    public int _mapLevel;

    private UIMapArea _currentArea;
    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (_currentLevel > _mapLevel)
        {
            if (!_currentArea)
            {
                _currentArea = GetArea(AreaType.Reactor);
            }
            _currentArea.SetLevelPorcentage(_currentLevel);
        }


    }

    public UIMapArea GetArea(AreaType areaType)
    {
        foreach (UIMapArea area in _areasList)
        {
            if (area.areaType == areaType)
            {
                return area;
            }
        }
        return null;
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
