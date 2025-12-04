using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    public static UIGameOver Instance;


    [SerializeField] private GameObject _panel;

    [SerializeField] private TextMeshProUGUI _npcText;
    [SerializeField] private TextMeshProUGUI _fireText;
    [SerializeField] private TextMeshProUGUI _pointsText;

    private int _npcPoints;
    private int _firePoints;
    private int _finalPoints;

    public bool pruebaDelegado;

    public delegate void ResetDelegate();
    public ResetDelegate resetAction;


    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        resetAction += ResetUIData;
    }
    private void OnDisable()
    {
        resetAction -= ResetUIData;
    }

    private void Start()
    {
        ShowGameOver(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_panel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }

        if (pruebaDelegado)
        {
            ResetGame();
            pruebaDelegado = false;

        }
    }

    public void NpcPoints(int value)
    {
        _npcPoints = value;
        _npcText.text = "" + _npcPoints;
    }
    public void FirePoints(int value)
    {
        _firePoints = value;
        _fireText.text = "" + _firePoints;
    }
    public void FinalPoints(int value)
    {
        _finalPoints = value;
        _pointsText.text = "" + _finalPoints;
    }

    public void ResetGame()
    {
        resetAction?.Invoke();
    }

    public void ShowGameOver(bool value)
    {
        _panel.SetActive(value);
    }

    private void ResetUIData()
    {
        _npcPoints = 0;
        _npcText.text = "";
        _firePoints = 0;
        _fireText.text = "";
        _finalPoints = 0;
        _pointsText.text = "";

        ShowGameOver(false);
    }

}
