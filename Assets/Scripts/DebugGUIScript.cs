using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugGUIScript : MonoBehaviour
{
    private Text m_text;

	// Use this for initialization
	void Start ()
	{
	    m_text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        m_text.text = string.Format("Bucket Money: {0}\n" +
                                    "Bucket Level: {1}\n" +
                                    "Bucket Value/sec: {2}\n" +
                                    "Bucket Max Amount: {3}\n" +
                                    "Bucket isFull: {4}\n", GameManagerScript.GameManager.GetMoneyInBucketForDebug(), GameManagerScript.GameManager.GetBucketLevel(),
                                    GameManagerScript.GameManager.GetBucketValuePerSec(), GameManagerScript.GameManager.GetBucketMaxAmount(), GameManagerScript.GameManager.IsBucketFull());
	}
}
