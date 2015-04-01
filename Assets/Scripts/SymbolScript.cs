using UnityEngine;
using System.Collections;


public class SymbolScript : MonoBehaviour {


	public int m_symbol;
	public int m_vectorIndex;
	private SpriteRenderer m_spriteRenderer;
	public GameObject m_topPosition;
	public Sprite[] m_symbolsSprites;
	private int m_stopPosition;
	public bool m_isStopPressed;
	float m_buttomPositionY;


	private ReelAnimationScript m_reelAnimationScript;

	void Awake()
	{
		m_buttomPositionY = GameObject.FindGameObjectWithTag ("BottomBoundry").transform.position.y;
		m_spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		m_reelAnimationScript = GetComponentInParent<ReelAnimationScript> ();
	}


	void Update()
	{
		if (m_buttomPositionY > this.transform.position.y) {
			this.transform.position = m_topPosition.transform.position;
			m_symbol = m_reelAnimationScript.GetNextIndexValueOfVector (m_vectorIndex);
			m_vectorIndex = m_reelAnimationScript.GetNextIndexOfVector (m_vectorIndex);
			m_spriteRenderer.sprite = m_symbolsSprites [m_symbol];

		}

		if (m_reelAnimationScript.m_isSpinning && !m_reelAnimationScript.m_isStopPressed) {
			//temp solution, need to hide fake reel
			m_spriteRenderer.color = new Vector4(m_spriteRenderer.color.r,m_spriteRenderer.color.b,m_spriteRenderer.color.g,255f);
			float movement = this.transform.position.y - m_reelAnimationScript.GetSpeed (); 
			this.transform.position = new Vector3 (this.transform.position.x, movement, this.transform.position.z);
		} else if (!m_reelAnimationScript.m_isSpinning && m_reelAnimationScript.m_isStopPressed) {
			m_spriteRenderer.color = new Vector4(m_spriteRenderer.color.r,m_spriteRenderer.color.b,m_spriteRenderer.color.g,0f);
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		/*
		if (other.tag == "BottomBoundry" && m_reelAnimationScript.m_isSpinning) {
			this.transform.position = m_topPosition.transform.position;
			m_symbol = m_reelAnimationScript.GetNextIndexValueOfVector (m_vectorIndex);
			m_vectorIndex = m_reelAnimationScript.GetNextIndexOfVector (m_vectorIndex);
			m_spriteRenderer.sprite = m_symbolsSprites [m_symbol];
		}
		*/
	}

		/*
		else if (other.tag == "VerifyStopContidion")
		{
			Debug.Log (other.tag);
			Debug.Log(!m_reelAnimationScript.m_isSpinning + " && " + m_reelAnimationScript.GetStopPosition() + "==" + m_vectorIndex);
			if (!m_reelAnimationScript.m_isSpinning && m_reelAnimationScript.GetStopPosition () == m_vectorIndex)
			{

				m_reelAnimationScript.StartSlowingDownAnimation();
			}
		} else if (!m_reelAnimationScript.m_isSpinning && m_reelAnimationScript.GetStopPosition () == m_vectorIndex && 
			other.tag == "FinalPosition")
		{
			m_reelAnimationScript.StopAnimation();
		}


	}
	*/
	public int GetSymbol()
	{
		return m_symbol;
	}

	public void SetStopPosition(int i_stopPosition)
	{
		m_stopPosition = i_stopPosition;
	}
	

}
