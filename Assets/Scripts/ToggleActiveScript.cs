using UnityEngine;
using System.Collections;

public class ToggleActiveScript : MonoBehaviour {

    public void ToggleActive(GameObject i_gameObject)
    {
        Debug.Log("before: !i_gameObject.activeSelf = " + !i_gameObject.activeSelf);
        i_gameObject.SetActive(!i_gameObject.activeSelf);
        Debug.Log("after: !i_gameObject.activeSelf = " + !i_gameObject.activeSelf);
    }
}
