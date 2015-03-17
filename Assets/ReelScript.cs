using UnityEngine;
using System.Collections;

public class ReelScript : MonoBehaviour {

	public GameObject[] m_Symbols;
	private int m_numOfFeatures = -1;

	private Vector3[] loseConditions = {
		new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),
		new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),
		new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),
		new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),
		new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3),new Vector3 (1, 2, 3)};

	public int GetNumberOfSymbols()
	{
		return m_Symbols.Length;
	}

	public void StartSpinnig(){
		// TODO:
	}

	public void StopSpinnigOnSymbol (int i_symbol)
	{
		// TODO: stop animation
	}

	public int GetNumberOfFeature()
	{
		if (m_numOfFeatures == -1) {
			m_numOfFeatures = 0;
			foreach (GameObject symbol in m_Symbols) {
				if (symbol.GetComponent<SymbolScript> ().IsFeature()) {
					m_numOfFeatures++;
				}
			}
		}
		return m_numOfFeatures;
	}

	public ArrayList GetSymbols()
	{
		ArrayList symbols = new ArrayList ();
		foreach (GameObject symbol in m_Symbols) 
		{
			symbols.Add(symbol.GetComponent<SymbolScript> ().GetSymbol()); 
		}
		return symbols;
	}



	public SymbolScript GetSymbolScript(int i_symbol){
		return m_Symbols [i_symbol].GetComponent<SymbolScript> ();
	}

}
