using UnityEngine;
using System.Collections;

//public enum SymbolEnum{Symbol_1,Symbol_2,Symbol_3};

public class SymbolScript : MonoBehaviour {
	
	public int m_symbol;
	public int m_value;
	public bool m_IsFeature;
	public float m_WinRatio;

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
