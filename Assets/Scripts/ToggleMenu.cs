using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject objectToToggle; //Assign in editor
    public KeyCode toggleKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            //Flip the object's active status
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
