using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPoints : MonoBehaviour
{
    public static UIPoints Instance;
 

    [SerializeField] private TextMeshProUGUI _pointsText;

    public bool _counting;
    public int value;
    public int _currentPoints;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        if (UIGameOver.Instance != null)
            UIGameOver.Instance.resetAction += ResetPoints;
    }
    private void OnDisable()
    {

        UIGameOver.Instance.resetAction -= ResetPoints;
    }

    private void OnDestroy()
    {
        UIGameOver.Instance.resetAction -= ResetPoints;
    }



    void Update()
    {

        if (_counting)
        {
            StartCoroutine(RepeatCoroutine());
            _counting = false;
        }
    }

    IEnumerator RepeatCoroutine()
    {
        while (_currentPoints < value)
        {
            _currentPoints++;
            _pointsText.text = "" + _currentPoints;
            yield return new WaitForSeconds(0.02f);
        }
        while (_currentPoints > value)
        {
            _currentPoints--;
            _pointsText.text = "" + _currentPoints;
            yield return new WaitForSeconds(0.02f);
        }

        if (_currentPoints >= 300)
        {
            UIGameOver.Instance.ShowGameOver(true);
        }
    }

    public void AddPoints(int value)
    {
        _currentPoints += value;
        StartCoroutine(RepeatCoroutine());
    }
    public void SubstactPoints(int value)
    {
        _currentPoints -= value;
        StartCoroutine(RepeatCoroutine());
    }

    private void ResetPoints()
    {
        value = 0;
        _currentPoints = 0;
        _pointsText.text = "000000";
    }
}
