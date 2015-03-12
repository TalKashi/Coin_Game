using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExperienceBarScript : MonoBehaviour
{

    private Slider m_experienceSlider;
    private Text m_levelText;
    //private Player m_player;

    void Start()
    {
        m_experienceSlider = GetComponent<Slider>();
        m_levelText = GetComponentInChildren<Text>();
        //m_player = GameManagerScript.GameManager.GetPlayer();
		m_experienceSlider.minValue = GameManagerScript.GameManager.GetPlayerMinXP();
        m_experienceSlider.maxValue = GameManagerScript.GameManager.GetPlayerMaxXP();
        m_experienceSlider.value = GameManagerScript.GameManager.GetPlayerCurrentXP();
        m_levelText.text = "Level " + GameManagerScript.GameManager.GetPlayerLevel();
    }
	
	// Update is called once per frame
	void Update ()
	{
        m_experienceSlider.minValue = GameManagerScript.GameManager.GetPlayerMinXP();
        m_experienceSlider.maxValue = GameManagerScript.GameManager.GetPlayerMaxXP();
        m_experienceSlider.value = GameManagerScript.GameManager.GetPlayerCurrentXP();
        m_levelText.text = "Level " + GameManagerScript.GameManager.GetPlayerLevel();
	}
}
