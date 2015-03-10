using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExperienceBarScript : MonoBehaviour
{

    private Slider m_experienceSlider;
    private Text m_levelText;
    private Player m_player;

    void Start()
    {
        m_experienceSlider = GetComponent<Slider>();
        m_levelText = GetComponentInChildren<Text>();
        m_player = GameManagerScript.GameManager.GetPlayer();
		m_experienceSlider.minValue = m_player.GetMinXP ();
		m_experienceSlider.maxValue = m_player.GetMaxXP ();
        m_experienceSlider.value = m_player.GetExperience();
        m_levelText.text = "Level " + m_player.GetLevel();
    }
	
	// Update is called once per frame
	void Update ()
	{
	    m_experienceSlider.value = m_player.GetExperience();
		m_experienceSlider.minValue = m_player.GetMinXP ();
		m_experienceSlider.maxValue = m_player.GetMaxXP ();
		m_levelText.text = "Level " + m_player.GetLevel();
	}
}
