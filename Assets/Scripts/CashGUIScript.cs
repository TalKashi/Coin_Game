﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashGUIScript : MonoBehaviour
{
    //Player m_player;
    Text m_cashText;

	// Use this for initialization
	void Start ()
	{
	    m_cashText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    m_cashText.text = GameManagerScript.GameManager.GetPlayerCash() + "$";
	}
}
