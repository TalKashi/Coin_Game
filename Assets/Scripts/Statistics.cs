using System;

[Serializable]
public class Statistics
{
    private int m_totalBets;
    private int m_biggestWin;
    private int m_totalWins;
    private int m_recordCash;
    private int m_totalClicksOnCoin;
    private int m_totalMoneyWonFromSlots;
    private int m_totalMoneyEarnedFromCoin;
    private int m_totalMoneyEarnedFromBucket;

    public void CheckAndUpdateRecordCash(int i_newCash)
    {
        if (i_newCash > m_recordCash)
            m_recordCash = i_newCash;
    }

    private void CheckAndUpdateBiggestWin(int i_winAmount)
    {
        if (i_winAmount > m_biggestWin)
            m_biggestWin = i_winAmount;
    }

    public void IncreamentTotalWins()
    {
        m_totalWins++;
    }

    public void IncreamentTotalBets()
    {
        m_totalBets++;
    }

    public void IncreamentTotalClicksOnCoin()
    {
        m_totalClicksOnCoin++;
    }

    public float GetWinRatio()
    {
        return (float) m_totalWins / m_totalBets;
    }

    public void UpdateMoneyWonFromSlots(int i_winAmount)
    {
        m_totalMoneyWonFromSlots += i_winAmount;
        CheckAndUpdateBiggestWin(i_winAmount);
    }

    public void UpdateMoneyEarnedFromCoin(int i_amount)
    {
        m_totalMoneyEarnedFromCoin += i_amount;
    }

    public void UpdateMoneyEarnedFromBucket(int i_amount)
    {
        m_totalMoneyEarnedFromBucket += i_amount;
    }

    public override string ToString()
    {
        return String.Format("Total Bets: {0}\nTotal Wins: {1}\nWin Ratio: {2}\nBiggest Win: {3}\nRecord Cash: {4}\nTotal Clicks On Coin: {5}\nTotal Money Won From Slots: {6}\n" +
                             "Total Money Earned From Coin: {7}\nTotal Money Earned From Bucket: {8}",
            m_totalBets, m_totalWins, GetWinRatio(), m_biggestWin, m_recordCash, m_totalClicksOnCoin, m_totalMoneyWonFromSlots, m_totalMoneyEarnedFromCoin, m_totalMoneyEarnedFromBucket);
    }
}

