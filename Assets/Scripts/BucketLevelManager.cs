using UnityEngine;
using System.Collections;

public class BucketLevelManager : MonoBehaviour {

    public static BucketLevelManager bucketLevelManager;

	public int[] m_bucketCap;
	public int[] m_timeToFill;
	public int[] m_expectedPlayerLevel;

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
		if (m_bucketCap.Length != m_timeToFill.Length || m_expectedPlayerLevel.Length != m_timeToFill.Length )
		{
			Debug.LogError("m_bucketCap.Length != m_timeToFill.Lengt || m_expectedPlayerLevel.Length != m_timeToFill.Length ");
		}
    }


    public int GetLevelBucketCap(int i_level)
    {
		return m_bucketCap [i_level];
    }

    public int GetLevelTimeCap(int i_level)
    {
		return m_timeToFill [i_level];
    }

	public int GetExpectedPlayerLevel(int i_level)
	{
		return m_expectedPlayerLevel [i_level];
	}

	public int GetNumberOfLeveles()
	{
		return m_timeToFill.Length;
	}
}
