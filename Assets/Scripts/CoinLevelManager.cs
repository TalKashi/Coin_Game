using UnityEngine;
using System.Collections;

public class CoinLevelManager : MonoBehaviour
{

    public static CoinLevelManager coinLevelManager;

    public int m_levelOneCoinValue = 2;
    public int m_levelOneUpgradeCost = 100;

    public int m_levelTwoCoinValue = 3;
    public int m_levelTwoUpgradeCost = 200;

    public int m_levelThreeCoinValue = 4;
    public int m_levelThreeUpgradeCost = 300;

    void Awake()
    {
        if (coinLevelManager == null)
        {
            coinLevelManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int GetLevelValue(int i_level)
    {
        switch (i_level)
        {
            case 1:
                return m_levelOneCoinValue;
            case 2:
                return m_levelTwoCoinValue;
            case 3:
                return m_levelThreeCoinValue;
            default:
                Debug.LogError("The level given (level=" + i_level + ") is not supported!");
                return -1;
        }
    }

    public int GetLevelCost(int i_level)
    {
        switch (i_level)
        {
            case 1:
                return m_levelOneUpgradeCost;
            case 2:
                return m_levelTwoUpgradeCost;
            case 3:
                return m_levelThreeUpgradeCost;
            default:
                Debug.LogError("The level given (level=" + i_level + ") is not supported!");
                return -1;
        }
    }
}
