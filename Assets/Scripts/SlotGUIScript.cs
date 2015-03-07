using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlotGUIScript : MonoBehaviour
{
    private ISlot m_slot;
    private Text m_currentBetText;
    private Text m_rackDisplayText;
    private int[] m_slotRackResult;

    void Start()
    {
        m_slot = GameManagerScript.GameManager.GetSlot();
        m_slotRackResult = m_slot.GetSlotRackResult();
        Text[] textsArray = GetComponentsInChildren<Text>();
        for (int i = 0; i < textsArray.Length; i++)
        {
            switch (textsArray[i].tag)
            {
                case "RackDisplay":
                    m_rackDisplayText = textsArray[i];
                    break;
                case "BetDisplay":
                    m_currentBetText = textsArray[i];
                    break;
            }
            Debug.Log(textsArray[i].tag);
        }
    }

    void Update()
    {
        if(m_slot == null)
            Start();
        string rackDisplay = "";
        m_currentBetText.text = "Bet: " + m_slot.GetCurrentBet();
        for (int i = 0; i < m_slotRackResult.Length; i++)
        {
            rackDisplay += m_slotRackResult[i];
            if (m_slotRackResult.Length - 1 > i)
                rackDisplay += " -- ";
        }
        m_rackDisplayText.text = rackDisplay;
    }

    public void OnSpinClick()
    {
        m_slot.OnSpinEvent();
    }

    public void OnIncreaseBetClick()
    {
        m_slot.OnIncreaseBet();
    }

    public void OnDecreaseBetClick()
    {
        m_slot.OnDecreaseBet();
    }
}
