using UnityEngine;
using System.Collections;

public class CoinGUIScript : MonoBehaviour {

	public void OnClickCoin()
	{
		GameManagerScript.GameManager.OnCoinClick ();
	}
}
