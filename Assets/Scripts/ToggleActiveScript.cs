using UnityEngine;
using System.Collections;

public class ToggleActiveScript : MonoBehaviour {
	public GameObject m_coinMenu;
	public GameObject m_bucketMenu;

    public void ToggleActive(GameObject i_gameObject)
    {
        Debug.Log("before: !i_gameObject.activeSelf = " + !i_gameObject.activeSelf);
        i_gameObject.SetActive(!i_gameObject.activeSelf);
        Debug.Log("after: !i_gameObject.activeSelf = " + !i_gameObject.activeSelf);
    }

	public void ToggleCoin() 
	{
		m_bucketMenu.SetActive (false);
		m_coinMenu.SetActive (!m_coinMenu.activeSelf);
	}

	public void ToggleBucket() 
	{
		m_coinMenu.SetActive (false);
		m_bucketMenu.SetActive (!m_bucketMenu.activeSelf);
	}
}
