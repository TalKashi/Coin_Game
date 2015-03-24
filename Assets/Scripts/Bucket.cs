﻿using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Bucket
{
    DateTime m_lastBucketFlush;
    float m_valueForSecond;
    int m_maxAmount;
    float m_currentMoneyInBucket;
    private bool m_isFull;

	public Bucket(int i_maxAmount,int i_totalTimeToCollectInSeconds)
    {
        m_valueForSecond = (float) i_maxAmount / i_totalTimeToCollectInSeconds;
		m_maxAmount = i_maxAmount;
		m_currentMoneyInBucket = 0;
	    m_isFull = false;
    }

    public int EmptyBucket()
    {
        // Can only empty bucket if the bucket is full
        if (!m_isFull)
        {
            Debug.Log("Bucket is not full. Can't empty yet");
            return 0;
        }

        int moneyToReturn = (int) m_currentMoneyInBucket;
        Debug.Log("moneyToReturn=" + moneyToReturn + ";m_currentMoneyInBucket=" + m_currentMoneyInBucket);
        m_currentMoneyInBucket = 0;
        m_lastBucketFlush = DateTime.Now;
        m_isFull = false;

        Debug.Log("Emptying bucket. Returning " + moneyToReturn + " coins.");
        return moneyToReturn;
    }

    public void AddMoneyToBucket(float i_deltaTime)
    {
        //Debug.Log("Adding money to bucket of " + i_deltaTime + " seconds");
        if (m_isFull)
        {
            Debug.Log("Can't add more money to bucket. Bucket is full!");
            return;
        }

        m_currentMoneyInBucket += m_valueForSecond * i_deltaTime;

        if (m_currentMoneyInBucket > m_maxAmount)
        {
            m_currentMoneyInBucket = m_maxAmount;
            m_isFull = true;
            Debug.Log("Bucket is full! (" + m_currentMoneyInBucket + ")");
        }
            

        //Debug.Log("New value in bucket: " + m_currentMoneyInBucket);
    }

	public int GetMoneyInBucket ()
	{
		return (int) m_currentMoneyInBucket;
	}

    public TimeSpan GetTimeUntilBucketIsFull()
    {
        // The formula
        float moneyLeftToFill = m_maxAmount - m_currentMoneyInBucket;
        float timeLeftInSeconds = moneyLeftToFill * (1 / m_valueForSecond);

        return TimeSpan.FromSeconds(timeLeftInSeconds);
    }
}
