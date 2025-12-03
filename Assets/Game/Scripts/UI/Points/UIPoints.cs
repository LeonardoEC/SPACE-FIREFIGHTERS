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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
