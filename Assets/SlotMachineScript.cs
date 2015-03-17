using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotMachineScript : MonoBehaviour {

	int m_minimumBetAmount;
	int m_maximumBetAmount;
	int m_currentBet;
	int m_increaseInterval;
	public float m_megaRatio;
	public float m_spinnigTime;
	public float m_winRatio;
	public float m_superRatio;
	public GameObject m_reelManager;
	public GameObject m_payTable;
	private ReelManagerScript m_reelManagerScript;
	private PayTableScript m_payTableScript;


	public static int[] ConvertVector3ToArray(Vector3 i_vectorToConvert)
	{
		int[] result = new int[3];
		result [0] = i_vectorToConvert.x;
		result [1] = i_vectorToConvert.y;
		result [2] = i_vectorToConvert.z;

		return result;
	}

	void Awake()
	{
		m_reelManagerScript = m_reelManager.GetComponent<ReelManagerScript> ();
		m_payTableScript = m_reelManager.GetComponent<PayTableScript> ();
	}

	public IEnumerator OnSpinClick()
	{
		m_reelManagerScript.SpinAllReels ();
		Dictionary <string, System.Object> resultDict = calculateResult ();
		yield return new WaitForSeconds (m_spinnigTime);
		m_reelManagerScript.StopReels (ConvertVector3ToArray(resultDict["winVector"]));
		yield return new WaitForSeconds (1f);
		GameManagerScript.GameManager.AddMoneyToPlayer (m_currentBet * resultDict ["winMultiplier"]);

	} 


	private Dictionary <string, System.Object> calculateResult()
	{
		float randomNum = Random.Range (0f, 100f);
		if (randomNum < m_winRatio) 
		{
			//win condition
			return calculateWinResult ();
		}
		return randomLoseCondition();
	}


	private Dictionary <string, System.Object> calculateWinResult()
	{
		float randomNum = Random.Range (0f, 100f);
		if (randomNum < m_megaRatio) {
			//Mega condition
			return megaCondition ();
		} 
		else if (randomNum < m_superRatio)
		{
			//Super condition
			return superCondition();
		}
		return normalWinCondition();
	}

	private Dictionary<string, System.Object> superCondition ()
	{
		//Random
		int random = Random.Range (0, m_payTableScript.GetSuperWinList ().Count);
		
		Dictionary<string, System.Object> resultDictionary = new Dictionary<string, System.Object> ();
		resultDictionary ["winVector"] = m_payTableScript.GetVector (random);
		resultDictionary ["winMultiplier"] = m_payTableScript.GetMultiplier (random);
		resultDictionary ["winType"] = m_payTableScript.GetWinType (random);
		return resultDictionary;
	}
	
	private Dictionary <string, System.Object> megaCondition()
	{
		//Random
		int random = Random.Range (0, m_payTableScript.GetMegaWinList ().Count);

		Dictionary<string, System.Object> resultDictionary = new Dictionary<string, System.Object> ();
		resultDictionary ["winVector"] = m_payTableScript.GetVector (random);
		resultDictionary ["winMultiplier"] = m_payTableScript.GetMultiplier (random);
		resultDictionary ["winType"] = m_payTableScript.GetWinType (random);
		return resultDictionary;
	}

	private Dictionary <string, System.Object> normalWinCondition()
	{
		//Random
		int random = Random.Range (0, m_payTableScript.GetNormalWinList ().Count);
		
		Dictionary<string, System.Object> resultDictionary = new Dictionary<string, System.Object> ();
		resultDictionary ["winVector"] = m_payTableScript.GetVector (random);
		resultDictionary ["winMultiplier"] = m_payTableScript.GetMultiplier (random);
		resultDictionary ["winType"] = m_payTableScript.GetWinType (random);
		return resultDictionary;
	}

	private Dictionary <string, System.Object> randomLoseCondition()
	{
		//TEMP SOLUTION!

		Dictionary<string, System.Object> resultDictionary = new Dictionary<string, System.Object> ();
		resultDictionary ["winVector"] = new Vector3 (1, 2, 3);
		resultDictionary ["winMultiplier"] = 0;
		resultDictionary ["winType"] = WinType.Lost;
		return resultDictionary;
	}


}

	