using UnityEngine;
using System.Collections;

public class SlotGameObjectScript : MonoBehaviour {

	public int m_chancesToWin;
	public GameObject m_reel;
	private GameObject m_firstReel;
	private GameObject m_secondReel;
	private GameObject m_thirdReel;
	private Animator m_firstReelAnimator;
	private Animator m_secondReelAnimator;
	private Animator m_thirdReelAnimator;
	public float m_timeReelsToSpin;
	float m_timeBetweenReels;
	int m_winAmount;

	private Vector3[] m_loseConditions = {
		new Vector3 (0, 0, 1),new Vector3 (0, 2, 0),new Vector3 (0, 2, 1),new Vector3 (0, 2, 2),
		new Vector3 (1, 0, 0),new Vector3 (1, 0, 1),new Vector3 (1, 0, 2),new Vector3 (1, 1, 0),
		new Vector3 (1, 1, 2),new Vector3 (1, 2, 0),new Vector3 (1, 2, 1),new Vector3 (1, 2, 2),
		new Vector3 (2, 0, 0),new Vector3 (2, 0, 1),new Vector3 (2, 0, 2),new Vector3 (2, 1, 0),
		new Vector3 (2, 1, 1),new Vector3 (2, 2, 0),new Vector3 (2, 2, 1)};

	// Use this for initialization
	void Start () {
		createReels ();
		m_firstReelAnimator = m_firstReel.gameObject.GetComponent<Animator> ();
		m_secondReelAnimator = m_secondReel.gameObject.GetComponent<Animator> ();
		m_thirdReelAnimator = m_thirdReel.gameObject.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void StartSpinnigAnimation(float i_timeReelsToSpin)
	{
		StartCoroutine(startSpinnigReels(i_timeReelsToSpin ));
	}

	IEnumerator startSpinnigReels(float i_timeReelsToSpin )
	{
		m_firstReelAnimator.SetBool ("Spinnig", true);
		m_secondReelAnimator.SetBool ("Spinnig", true);
		m_thirdReelAnimator.SetBool ("Spinnig", true);
		yield return new WaitForSeconds(m_timeReelsToSpin);
		DisplayResult (m_winAmount > 0);
		m_firstReelAnimator.SetBool ("Spinnig", false);
		m_secondReelAnimator.SetBool ("Spinnig", false);
		m_thirdReelAnimator.SetBool ("Spinnig", false);
	}


	public void DisplayResult(bool i_isWin)
	{

		if (i_isWin) {
			int winSymbol = Random.Range (0, 3);
			m_firstReelAnimator.SetInteger ("Symbol", winSymbol);
			m_secondReelAnimator.SetInteger ("Symbol", winSymbol);
			m_thirdReelAnimator.SetInteger ("Symbol", winSymbol);
		} else {
			Vector3 loseConditionSymbols = m_loseConditions [Random.Range (0, m_loseConditions.Length)];
			m_firstReelAnimator.SetInteger ("Symbol", (int)loseConditionSymbols.x);
			m_secondReelAnimator.SetInteger ("Symbol", (int)loseConditionSymbols.y);
			m_thirdReelAnimator.SetInteger ("Symbol", (int)loseConditionSymbols.z);


		}
	}

	public void SetWinAmount (int i_winAmount)
	{
		m_winAmount = i_winAmount;
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
