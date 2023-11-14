using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{

    public TMP_Text livesText;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "HP:" + player.hitPoints;
    }

    //Quits the Game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Loads the first scene
    public void SwitchScene()
    {
        SceneManager.LoadScene(0);
    }





}
