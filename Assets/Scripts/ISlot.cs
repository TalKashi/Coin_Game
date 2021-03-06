﻿using UnityEngine;
using System.Collections;

public interface ISlot
{
	/*
    int m_minimumBetAmount;
    int m_maximumBetAmount;
    int m_numberOfSymbols;
    int m_currentBet;
    int m_increaseInterval;
    Player m_player;
    */
    
	int OnSpinEvent();

    bool CanPlayerBet(int i_playerTotalCash);

    void OnIncreaseBet(int i_playerTotalCash);

    void OnDecreaseBet(int i_playerTotalCash);

    void DisplayPayTable();

    int GetCurrentBet();

    int[] GetSlotRackResult();

	void SetChancesToWin(int i_chancesToWin);


}
