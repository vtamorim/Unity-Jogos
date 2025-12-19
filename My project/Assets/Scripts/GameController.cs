using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public int totalScore;
    public TextMeshProUGUI scoreText;

    public GameObject gameover;

    public static GameController instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ShowGameOver()
    {
        gameover.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
       SceneManager.LoadScene(lvlName);
    }
}
