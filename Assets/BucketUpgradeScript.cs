using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class BucketUpgradeScript : MonoBehaviour
{
	
	public GameObject BucketUpgradeButton;
    public GameObject PanelObject;
	
	void Start()
	{
		init();
		gameObject.SetActive(false);
	}
	
	public void UpgradeBucket(int i_level)
	{
		GameManagerScript.GameManager.UpgradeBucket(i_level);
	}
	
	private void init()
	{
		for (int i = 0; i < BucketLevelManager.bucketLevelManager.GetNumberOfLeveles(); i++)
		{
			GameObject newButton = Instantiate(BucketUpgradeButton);
			UpgradeBucketChecker newButtonScript = newButton.GetComponent<UpgradeBucketChecker>();
			newButtonScript.m_minExpectedBucketLevel = i;
			newButtonScript.m_minExpectedPlayerLevel = BucketLevelManager.bucketLevelManager.GetExpectedPlayerLevel(i);
            newButton.transform.SetParent(PanelObject.transform);
			Button onClickButton = newButton.GetComponent<Button>();
			int parameterForButton = i + 1;
			onClickButton.onClick.AddListener(() => UpgradeBucket(parameterForButton));
			newButton.SetActive(true);
		}
		
	}
	
}
