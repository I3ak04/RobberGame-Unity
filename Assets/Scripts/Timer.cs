using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    [SerializeField] private Text _textOfTimer;
    [SerializeField] private sbyte _startTimerValue;
    
    private bool isTimerStart = false;
    private float _timeCounting;

    private void Start()
    {
        _textOfTimer.text = _timeCounting.ToString();
    }

    private void Update()
    {
        if (isTimerStart == true)
        {
            _timeCounting -= Time.deltaTime;
            _textOfTimer.text = Math.Round(_timeCounting).ToString();
        }
    }

    public void timerOn()
    {
        isTimerStart = true;
        _timeCounting = _startTimerValue;
    }
    
    public void timerOff()
    {
        isTimerStart = false;
    }

}
