using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlotPrototype : ISlot
{
    int m_minimumBetAmount;
    int m_maximumBetAmount;
    int m_numberOfSymbols;
    int m_currentBet;
    int m_increaseInterval;
    int[] m_slotRacks;
    //Player m_player;

    public SlotPrototype(int i_minimumBetAmount, int i_maximumBetAmount, int i_numberOfSymbols,
                        int i_increaseInterval, Player i_player)
    {
        m_minimumBetAmount = i_minimumBetAmount;
        m_maximumBetAmount = i_maximumBetAmount;
        m_numberOfSymbols = i_numberOfSymbols;
        m_currentBet = m_minimumBetAmount;
        m_increaseInterval = i_increaseInterval;
        //m_player = i_player;
        m_slotRacks = new int[3];
    }

    public int OnSpinEvent()
    {
        int winAmount = 0;
        
        // Sanity check!
        if (m_currentBet > GameManagerScript.GameManager.GetPlayerCash())
        {
            Debug.Log("The bet is greater than the player cash!");
            return -1; // Maybe to notify the calling function player bet is low?
        }

        m_slotRacks[0] = Random.Range(0, m_numberOfSymbols);
        m_slotRacks[1] = Random.Range(0, m_numberOfSymbols);
        m_slotRacks[2] = Random.Range(0, m_numberOfSymbols);

        if (m_slotRacks[0] == m_slotRacks[1] && m_slotRacks[1] == m_slotRacks[2])
        {
            winAmount = m_currentBet * 5;
        }
        return winAmount;
    }

    public bool CanPlayerBet(int i_playerTotalCash)
    {
        return m_currentBet <= i_playerTotalCash;
    }

    public void OnIncreaseBet(int i_playerTotalCash)
    {
        if (m_currentBet == m_maximumBetAmount)
            return;

        if (m_currentBet + m_increaseInterval > i_playerTotalCash)
            return;

        m_currentBet += m_increaseInterval;
        if (m_currentBet > m_maximumBetAmount)
            m_currentBet = m_maximumBetAmount;
    }

    public void OnDecreaseBet(int i_playerTotalCash)
    {
        if (m_currentBet == m_minimumBetAmount)
            return;

        m_currentBet -= m_increaseInterval;
        if (m_currentBet < m_minimumBetAmount)
            m_currentBet = m_minimumBetAmount;
    }

    public void DisplayPayTable()
    {
			
        throw new NotImplementedException();
    }

    public int GetCurrentBet()
    {
        return m_currentBet;
    }

    public int[] GetSlotRackResult()
    {
        return m_slotRacks;
    }
}
