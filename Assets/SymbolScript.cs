using UnityEngine;
using System.Collections;


public class SymbolScript : MonoBehaviour {
	
	public int m_symbol;
	public int m_value;
	public bool m_IsFeature;

	public int GetSymbol()
	{
		return m_symbol;
	}

	public int GetValue()
	{
		return m_value;
	}

	public bool IsFeature()
	{
		return m_IsFeature;
	}

	
}
