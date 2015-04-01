using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotMachineScript : MonoBehaviour {

	int m_minimumBetAmount;
	int m_maximumBetAmount;
	int m_currentBet = 1;
	int m_increaseInterval;
	public float m_megaRatio;
	public float m_spinnigTime;
	public float m_winRatio;
	public float m_superRatio;
	public GameObject m_reelManager;
	public GameObject m_payTable;
	private ReelManagerScript m_reelManagerScript;
	private PayTableScript m_payTableScript;

	private float m_winAmount;


	public static int[] ConvertVector3ToArray(Vector3 i_vectorToConvert)
	{
		int[] result = new int[3];
		result [0] = (int) i_vectorToConvert.x;
		result [1] = (int) i_vectorToConvert.y;
		result [2] = (int) i_vectorToConvert.z;

		return result;
	}

	void Awake()
	{
		m_reelManagerScript = m_reelManager.GetComponent<ReelManagerScript> ();
		m_payTableScript = m_payTable.GetComponent<PayTableScript> ();
		if (m_payTableScript == null) 
		{
			Debug.LogError("m_payTableScript == null");
		}
		Debug.Log ("Current seed=" + Random.seed);
	}

	void Start()
	{
		m_payTableScript.GenerateLists ();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			StartCoroutine(OnSpinClick());
		}
	}

	public IEnumerator OnSpinClick()
	{
		Debug.Log ("OnSpinClick() enter");
		StartCoroutine (m_reelManagerScript.SpinAllReels ());
		//Dictionary <string, System.Object> resultDict = calculateResult ();
	    int[] spinResult = m_reelManagerScript.GetResultVector();
        printResults(spinResult);
	    Dictionary <string, object> resultDict = m_payTableScript.Contains(spinResult);
		yield return new WaitForSeconds (m_spinnigTime);
		StartCoroutine (m_reelManagerScript.StopReels (spinResult));
		yield return new WaitForSeconds (1f);
		GameManagerScript.GameManager.AddMoneyToPlayer (m_currentBet * ((int) resultDict ["winMultiplier"]));
		Debug.Log ("OnSpinClick() exit");
	} 

	private void printResults(Dictionary<string, System.Object> i_resultDict)
	{
		Debug.Log ("winType: " + (WinType)i_resultDict ["winType"]);
		Debug.Log ("winVector: " + (Vector3)i_resultDict ["winVector"]);
		Debug.Log ("winMultiplier: " + (int)i_resultDict ["winMultiplier"]);
	}

    private void printResults(int[] i_resultVector)
    {
        string resultString = "";
        for (int i = 0; i < i_resultVector.Length; i++)
        {
            resultString += i_resultVector[i] + " --- ";
        }
        Debug.Log(resultString);
    }

	private Dictionary <string, System.Object> calculateResult()
	{
		float randomNum = Random.Range (0f, 100f);
		Debug.Log ("Current seed=" + Random.seed);
		Debug.Log ("calculateResult()| randomeNum=" + randomNum + " ; m_winRatio=" + m_winRatio);
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
			Debug.Log ("calculateWinResult()| randomeNum=" + randomNum + " ; m_megaRatio=" + m_megaRatio);
			return megaCondition ();
		} 
		else if (randomNum < m_superRatio + m_megaRatio)
		{
			//Super condition
			Debug.Log ("calculateWinResult()| randomeNum=" + randomNum + " ; m_superRatio=" +
			           (m_superRatio + m_megaRatio));
			return superCondition();
		}
		Debug.Log ("calculateWinResult()| randomeNum=" + randomNum + " ; (not super/mega)");
		return normalWinCondition();
	}

	private Dictionary<string, System.Object> superCondition ()
	{
		//Random
		ArrayList superWinList = m_payTableScript.GetSuperWinList ();
		int random = Random.Range (0, superWinList.Count);
		Debug.Log ("superCondition()| random=" + random + " ; ListCount=" + superWinList.Count);
		
		Dictionary<string, System.Object> resultDictionary = new Dictionary<string, System.Object> ();
		resultDictionary ["winVector"] = m_payTableScript.GetVector ((int) superWinList[random]);
		resultDictionary ["winMultiplier"] = m_payTableScript.GetMultiplier ((int)superWinList[random]);
		resultDictionary ["winType"] = m_payTableScript.GetWinType ((int)superWinList[random]);
		return resultDictionary;
	}
	
	private Dictionary <string, System.Object> megaCondition()
	{
		//Random
		ArrayList megaWinList = m_payTableScript.GetMegaWinList ();
		int random = Random.Range (0, megaWinList.Count);
		Debug.Log ("megaCondition()| random=" + random + " ; ListCount=" + megaWinList.Count);

		Dictionary<string, System.Object> resultDictionary = new Dictionary<string, System.Object> ();
		resultDictionary ["winVector"] = m_payTableScript.GetVector ((int)megaWinList[random]);
		resultDictionary ["winMultiplier"] = m_payTableScript.GetMultiplier ((int)megaWinList[random]);
		resultDictionary ["winType"] = m_payTableScript.GetWinType ((int)megaWinList[random]);
		return resultDictionary;
	}

	private Dictionary <string, System.Object> normalWinCondition()
	{
		//Random
		ArrayList normalWinList = m_payTableScript.GetNormalWinList ();
		int random = Random.Range (0, normalWinList.Count);
		Debug.Log ("normalWinCondition()| random=" + random + " ; ListCount=" + normalWinList.Count);
		
		Dictionary<string, System.Object> resultDictionary = new Dictionary<string, System.Object> ();
		resultDictionary ["winVector"] = m_payTableScript.GetVector ((int)normalWinList[random]);
		resultDictionary ["winMultiplier"] = m_payTableScript.GetMultiplier ((int)normalWinList[random]);
		resultDictionary ["winType"] = m_payTableScript.GetWinType ((int)normalWinList[random]);
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



	public void SetWinAmount (int i_winAmount)
	{
		m_winAmount = i_winAmount;
	}


}

	