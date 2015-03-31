using UnityEngine;
using System.Collections;

public class FinalReelPositionScript : MonoBehaviour {

	public GameObject m_topSymbol;
	public GameObject m_middleSymbol;
	public GameObject m_buttomSymbol;
	private bool m_isSpinning;
	public float m_speed;

	// Use this for initialization
	void Start () {
		m_isSpinning = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)){
			m_isSpinning = false;
		}

		if (!m_isSpinning) {
			float movement = this.transform.position.y - m_speed * Time.deltaTime; 
			this.transform.position = new Vector3 (this.transform.position.x, movement, this.transform.position.z);
		} 

	}

	public void SetTopSprite(Sprite i_topSprite)
	{
		m_topSymbol.GetComponent<SpriteRenderer> ().sprite = i_topSprite;
	}

	public void SetMiddleSprite(Sprite i_middleSprite)
	{
		m_topSymbol.GetComponent<SpriteRenderer> ().sprite = i_middleSprite;
	}

	public void SetButtomSprite(Sprite i_buttomSprite)
	{
		m_topSymbol.GetComponent<SpriteRenderer> ().sprite = i_buttomSprite;
	}

	public void SetisSpinning(bool i_isSpinning){
		m_isSpinning = i_isSpinning;
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "BottomBoundrySymbolPosition") {
			SetisSpinning(true);
		}
	}

	public void ResetPosition ()
	{
		this.transform.position = new Vector3 (0f, 15f, 0f);
	}
}
