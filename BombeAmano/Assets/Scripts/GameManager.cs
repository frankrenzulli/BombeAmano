using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3;
    public GameObject winLossScreen;
    public TextMeshProUGUI winlossText;
    

    public void player1Hit()
    {
        playerLives--;
    }

    public void isGameOver()
    {
        if(playerLives <= 0)
        {
            winLossScreen.SetActive(true);
            winlossText.text = "Hai Perso!";
            Time.timeScale = 0f;
        }
    }

    public void Win()
    {
        winLossScreen.SetActive(true);
        winlossText.text = "Hai Vinto!!";
        Time.timeScale= 0f;
    }

}