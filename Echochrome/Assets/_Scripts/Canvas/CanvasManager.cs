using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    #region StaticComponent
    public static bool IsStartGeme, IsGameFlow, IsWinGame, IsLoseGame;
    public static CanvasManager Instance;
    #endregion

    [SerializeField]
    private GameObject _menuUI, _inGameUI, _wimIU, _lostUI;

    [SerializeField]
    private int _numberForVictory;
    private int _numberVictory;
    private void Awake()
    {
        IsWinGame = false;
        IsLoseGame = false;
        Instance = this;
    }
    private void Start()
    {
        if (!IsStartGeme)
        {
            _menuUI.SetActive(true);
            IsGameFlow = true;
        }
        else
        {
            IsGameFlow = true;
        }
    }

    private void Update()
    {
        if (!_inGameUI.activeSelf && IsStartGeme && IsGameFlow)
        {
            _inGameUI.SetActive(true);
        }
        //if (!_wimIU.activeSelf && IsWinGame)
        //{
        //}
        if (!_lostUI.activeSelf && IsLoseGame)
        {
            _inGameUI.SetActive(false);
            _lostUI.SetActive(true);
        }
    }

    public void BallCounter()
    {
        _numberForVictory--;
        if (_numberForVictory<=0)
        {
            IsWinGame = true;
            _inGameUI.SetActive(false);
            _wimIU.SetActive(true);
        }
    }
}
