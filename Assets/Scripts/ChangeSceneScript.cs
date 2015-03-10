using UnityEngine;
using System.Collections;

public class ChangeSceneScript : MonoBehaviour {

    public void ChangeLevel()
    {
        GameManagerScript.GameManager.SwitchScene();    
    }
}
