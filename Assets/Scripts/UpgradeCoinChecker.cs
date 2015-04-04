using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeCoinChecker : MonoBehaviour {

    public int m_minExpectedCoinLevel;
    public int m_upgradeCost;
    private Button m_button;

    void Awake()
    {
        m_button = GetComponent<Button>();
        m_button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.GameManager.GetCoinLevel() < m_minExpectedCoinLevel || GameManagerScript.GameManager.GetPlayerCash() < m_upgradeCost)
        {
            m_button.interactable = false;
        }
        else if (GameManagerScript.GameManager.GetCoinLevel() == m_minExpectedCoinLevel && GameManagerScript.GameManager.GetPlayerCash() >= m_upgradeCost)
        {
            m_button.interactable = true;
        }
        else
        {
            m_button.interactable = false;
        }
    }
}
