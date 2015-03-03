using UnityEngine;
using System.Collections;

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
