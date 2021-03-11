using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    
    [SerializeField] private int _maxLives;
    [SerializeField] private float _maxTime;
    
    public float CurrentTime { get; private set; }
    public bool IsTimerOn { get; private set; }
    public int Lives { get; private set; }
    public static State LivesState { get; private set; }
    
    private void Start()
    {
        CurrentTime = _maxTime;
        Lives = _maxLives;
        IsTimerOn = false;
        
        UIController.OnRefillLivesClick += StopTimer;
        UIController.OnRefillLivesClick += RefillLives;
        UIController.OnUseLifeClick += UseLife;
    }
    private void Update()
    {
        StateUpdate();
        Countdowm();
        if (Lives < _maxLives)
            StartTimer();
    }

    private void OnDisable()
    {
        UIController.OnRefillLivesClick -= StopTimer;
        UIController.OnRefillLivesClick -= RefillLives;
        UIController.OnUseLifeClick -= UseLife;
    }

    private void AddLife()
    {
        if (Lives >= _maxLives) return;
        Lives++;
    }
    
    private void RefillLives()
    {
        if (Lives >= _maxLives) return;
        Lives = _maxLives;
    }
    
    private void UseLife()
    {
        if (Lives <= 0) return;
        Lives--;
    }
    
    private void StateUpdate()
    {
        if (Lives >= _maxLives)
        {
            LivesState = State.FullLives;
        }
        else if (Lives < _maxLives && Lives > 0)
        {
            LivesState = State.PartialLives;
        }
        else
        {
            LivesState = State.NoLives;
        }
    }
    
    private void StartTimer()
    {
        if (!IsTimerOn)
            StartCoroutine(Clock());
    }
    
    private void StopTimer()
    {
        IsTimerOn = false;
        CurrentTime = _maxTime;
    }
    
    private IEnumerator Clock()
    {
        CurrentTime = _maxTime;
        IsTimerOn = true;
        while(IsTimerOn && CurrentTime > 0)
        {
            yield return new WaitForSeconds(1);
        }
        IsTimerOn = false;
        AddLife();
    }
    
    private void Countdowm()
    {
        if (IsTimerOn && CurrentTime > 0)
            CurrentTime -= Time.deltaTime;
    }
}
