using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenu : MonoBehaviour
{
    [SerializeField] private GameObject _fullLifeState;
    [SerializeField] private GameObject _partialLifeState;
    [SerializeField] private GameObject _noLifeState;

    
    private void Update()
    {
        ChangeState();
    }

    private void ChangeState()
    {
        switch (LivesController.LivesState)
        {
            
            case State.PartialLives:
                _fullLifeState.SetActive(false);
                _partialLifeState.SetActive(true);
                _noLifeState.SetActive(false);
                break;
            case State.NoLives:
                _fullLifeState.SetActive(false);
                _partialLifeState.SetActive(false);
                _noLifeState.SetActive(true);
                break;
            default:
            {
                _fullLifeState.SetActive(true);
                _partialLifeState.SetActive(false);
                _noLifeState.SetActive(false);
                break;
            }
        }
    }
}
