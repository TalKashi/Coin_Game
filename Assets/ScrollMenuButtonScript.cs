using UnityEngine;
using System.Collections;

public class ScrollMenuButtonScript : MonoBehaviour {
	public GameObject m_scrollMenu;
	bool m_isActive;

	void Strat()
	{
		m_isActive = false;
	}

	public void SetScrollMenuActive()
	{
		m_isActive = !m_isActive;
		m_scrollMenu.SetActive (m_isActive);
	}

}
