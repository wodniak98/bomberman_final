using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("koniec nadszedł");
        Application.Quit();
    }
}
