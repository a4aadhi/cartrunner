using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
       public void PlayerButtonPressed(){
        SceneManager.LoadScene(1);
    }
    public void ExitButtonPressed(){
        Application.Quit();
        Debug.Log("exit button pressed");
    }
    public void RestartButtonPressed(){
        SceneManager.LoadScene(1);
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
       {
           
       }
    }
   
        
    
}
