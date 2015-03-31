using UnityEngine;
using System.Collections;

public class BucketCoinUpgradeScript : MonoBehaviour
{

    public int m_levelOneCoinCap = 100;
    public int m_levelOneTimeCapInSeconds = 10800;

    public int m_levelTwoCoinCap = 200;
    public int m_levelTwoTimeCapInSeconds = 10800;

    public int m_levelThreeCoinCap = 300;
    public int m_levelThreeTimeCapInSeconds = 10800;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpgradeBucket(int i_level)
    {
        switch (i_level)
        {
            case 1:
                GameManagerScript.GameManager.UpgradeBucket(i_level, m_levelOneCoinCap, m_levelOneTimeCapInSeconds);
                break;
            case 2:
                GameManagerScript.GameManager.UpgradeBucket(i_level, m_levelTwoCoinCap, m_levelTwoTimeCapInSeconds);
                break;
            case 3:
                GameManagerScript.GameManager.UpgradeBucket(i_level, m_levelThreeCoinCap, m_levelThreeTimeCapInSeconds);
                break;
        }
    }
}
