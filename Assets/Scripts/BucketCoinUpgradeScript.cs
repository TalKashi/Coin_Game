using UnityEngine;
using System.Collections;

public class BucketCoinUpgradeScript : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void UpgradeBucket(int i_level)
    {
        GameManagerScript.GameManager.UpgradeBucket(i_level);
    }
}
