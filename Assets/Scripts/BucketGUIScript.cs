using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BucketGUIScript : MonoBehaviour {

	Text m_bucketText;
    private Image m_image;
    public Sprite[] m_BucketSprites;

	// Use this for initialization
	void Start ()
	{
        m_image = GetComponent<Image>();
        if (m_image == null)
	    {
            Debug.LogError("m_image is NULL!");
	    }
		m_bucketText = GetComponentInChildren<Text> ();
        if (m_bucketText == null)
        {
            Debug.LogError("m_bucketText is NULL!");
        }
        if (GameManagerScript.GameManager.GetBucketLevel() == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            SetSpriteByLevel(GameManagerScript.GameManager.GetBucketLevel());
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    updateText();
	}

	public void OnClickEvent()
	{
		GameManagerScript.GameManager.EmptyBucket ();
	}

    public void SetSpriteByLevel(int i_level)
    {
        if (i_level < 1)
        {
            Debug.LogError("SetSpriteByLevel parametar must be 1 or greater! Exiting method");
            return;
        }
        m_image.sprite = m_BucketSprites[i_level - 1];
    }

    private void updateText()
    {
        TimeSpan timeLeft = GameManagerScript.GameManager.GetNextEmptyTimeSpan();
        if (timeLeft == TimeSpan.Zero)
        {
            m_bucketText.text = "EMPTY NOW!";
        }
        else if(timeLeft == TimeSpan.MaxValue)
        {
            m_bucketText.text = "You Should Upgrade Your Bucket!";
        }
        else
        {
            m_bucketText.text = "Next Empty: " + timeLeft.ToString().Split('.')[0];
        }
    }
}
