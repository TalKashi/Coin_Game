using UnityEngine;
using System.Collections;

public class ReelScript : MonoBehaviour {

	public GameObject[] m_Symbols;
    public int[] m_ReelVector;
	public GameObject m_reelAnimation;
	private ReelAnimationScript m_reelAnimationScript;
	private int m_currentVectorIndex;

	void Awake()
	{
		m_reelAnimationScript = GetComponentInChildren<ReelAnimationScript> ();
	}

	void Start() 
	{
		m_currentVectorIndex = Random.Range (0, m_ReelVector.Length);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Y))
		{
			StartSpinnig();
		}
		if(Input.GetKeyDown(KeyCode.U))
		{
			StopSpinnig();
		}
	}

	public int GetNumberOfSymbols()
	{
		return m_Symbols.Length;
	}

	public void StartSpinnig(){
		m_reelAnimationScript.StartSpinning ();
	}

	public void StopSpinnigOnSymbol (int i_symbol)
	{
		// TODO: stop animation
	}

    public void StopSpinnig()
    {
        m_reelAnimationScript.StopSpinning(m_currentVectorIndex);
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
		m_currentVectorIndex = Random.Range(0, m_ReelVector.Length);
		return m_currentVectorIndex;
    }

	public SymbolScript GetSymbolScript(int i_symbol){
		return m_Symbols [i_symbol].GetComponent<SymbolScript> ();
	}

	public int[] GetReelVector ()
	{
		return m_ReelVector;
	}
}
