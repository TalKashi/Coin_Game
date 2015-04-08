using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DisbaleButtonsManagerScript : MonoBehaviour {

    public static DisbaleButtonsManagerScript DisbaleButtonsManager;

    public List<Button> m_buttonsList;

    void Awake()
    {
        if (DisbaleButtonsManager == null)
        {
            DisbaleButtonsManager = this;
            
        }
        else if (DisbaleButtonsManager != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetButtonsActive(bool i_setActive)
    {
        foreach (Button button in m_buttonsList)
        {
            button.interactable = i_setActive;
        }
    }
}
