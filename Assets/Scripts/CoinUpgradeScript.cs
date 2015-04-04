using UnityEngine;
using System.Collections;

public class CoinUpgradeScript : MonoBehaviour {

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpgradeCoin(int i_level)
    {
        GameManagerScript.GameManager.UpgradeCoin(i_level);
    }
}
