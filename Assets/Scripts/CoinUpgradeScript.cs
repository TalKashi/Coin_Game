using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class CoinUpgradeScript : MonoBehaviour
{

    public GameObject CoinUpgradeButton;

    void Awake()
    {
        gameObject.SetActive(false);        
    }

    void Start()
    {
        init();
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
            newButton.transform.SetParent(transform);
            Button onClickButton = newButton.GetComponent<Button>();
            int parameterForButton = i;
            onClickButton.onClick.AddListener(() => UpgradeCoin(parameterForButton));
            newButton.SetActive(true);
        }
        
    }

}
