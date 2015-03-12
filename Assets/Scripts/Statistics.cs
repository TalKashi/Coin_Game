using System;

[Serializable]
public class Statistics
{
    private int m_totalBets;
    private int m_biggestWin;
    private int m_totalWins;
    private int m_recordCash;

    public void CheckAndUpdateRecordCash(int i_newCash)
    {
        if (i_newCash > m_recordCash)
            m_recordCash = i_newCash;
    }

    public void CheckAndUpdateBiggestWin(int i_newWin)
    {
        if (i_newWin > m_biggestWin)
            m_biggestWin = i_newWin;
    }

    public void IncreamentTotalWins()
    {
        m_totalWins++;
    }

    public void IncreamentTotalBets()
    {
        m_totalBets++;
    }

    public float GetWinRatio()
    {
        return (float) m_totalWins / m_totalBets;
    }
}

