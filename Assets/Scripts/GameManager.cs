using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int gold;
    public int round;

    public Text GoldText;
    public Text LivesText;
    public GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        gold = 500;
        lives = 20;
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = gold.ToString();
        LivesText.text = lives.ToString();

    }

    
}
