using UnityEngine;
using System.Collections;

public class ReelAnimationScript : MonoBehaviour {

	public float m_defaultSpeed;
	private int[] m_ReelVector;
	public float m_speed;
	public bool m_isSpinning = false;
	public int m_stopPosition;

	void  Start()
	{
		m_ReelVector = GetComponentInParent<ReelScript>().GetReelVector();

	}

	public int GetNextIndexValueOfVector (int i_vectorIndex)
	{
		return m_ReelVector[(i_vectorIndex+ 1) % m_ReelVector.Length];
	}

	public int GetNextIndexOfVector (int i_vectorIndex)
	{
		return (i_vectorIndex+ 1) % m_ReelVector.Length;
	}

	public void StopSpinning(int i_stopIndex)
	{
		m_isSpinning = false;
		m_stopPosition = i_stopIndex;
	}
	
	public void StartSpinning()
	{
		m_isSpinning = true;
		m_speed = m_defaultSpeed;
	}

	public float GetSpeed()
	{
		return m_speed;
	}

	public int GetStopPosition ()
	{
		return m_stopPosition;
	}

	public void StartSlowingDownAnimation ()
	{
		//Room for emprovment
		m_speed = 25;
	}

	public void StopAnimation ()
	{
		m_speed = 0;
	}	


}
