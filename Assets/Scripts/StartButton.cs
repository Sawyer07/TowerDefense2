using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //MUST be included or can't use SceneManager...

public class StartButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
