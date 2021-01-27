using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStateManage : MonoBehaviour
{
    private int deadPlayers = 0;
    private int deadPlayerNumber = -1;
    public GameObject EndMenu;
    public GameObject Win1;
    public GameObject Win2;
    public GameObject Win3;



    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerDied(int playerNumber)
    {
        deadPlayers++; // 1

        if (deadPlayers == 1)
        { // 2
            deadPlayerNumber = playerNumber; // 3
            Invoke("CheckPlayersDeath", .3f); // 4
        }
    }
    void CheckPlayersDeath()
    {
        // 1
        if (deadPlayers == 1)
        {
            // 2
            if (deadPlayerNumber == 1)
            {
                Debug.Log("Player 2 is the winner!");
                Win2.SetActive(true);
                // 3
            }
            else
            {
                Debug.Log("Player 1 is the winner!");
                Win1.SetActive(true);
            }
            // 4
        }
        else
        {
            Debug.Log("The game ended in a draw!");
            Win3.SetActive(true);
        }
        Time.timeScale = 0f;
        EndMenu.SetActive(true);

    }
    // A single player died and he's the loser.
    //Player 1 died so Player 2 is the winner.
    //Player 2 died so Player 1 is the winner.
    //Both players died, so it's a draw.
    
    

}

