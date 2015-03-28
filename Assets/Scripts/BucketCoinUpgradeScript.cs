using UnityEngine;
using System.Collections;

public class BucketCoinUpgradeScript : MonoBehaviour {

    public void UpgradeBucket(int i_level)
    {
        switch (i_level)
        {
            case 1:
                GameManagerScript.GameManager.UpgradeBucket(i_level, 100, 10800);
                break;
            case 2:
                GameManagerScript.GameManager.UpgradeBucket(i_level, 200, 10800);
                break;
            case 3:
                GameManagerScript.GameManager.UpgradeBucket(i_level, 300, 10800);
                break;
        }
    }
}
