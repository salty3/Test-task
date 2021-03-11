using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private LivesController _livesController;
    [SerializeField] private string _labelIfLivesFull = "Full";
    [SerializeField] private UILabel[] _lifeLabelsArray;
    [SerializeField] private UILabel[] _timerLabelsArray;
    
    public static Action OnUseLifeClick;
    public static Action OnRefillLivesClick;

    private void Start()
    {
        UpdateLifeLabels();
        UpdateTimerLabels();
    }

    private void Update()
    {
        UpdateLifeLabels();
        UpdateTimerLabels();
    }

    public void UseLife()
    {
        OnUseLifeClick?.Invoke();
    }
    
    public void RefillLives()
    {
        OnRefillLivesClick?.Invoke();
    }

    private void UpdateLifeLabels()
    {
        foreach (var label in _lifeLabelsArray)
        {
            label.text = _livesController.Lives.ToString();
        }
    }
    
    private void UpdateTimerLabels()
    {
        TimeSpan time = TimeSpan.FromSeconds(_livesController.CurrentTime);
        foreach (var label in _timerLabelsArray)
        {
            label.text = _livesController.IsTimerOn ? time.ToString(@"mm\:ss") : _labelIfLivesFull;
        }
    }

}
