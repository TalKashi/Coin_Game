using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Coin
{
    private int m_value;
    private int m_level;

    public Coin(int i_value)
    {
		Debug.Log ("Constructor i_value: " + i_value);
        m_value = i_value;
		Debug.Log ("Constructor m_value: " + m_value);

    }

    public void OnClickEvent()
    {
		Debug.Log ("m_amount in COIN = " + m_value);
		GameManagerScript.GameManager.AddMoneyToPlayer (m_value);
    }

    public void SetNewValue(int i_newValue, int i_newLevel)
    {
        m_value = i_newValue;
        m_level = i_newLevel;
        Debug.Log("Coin new value: " + m_value + " and new level: " + m_level);
    }

    public int GetValue()
    {
        return m_value;
    }

    public int GetLevel()
    {
        return m_level;
    }
	
}
