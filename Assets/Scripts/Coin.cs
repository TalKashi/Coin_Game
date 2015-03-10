using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Coin
{
    public int m_value;

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

    public void SetNewValue(int i_newValue)
    {
        m_value = i_newValue;
    }
	
}
