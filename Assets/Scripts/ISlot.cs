using UnityEngine;
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

	void OnIncreaseBet();

    void OnDecreaseBet();

    void DisplayPayTable();

    int GetCurrentBet();

    int[] GetSlotRackResult();
}
