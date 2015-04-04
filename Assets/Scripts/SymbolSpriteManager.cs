using UnityEngine;
using System.Collections;

public class SymbolSpriteManager : MonoBehaviour {
	public static SymbolSpriteManager symbolSpriteManager;

	void Awake()
	{
		if (symbolSpriteManager == null) {
			symbolSpriteManager = this;
		} 
		else if (symbolSpriteManager != this) 
		{
			Destroy(this.gameObject);
		}

	}

	public Sprite[] m_symbolSprites;
	// Use this for initialization

	public Sprite GetSprite(int i)
	{
		return m_symbolSprites [i];
	}
}
