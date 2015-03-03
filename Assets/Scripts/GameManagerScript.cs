﻿using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	Player m_player;
	Bucket m_bucket;
	Coin m_coin;
	float m_startTime;

	// Use this for initialization
	void Start () {
		m_player = new Player ("Serge", 10000);
		m_bucket = new Bucket(10,1000,10,0);
		m_player.SetBucket (m_bucket);
		m_coin = new Coin (1, m_player);
		m_startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//Press on coin
		if(Input.GetKeyDown(KeyCode.A))
		{
			print("Add coin");
			m_coin.OnClickEvent();
		}
		//Empty bucket
		if(Input.GetKeyDown(KeyCode.S))
		{
			print("Empty Bucket");
			m_player.EmptyBucket();
		}
		//Print balance
		if(Input.GetKeyDown(KeyCode.D))
		{
			print("The amounth of money you have is: "+m_player.GetCash());
		}
		//
		if(Input.GetKeyDown(KeyCode.Z))
		{
			print("Spin");
			playSlotMachine();
		}

		if (Time.time - m_startTime >= 60f)
		{
			print ("Adding money to bucket");
			m_bucket.AddMoneyToBucket();
			m_startTime = Time.time;
		}
	}


	private void playSlotMachine()
	{
		int num1 = Random.Range (1, 4);
		int num2 = Random.Range (1, 4);
		int num3 = Random.Range (1, 4);
		print (num1 + "-----" + num2 + "------" + num3);
		m_player.DecreaseMoney (20);
		if (num1 == num2 && num1 == num3) 
		{
			print("Great Win");
			m_player.AddMoney(100);
		}
	}
}
