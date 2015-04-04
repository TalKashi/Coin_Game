using UnityEngine;
using System.Collections;

public class BucketLevelManager : MonoBehaviour {

    public static BucketLevelManager bucketLevelManager;

    public int m_level1BucketCap = 100;
    public int m_level1TimeCap = 10800;

    public int m_level2BucketCap = 200;
    public int m_level2TimeCap = 10800;

    public int m_level3BucketCap = 300;
    public int m_level3TimeCap = 10800;

    void Awake()
    {
        if (bucketLevelManager == null)
        {
            bucketLevelManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int GetLevelBucketCap(int i_level)
    {
        switch (i_level)
        {
            case 1:
                return m_level1BucketCap;
            case 2:
                return m_level2BucketCap;
            case 3:
                return m_level3BucketCap;
            default:
                Debug.LogError("The level given (level=" + i_level + ") is not supported!");
                return -1;
        }
    }

    public int GetLevelTimeCap(int i_level)
    {
        switch (i_level)
        {
            case 1:
                return m_level1TimeCap;
            case 2:
                return m_level2TimeCap;
            case 3:
                return m_level3TimeCap;
            default:
                Debug.LogError("The level given (level=" + i_level + ") is not supported!");
                return -1;
        }
    }
}
