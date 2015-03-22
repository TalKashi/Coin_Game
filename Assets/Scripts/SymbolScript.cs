using UnityEngine;
using System.Collections;


public class SymbolScript : MonoBehaviour {


	public int m_symbol;
	public int m_vectorIndex;
	private SpriteRenderer m_spriteRenderer;
	public GameObject m_topPosition;
	public Sprite[] m_symbolsSprites;
	private int m_stopPosition;

	private ReelAnimationScript m_reelAnimationScript;

	void Awake()
	{
		m_spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		m_reelAnimationScript = GetComponentInParent<ReelAnimationScript> ();
	}


	void Update()
	{
		//if (m_isSpinning) 
		//{
			float movement = this.transform.position.y - m_reelAnimationScript.GetSpeed()*Time.deltaTime; 
			this.transform.position = new Vector3(this.transform.position.x, movement,this.transform.position.z);
		//}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "BottomBoundry") {
			this.transform.position = m_topPosition.transform.position;
			m_symbol = m_reelAnimationScript.GetNextIndexValueOfVector (m_vectorIndex);
			m_vectorIndex = m_reelAnimationScript.GetNextIndexOfVector (m_vectorIndex);
			m_spriteRenderer.sprite = m_symbolsSprites [m_symbol];
		} 
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

	public int GetSymbol()
	{
		return m_symbol;
	}

	public void SetStopPosition(int i_stopPosition)
	{
		m_stopPosition = i_stopPosition;
	}
	

}
