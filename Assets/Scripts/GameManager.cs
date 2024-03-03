using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gamingCanvas;
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;

    [SerializeField] private Text _timerText;
    [SerializeField] private UnityEvent _timerOn;
    [SerializeField] private UnityEvent _timerOff;
    
    [SerializeField] private Text _pin1;
    [SerializeField] private Text _pin2;
    [SerializeField] private Text _pin3;

    [SerializeField] private sbyte[] _pinsStartValue;
    [SerializeField] private bool[]  _isToolPressed;

    private sbyte[] _currentPinsNumbers = new sbyte[3];

    private sbyte _maxPin = 10;
    private sbyte _minPin = 0;
    
    private bool isWin = false;
    private bool isLose = false;

    private void Start()
    {
        RestartGame();
    }

    private void Update()
    {
        if (_timerText.text == "-1")
        {
            isLose = true;
            _timerText.text = "0";
            WinLose();
        }
    }

    private void ToolUse(sbyte[] _currentPinsNumbers)
    {

        if (_isToolPressed[0] == true) 
        {
            _currentPinsNumbers[0] += 1;
            _currentPinsNumbers[1] -= 2;
            _currentPinsNumbers[2] -= 1;
        }
        else if (_isToolPressed[1] == true)
        {
            _currentPinsNumbers[0] -= 2;
            _currentPinsNumbers[1] += 1;
            _currentPinsNumbers[2] += 2;
        }
        else if (_isToolPressed[2] == true)
        {
            _currentPinsNumbers[0] += 1;
            _currentPinsNumbers[1] += 1;
            _currentPinsNumbers[2] -= 1;
        }

        MaxMinPins(_currentPinsNumbers);
        _pin1.text = Convert.ToString(_currentPinsNumbers[0]);
        _pin2.text = Convert.ToString(_currentPinsNumbers[1]);
        _pin3.text = Convert.ToString(_currentPinsNumbers[2]);

        if (_currentPinsNumbers[0] == _currentPinsNumbers[1] && _currentPinsNumbers[0] == _currentPinsNumbers[2])
        {
            isWin = true;
            WinLose();
        }

    }

    private void MaxMinPins(sbyte[] _currentPinsNumbers)
    {
        for(int i = 0; i < _currentPinsNumbers.Length ; i++)
        {
            if (_currentPinsNumbers[i] > _maxPin)
            {
                _currentPinsNumbers[i] = _maxPin;
            }
        }

        for (int i = 0; i < _currentPinsNumbers.Length; i++)
        {
            if (_currentPinsNumbers[i] < _minPin)
            {
                _currentPinsNumbers[i] = _minPin;
            }
        }

    }

    private void RestartGame()
    {
        isLose = false;
        isWin = false;
        
        _pin1.text = _pinsStartValue[0].ToString();
        _pin2.text = _pinsStartValue[1].ToString();
        _pin3.text = _pinsStartValue[2].ToString();

        for(int i = 0; i < _pinsStartValue.Length ; i++)
        {
            _currentPinsNumbers[i] = _pinsStartValue[i];
        }
        
    }

    private void WinLose()
    {
        if(isWin == true)
        {
            _gamingCanvas.SetActive(false);
            _winCanvas.SetActive(true);
            _timerOff.Invoke();
            RestartGame();
            isWin = false;
        }
        else if(isLose == true)
        {
            _gamingCanvas.SetActive(false);
            _loseCanvas.SetActive(true);
            _timerOff.Invoke();
            RestartGame();
            isLose = false;
        }
    }

    public void tool1()
    {
        _isToolPressed[0] = true;
        ToolUse(_currentPinsNumbers);
        _isToolPressed[0] = false;
    }

    public void tool2()
    {
        _isToolPressed[1] = true;
        ToolUse(_currentPinsNumbers);
        _isToolPressed[1] = false;
    }

    public void tool3()
    {
        _isToolPressed[2] = true;
        ToolUse(_currentPinsNumbers);
        _isToolPressed[2] = false;
    }

}
