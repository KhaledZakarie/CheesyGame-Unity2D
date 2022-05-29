using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCode : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void OnePlayer()
    {
        SceneManager.LoadScene(1);
    }
    public void MultiPlayer()
    {
        SceneManager.LoadScene(2);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Help()
    {
        SceneManager.LoadScene(5);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
