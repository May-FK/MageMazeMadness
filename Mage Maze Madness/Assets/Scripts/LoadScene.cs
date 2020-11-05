using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
   public void Quit()
    {
        Application.Quit();
    }
}
