using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int player1Lives = 3;

    

    public void player1Hit()
    {
        player1Lives--;
    }

    public void isGameOver()
    {
        if(player1Lives <= 0)
        {
            Debug.Log("Player 1 vince");
        }
    }


}