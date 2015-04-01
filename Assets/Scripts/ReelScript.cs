using UnityEngine;
using System.Collections;

public class ReelScript : MonoBehaviour {

	public GameObject[] m_Symbols;
    public int[] m_ReelVector;
	public GameObject m_reelAnimation;
	public GameObject m_finalReelPosition;
	private ReelAnimationScript m_reelAnimationScript;
	private int m_currentVectorIndex;
	private FinalReelPositionScript m_finalReelPositionScript;


	void Awake()
	{
		m_reelAnimationScript = GetComponentInChildren<ReelAnimationScript> ();
		m_finalReelPositionScript = m_finalReelPosition.GetComponent<FinalReelPositionScript> ();
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
		m_finalReelPositionScript.ResetPosition ();
		m_reelAnimationScript.StartSpinning ();
	}

	public void StopSpinnigOnSymbol (int i_symbol)
	{
		// TODO: stop animation
	}

    public void StopSpinnig()
    {
		Debug.Log ("m_finalReelPositionScript.SetMiddleSprite (m_symbolsSprites [m_currentVectorIndex]);");
		m_finalReelPositionScript.SetMiddleSprite (SymbolSpriteManager.symbolSpriteManager.GetSprite (m_currentVectorIndex));
        m_reelAnimationScript.StopSpinning(m_currentVectorIndex);
		m_finalReelPositionScript.SetisSpinning (false);

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
		//Set picture
		m_finalReelPositionScript.SetMiddleSprite(SymbolSpriteManager.symbolSpriteManager.GetSprite (m_currentVectorIndex));
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
