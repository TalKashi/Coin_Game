using UnityEngine;
using System.Collections;

public class AnimationReelScript : MonoBehaviour {

	public void ChangeToSymbol(int i_symbol)
	{
		this.gameObject.GetComponent<Animator> ().SetInteger ("StopOnSymbol", i_symbol);
	}
}
