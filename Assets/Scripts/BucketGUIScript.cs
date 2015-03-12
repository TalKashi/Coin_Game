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
		m_bucketText.text = "Bucket: " + GameManagerScript.GameManager.GetMoneyInBucket() + "$";
	}

	public void OnClickEvent()
	{
		GameManagerScript.GameManager.EmptyBucket ();
	}
}
