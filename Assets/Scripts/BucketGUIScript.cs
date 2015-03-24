using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BucketGUIScript : MonoBehaviour {

	Text m_bucketText;
	//Bucket m_bucket;

	// Use this for initialization
	void Start () {
		//m_bucket = GameManagerScript.GameManager.GetBucket ();
		m_bucketText = GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    updateText();
	}

	public void OnClickEvent()
	{
		GameManagerScript.GameManager.EmptyBucket ();
	}

    private void updateText()
    {
        TimeSpan timeLeft = GameManagerScript.GameManager.GetNextEmptyTimeSpan();
        if (timeLeft == TimeSpan.Zero)
        {
            m_bucketText.text = "EMPTY NOW!";
        }
        else
        {
            m_bucketText.text = "Next Empty: " + timeLeft.ToString().Split('.')[0];
        }
    }
}
