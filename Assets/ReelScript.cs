using UnityEngine;
using System.Collections;

public class ReelScript : MonoBehaviour {

	public GameObject[] m_Symbols;
    public int[] m_ReelVector;
	private int m_numOfFeatures = -1;

	public int GetNumberOfSymbols()
	{
		return m_Symbols.Length;
	}

	public void StartSpinnig(){
		// TODO: start animation
	}

	public void StopSpinnigOnSymbol (int i_symbol)
	{
		// TODO: stop animation
	}

    public void StopSpinnigOnIndex(int i_vectorIndex)
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

    public int GetRandomReelPosition()
    {
        return Random.Range(0, m_ReelVector.Length);
    }

	public SymbolScript GetSymbolScript(int i_symbol){
		return m_Symbols [i_symbol].GetComponent<SymbolScript> ();
	}

}
