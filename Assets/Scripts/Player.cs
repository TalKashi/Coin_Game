using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Player
{
    int m_cash;
    int m_experience;
    int m_level;
    Bucket m_bucket;
    string m_name;
    DateTime m_disconnectDate;

    public Player(string i_name, int i_initialCash)
    {
        m_name = i_name;
        m_cash = i_initialCash;
        m_experience = 0;
    }


    public Player(string i_name, int i_cash, int i_experience, Bucket i_bucket, DateTime i_disconnectDate)
    {
        m_name = i_name;
        m_cash = i_cash;
        m_experience = i_experience;
        m_bucket = i_bucket;
        m_disconnectDate = i_disconnectDate;
        //playerConnected(System.DateTime.Now);
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
        m_disconnectDate = DateTime.Now;
    }

	public void SetBucket(Bucket i_bucket)
	{
		this.m_bucket = i_bucket;
	}

	public void EmptyBucket ()
	{
		m_cash += m_bucket.EmptyBucket();
	}

	public int GetCash(){
		return m_cash;
	}

    public int GetExperience()
    {
        return m_experience;
    }

    public int GetLevel()
    {
        return m_level;
    }

    public void PlayerConnected(DateTime i_nowDate)
    {
        int deltaTime = (int)i_nowDate.Subtract(m_disconnectDate).TotalMinutes;
        m_bucket.AddMoneyToBucket(deltaTime);
    }

    private bool checkIfReachedNewLevel()
    {
        // Need to research how to decide
        // http://gamedev.stackexchange.com/questions/8965/how-to-implement-an-experience-system

        return false;
    }

   

}
