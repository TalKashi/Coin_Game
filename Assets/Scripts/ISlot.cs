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
    /*
     * Check at the start if going to win or not.
     * If won update the money to player and send him XP earned
     */
	int OnSpinEvent();

	void OnIncreaseBet();

    void OnDecreaseBet();

    void DisplayPayTable();

    int GetCurrentBet();

    int[] GetSlotRackResult();
}
