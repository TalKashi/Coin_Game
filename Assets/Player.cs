using UnityEngine;
using System.Collections;

public class Player
{
    int m_cash;
    int m_experience;
    Bucket m_bucket;
    string m_name;
    System.DateTime m_disconnectDate;

    public Player(string i_name, int i_initialCash)
    {
        m_name = i_name;
        m_cash = i_initialCash;
        m_experience = 0;
    }

    public Player(string i_name, int i_cash, int i_experience, Bucket i_bucket, System.DateTime i_disconnectDate)
    {
        m_name = i_name;
        m_cash = i_cash;
        m_experience = i_experience;
        m_bucket = i_bucket;
        m_disconnectDate = i_disconnectDate;
        playerConnected(System.DateTime.Now);
    }

    public void AddMoney(int i_amount)
    {
        m_cash += i_amount;
    }

    public void DecreaseMoney(int i_amount)
    {
        m_cash -= i_amount;
    }

    public bool AddExperience(int i_amount)
    {
        m_experience += i_amount;
        return checkIfReachedNewLevel();
    }

    public void OnDisconnecting()
    {
        m_disconnectDate = System.DateTime.Now;
    }

    private bool checkIfReachedNewLevel()
    {
        // Need to research how to decide

        return false;
    }

    private void playerConnected(System.DateTime i_nowDate)
    {
        int deltaTime = (int)i_nowDate.Subtract(m_disconnectDate).TotalMinutes;
        m_bucket.AddMoneyToBucket(deltaTime);
    }
}

public class Bucket
{
    System.DateTime m_lastBucketFlush;
    int m_valueForMinute;
    int m_maxAmount;
    int m_totalTimeToCollect;
    int m_currentMoneyInBucket;

    public int EmptyBucket()
    {
        int moneyToReturn = m_currentMoneyInBucket;
        m_currentMoneyInBucket = 0;
        m_lastBucketFlush = System.DateTime.Now;

        return moneyToReturn;
    }

    public void AddMoneyToBucket()
    {
        if (m_currentMoneyInBucket >= m_maxAmount)
            return;

        m_currentMoneyInBucket += m_valueForMinute;

        if (m_currentMoneyInBucket > m_maxAmount)
            m_currentMoneyInBucket = m_maxAmount;
    }

    public void AddMoneyToBucket(int i_minutes)
    {
        if (m_currentMoneyInBucket >= m_maxAmount)
            return;

        m_currentMoneyInBucket += m_valueForMinute * i_minutes;

        if (m_currentMoneyInBucket > m_maxAmount)
            m_currentMoneyInBucket = m_maxAmount;
    }
}

public class Coin
{
    int m_value;
    Player m_player;

    public Coin(int i_value, Player i_player)
    {
        m_value = i_value;
        m_player = i_player;
    }

    public void OnClickEvent()
    {
        m_player.AddMoney(m_value);
    }

    public void SetNewValue(int i_newValue)
    {
        m_value = i_newValue;
    }
}

public interface ISlot
{
    int m_minimumBetAmount;
    int m_maximumBetAmount;
    int m_numberOfSymbols;
    int m_currentBet;
    int m_increaseInterval;
    Player m_player;

    /*
     * Check at the start if going to win or not.
     * If won update the money to player and send him XP earned
     */
    public int OnSpinEvent;

    public void OnIncreaseBet;

    public void OnDecreaseBet;

    public void DisplayPayTable;

    public int GetCurrentBet;
}
