using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text instructions;
    public Text winloseText;
    public GameObject winlosePanel;
    public Text buttonText;
    public Text scoreText;
    int score = 0;

    private void Start()//если нет ключа то записываем 10 
    {
        if(!PlayerPrefs.HasKey("MineNum"))
        {
            PlayerPrefs.SetInt("MineNum", 10);
        }          
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void HideInstructions()
    {
        instructions.gameObject.SetActive(false);
    }

    public void Win()
    {
        PlayerPrefs.SetInt("MineNum", PlayerPrefs.GetInt("MineNum") + 20);
        winlosePanel.SetActive(true);
        winloseText.text = " Ты победил! ";
        winloseText.color = Color.green;
        buttonText.text = "Следующий уровень";
    }

    public void Lose()
    {
        PlayerPrefs.SetInt("MineNum", 10);
        winlosePanel.SetActive(true);
        winloseText.text = " Ты проиграл! ";
        winloseText.color = Color.red;
        buttonText.text = "Начать заново";
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
}
