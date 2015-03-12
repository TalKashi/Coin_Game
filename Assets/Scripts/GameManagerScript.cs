﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManagerScript : MonoBehaviour
{

    public static GameManagerScript GameManager;

	Player m_player;
	Bucket m_bucket;
	Coin m_coin;
    ISlot m_slot;
	float m_startTime;
	string m_currentScene;

    void Awake()
    {
        if (GameManager == null)
        {
            GameManager = this;
            DontDestroyOnLoad(gameObject);
			Load();
			m_slot = new SlotPrototype(5, 50, 3, 5, m_player);
        }
        else if(GameManager != this)
        {
            Destroy(gameObject);
        }
		

    }

	// Use this for initialization
	void Start ()
	{
        m_startTime = Time.time;
		m_currentScene = Application.loadedLevelName;
	}
	
	// Update is called once per frame
	void Update () {
		//Press on coin
		if(Input.GetKeyDown(KeyCode.A))
		{
			print("Add coin with value of: " + m_coin.m_value);
			m_coin.OnClickEvent();
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
		    m_player.AddExperience(10);
		}

		if (Time.time - m_startTime >= 30f)
		{
			print ("Adding money to bucket");
			m_bucket.AddMoneyToBucket();
			m_startTime = Time.time;
		}
	}

    void OnDisable()
    {
		if (this == GameManager) 
		{
			m_player.OnDisconnecting ();
			Save ();     
		}
    }

    public void Save()
    {
        Debug.Log("SAVING FILES");
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/bucket.dat");
        binaryFormatter.Serialize(file, m_bucket);
        file.Close();

        file = File.Create(Application.persistentDataPath + "/player.dat");
        binaryFormatter.Serialize(file, m_player);
        file.Close();

        file = File.Create(Application.persistentDataPath + "/coin.dat");
        binaryFormatter.Serialize(file, m_coin);
        file.Close();
    }

    public void Load()
    {
        Debug.Log("LOADING FILES");
        Debug.Log("path: " + Application.persistentDataPath);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (File.Exists (Application.persistentDataPath + "/bucket.dat")) {
			FileStream file = File.OpenRead (Application.persistentDataPath + "/bucket.dat");
			m_bucket = (Bucket)binaryFormatter.Deserialize (file);
			file.Close ();
			Debug.Log ("Loaded Bucket");
		} 
		else
		{
			m_bucket = new Bucket (20, 1000, 60, 0);
			Debug.Log("Created new instance of bucket!");
		}


        if (File.Exists (Application.persistentDataPath + "/player.dat")) {
			FileStream file = File.OpenRead (Application.persistentDataPath + "/player.dat");
			m_player = (Player)binaryFormatter.Deserialize (file);
			file.Close ();
			Debug.Log ("Loaded Player");
			m_player.PlayerConnected(System.DateTime.Now);
		} 
		else
		{
			m_player = new Player("Serge", 10000);
			Debug.Log("Created new instance of player!");
		}

        if (File.Exists (Application.persistentDataPath + "/coin.dat")) {
			FileStream file = File.OpenRead (Application.persistentDataPath + "/coin.dat");
			m_coin = (Coin)binaryFormatter.Deserialize (file);
			file.Close ();
			Debug.Log ("Loaded Coin");
		} 
		else
		{
			m_coin = new Coin(1);
			Debug.Log("Created new instance of coin!");
		}

    }

    #region Player Control

    //public Player GetPlayer()
    //{
    //    return m_player;
    //}

    public int GetPlayerCash()
    {
        return m_player.GetCash();
    }

    public int GetPlayerMaxXP()
    {
        return m_player.GetMaxXP();
    }

    public int GetPlayerMinXP()
    {
        return m_player.GetMinXP();
    }

    public int GetPlayerCurrentXP()
    {
        return m_player.GetExperience();
    }

    public int GetPlayerLevel()
    {
        return m_player.GetLevel();
    }

    public void AddMoneyToPlayer(int i_amount)
    {
        m_player.AddMoney(i_amount);
    }

    #endregion Player Control

    #region Coin Control

    public void OnCoinClick()
    {
        m_coin.OnClickEvent();
    }

    #endregion Coin Control

    #region Bucket Control

    //public Bucket GetBucket()
    //{
    //    return m_bucket;
    //}

    public void AddMoneyToBucket(int i_deltaTime)
	{
		m_bucket.AddMoneyToBucket (i_deltaTime);
	}

	public void EmptyBucket()
	{
		m_player.AddMoney (m_bucket.EmptyBucket ());
	}

    public int GetMoneyInBucket()
    {
        return m_bucket.GetMoneyInBucket();
    }

    #endregion Bucket Control

    #region Slot Control

    //public ISlot GetSlot()
    //{
    //    return m_slot;
    //}

    public int[] GetSlotRackResult()
    {
        return m_slot.GetSlotRackResult();
    }

    public int GetCurrentBet()
    {
        return m_slot.GetCurrentBet();
    }

    public void OnSpinEvent()
    {
        m_slot.OnSpinEvent();
    }

    public void OnIncreaseBet()
    {
        m_slot.OnIncreaseBet();
    }

    public void OnDecreaseBet()
    {
        m_slot.OnDecreaseBet();
    }

    #endregion Slot Control

    public void SwitchScene(){
		string nextScene = getNextScene (m_currentScene);
		Application.LoadLevel (nextScene);
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

	private string getNextScene(string i_scene)
	{
		if (i_scene == "Coin_Kashi") {
			m_currentScene = "Slot_Kashi";
		} 
		else 
		{
			m_currentScene = "Coin_Kashi";
		}

		return m_currentScene;
	}
}
