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
    Player m_player;

    public SlotPrototype(int i_minimumBetAmount, int i_maximumBetAmount, int i_numberOfSymbols,
                        int i_increaseInterval, Player i_player)
    {
        m_minimumBetAmount = i_minimumBetAmount;
        m_maximumBetAmount = i_maximumBetAmount;
        m_numberOfSymbols = i_numberOfSymbols;
        m_currentBet = m_minimumBetAmount;
        m_increaseInterval = i_increaseInterval;
        m_player = i_player;
        m_slotRacks = new int[3];
    }

    public int OnSpinEvent()
    {
        if (m_currentBet > m_player.GetCash())
        {
            Debug.Log("The bet is greater than the player cash!");
            return 0;
        }

        m_player.DecreaseMoney(m_currentBet);

        m_slotRacks[0] = Random.Range(0, m_numberOfSymbols);
        m_slotRacks[1] = Random.Range(0, m_numberOfSymbols);
        m_slotRacks[2] = Random.Range(0, m_numberOfSymbols);

        if (m_slotRacks[0] == m_slotRacks[1] && m_slotRacks[1] == m_slotRacks[2])
        {
            m_player.AddMoney(m_currentBet * 5);
        }
        m_player.AddExperience(10);
        return 1;
    }

    public void OnIncreaseBet()
    {
        if (m_currentBet == m_maximumBetAmount)
            return;

        if (m_currentBet + m_increaseInterval > m_player.GetCash())
            return;

        m_currentBet += m_increaseInterval;
        if (m_currentBet > m_maximumBetAmount)
            m_currentBet = m_maximumBetAmount;
    }

    public void OnDecreaseBet()
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
