using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
   public void LoadMenu ()
    {
        Debug.Log("Jeszcze raz");
        SceneManager.LoadScene("Menu-Start");
        Time.timeScale=1f;
    }
}
