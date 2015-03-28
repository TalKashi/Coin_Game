using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeBucketChecker : MonoBehaviour
{

    public int m_minExpectedBucketLevel;
    public int m_minExpectedPlayerLevel;
    private Button m_button;

    void Awake()
    {
        m_button = GetComponent<Button>();
        m_button.interactable = false;
    }

	// Update is called once per frame
	void Update ()
    {
	    if (GameManagerScript.GameManager.GetBucketLevel() < m_minExpectedBucketLevel || GameManagerScript.GameManager.GetPlayerLevel() < m_minExpectedPlayerLevel)
	    {
	        m_button.interactable = false;
	    }
        else if (GameManagerScript.GameManager.GetBucketLevel() == m_minExpectedBucketLevel && GameManagerScript.GameManager.GetPlayerLevel() >= m_minExpectedPlayerLevel)
	    {
            m_button.interactable = true;
	    }
        else
        {
            m_button.interactable = false;
        }
	}
}
