using UnityEngine;
using System.Collections;

public class ToggleActiveScript : MonoBehaviour {

    public void ToggleActive(GameObject i_gameObject)
    {
        i_gameObject.SetActive(!i_gameObject.activeSelf);
    }
}
