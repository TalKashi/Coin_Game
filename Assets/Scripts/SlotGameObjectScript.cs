using UnityEngine;
using System.Collections;

public class SlotGameObjectScript : MonoBehaviour {

	public int m_chancesToWin;
	public GameObject m_reel;
	private GameObject m_firstReel;
	private GameObject m_secondReel;
	private GameObject m_thirdReel;
	public float m_timeReelsToSpin;
	float m_timeBetweenReels;

	private Vector3[] m_loseConditions = {
		new Vector3 (0, 0, 1),new Vector3 (0, 2, 0),new Vector3 (0, 2, 1),new Vector3 (0, 2, 2),
		new Vector3 (1, 0, 0),new Vector3 (1, 0, 1),new Vector3 (1, 0, 2),new Vector3 (1, 1, 0),
		new Vector3 (1, 1, 2),new Vector3 (1, 2, 0),new Vector3 (1, 2, 1),new Vector3 (1, 2, 2),
		new Vector3 (2, 0, 0),new Vector3 (2, 0, 1),new Vector3 (2, 0, 2),new Vector3 (2, 1, 0),
		new Vector3 (2, 1, 1),new Vector3 (2, 2, 0),new Vector3 (2, 2, 1)};

	// Use this for initialization
	void Start () {
		createReels ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSpinEvent()
	{
		int randomNumber = Random.Range (0, 100);
		StartCoroutine(startSpinnigReels ());
		displayResult (randomNumber <= m_chancesToWin);
	}

	IEnumerator startSpinnigReels()
	{
		m_firstReel.gameObject.GetComponent<Animator> ().SetBool ("Spinnig", true);
		m_secondReel.gameObject.GetComponent<Animator> ().SetBool ("Spinnig", true);
		m_thirdReel.gameObject.GetComponent<Animator> ().SetBool ("Spinnig", true);
		yield return new WaitForSeconds(m_timeReelsToSpin);
		m_firstReel.gameObject.GetComponent<Animator> ().SetBool ("Spinnig", false);
		m_secondReel.gameObject.GetComponent<Animator> ().SetBool ("Spinnig", false);
		m_thirdReel.gameObject.GetComponent<Animator> ().SetBool ("Spinnig", false);
	}


	private void displayResult(bool i_isWin)
	{

		if (i_isWin) {
			int winSymbol = Random.Range (0, 2);
			m_firstReel.gameObject.GetComponent<Animator> ().SetInteger ("Symbol", winSymbol);
			m_secondReel.gameObject.GetComponent<Animator> ().SetInteger ("Symbol", winSymbol);
			m_thirdReel.gameObject.GetComponent<Animator> ().SetInteger ("Symbol", winSymbol);
		} else 
		{
			Vector3 loseConditionSymbols = m_loseConditions[Random.Range(0,m_loseConditions.Length)];
			m_firstReel.gameObject.GetComponent<Animator> ().SetInteger ("Symbol", (int) loseConditionSymbols.x);
			m_secondReel.gameObject.GetComponent<Animator> ().SetInteger ("Symbol", (int)loseConditionSymbols.y);
			m_thirdReel.gameObject.GetComponent<Animator> ().SetInteger ("Symbol", (int)loseConditionSymbols.z);

		}
	}






	//Create 3 reels
	private void createReels()
	{
		Vector3 reelFirstPosition = new Vector3 (this.transform.position.x - 2f, this.transform.position.y, this.transform.position.z);
		Vector3 reelSecondPosition = this.transform.position;
		Vector3 reelThirdPosition = new Vector3 (this.transform.position.x + 2f, this.transform.position.y, this.transform.position.z);
		
		
		//Create 3 reels
		m_firstReel = Instantiate (m_reel, reelFirstPosition, Quaternion.identity) as GameObject;
		m_secondReel = Instantiate (m_reel, reelSecondPosition, Quaternion.identity) as GameObject;
		m_thirdReel = Instantiate (m_reel, reelThirdPosition, Quaternion.identity) as GameObject;
	}
}
