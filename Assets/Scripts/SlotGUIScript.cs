using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlotGUIScript : MonoBehaviour
{
    //private ISlot m_slot;
    private Text m_currentBetText;
    private Text m_rackDisplayText;
    //private int[] m_slotRackResult;

    void Start()
    {
        //m_slot = GameManagerScript.GameManager.GetSlot();
        //m_slotRackResult = GameManagerScript.GameManager.GetSlotRackResult();
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
        string rackDisplay = "";
        m_currentBetText.text = "Bet: " + GameManagerScript.GameManager.GetCurrentBet();
        for (int i = 0; i < GameManagerScript.GameManager.GetSlotRackResult().Length; i++)
        {
            rackDisplay += GameManagerScript.GameManager.GetSlotRackResult()[i];
            if (GameManagerScript.GameManager.GetSlotRackResult().Length - 1 > i)
                rackDisplay += " -- ";
        }
        m_rackDisplayText.text = rackDisplay;
    }

    public void OnSpinClick()
    {
        GameManagerScript.GameManager.OnSpinEvent();
    }

    public void OnIncreaseBetClick()
    {
        GameManagerScript.GameManager.OnIncreaseBet();
    }

    public void OnDecreaseBetClick()
    {
        GameManagerScript.GameManager.OnDecreaseBet();
    }


}
