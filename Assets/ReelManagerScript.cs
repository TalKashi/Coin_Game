using UnityEngine;
using System.Collections;

public class ReelManagerScript : MonoBehaviour {

	public GameObject[] m_reels;
	public float m_WinRatio;
	private ReelScript[] m_reelScripts;
	public float m_delayBetweenSpins;



	void Awake()
	{
		m_reelScripts = new ReelScript[m_reels.Length];
		for (int i = 0 ; i < m_reels.Length;  i++) {
			m_reelScripts[i] = m_reels [i].GetComponent<ReelScript> ();
		}
	}

	public void SpinReel(int i_reelIndex)
	{
		m_reelScripts[i_reelIndex].StartSpinnig ();
	}

	public void StopReelOnSymbol(int i_reelIndex,int i_symbol)
	{
		m_reelScripts[i_reelIndex].StopSpinnigOnSymbol(i_symbol);
	}


	public IEnumerator SpinAllReels(){
		Debug.Log ("Spinning");
		for (int i = 0; i < m_reelScripts.Length; i++) 
		{
			SpinReel(i);
			yield return new WaitForSeconds(m_delayBetweenSpins);
		}
	}

	public IEnumerator StopReels(int[] i_symbols){
		if (i_symbols.Length != m_reels.Length) 
		{
			Debug.LogError("i_symbols.Length != m_reels.Length");
		}
		Debug.Log ("Stop Spinning");
		for (int i = 0; i < m_reelScripts.Length; i++) 
		{
			StopReelOnSymbol(i,i_symbols[i]);
			yield return new WaitForSeconds(m_delayBetweenSpins);
		}
	}

	void generateWinConditionList()
	{
		for (int i = 0; i < m_reelScripts.Length; i++) 
		{
			//m_reelScripts[i].GetSymbolScript;
		}


	}


}
