using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class CoinUpgradeScript : MonoBehaviour
{

    public GameObject CoinUpgradeButton;
    public GameObject PanelObject;

    void Start()
    {
        init();
		gameObject.SetActive(false);
    }

    public void UpgradeCoin(int i_level)
    {
        GameManagerScript.GameManager.UpgradeCoin(i_level);
    }

    private void init()
    {
        for (int i = 0; i < CoinLevelManager.coinLevelManager.GetNumberOfLevels(); i++)
        {
            GameObject newButton = Instantiate(CoinUpgradeButton);
            UpgradeCoinChecker newButtonScript = newButton.GetComponent<UpgradeCoinChecker>();
            newButtonScript.m_minExpectedCoinLevel = i;
            newButtonScript.m_upgradeCost = CoinLevelManager.coinLevelManager.GetLevelCost(i);
            newButton.transform.SetParent(PanelObject.transform);
            Button onClickButton = newButton.GetComponent<Button>();
            int parameterForButton = i;
            onClickButton.onClick.AddListener(() => UpgradeCoin(parameterForButton));
            newButton.SetActive(true);
        }
        
    }

}
