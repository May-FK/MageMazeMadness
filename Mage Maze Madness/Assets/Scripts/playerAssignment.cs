using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerAssignment : MonoBehaviour
{
    #region Player Objects
    public GameObject p1;
    public float p1score;
    public Text P1score;

    public GameObject p2;
    public float p2score;
    public Text P2score;

    public GameObject p3;
    public float p3score;
    public Text P3score;

    public GameObject p4;
    public float p4score;
    public Text P4score;

    public GameObject p5;
    public float p5score;
    public Text P5score;

    public GameObject p6;
    public float p6score;
    public Text P6score;

    public GameObject p7;
    public float p7score;
    public Text P7score;

    public GameObject p8;
    public float p8score;
    public Text P8score;
    #endregion

    public Button Quit;




    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Getting Time in Game

        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        p3 = GameObject.Find("Player3");
        p4 = GameObject.Find("Player4");
        p5 = GameObject.Find("Player5");
        p6 = GameObject.Find("Player6");
        p7 = GameObject.Find("Player7");
        p8 = GameObject.Find("Player8");


        if (p1 != null)
        {
            p1score = p1.GetComponentInChildren<theHunter>().timeTagged;
        } 

        if (p2 != null)
        {
            p2score = p2.GetComponentInChildren<theHunter>().timeTagged;
        }

        if (p3 != null)
        {
            p3score = p3.GetComponentInChildren<theHunter>().timeTagged;
        }

        if (p4 != null)
        {
            p4score = p4.GetComponentInChildren<theHunter>().timeTagged;
        }

        if (p5 != null)
        {
            p5score = p5.GetComponentInChildren<theHunter>().timeTagged;
        }

        if (p6 != null)
        {
            p6score = p6.GetComponentInChildren<theHunter>().timeTagged;
        }

        if (p7 != null)
        {
            p7score = p7.GetComponentInChildren<theHunter>().timeTagged;
        }

        if (p8 != null)
        {
            p8score = p8.GetComponentInChildren<theHunter>().timeTagged;
        }

        #endregion

        if (SceneManager.GetActiveScene().name == "Scoreboard")
        {
            
            P1score = GameObject.Find("Canvas/P1score").GetComponent<Text>();
            P1score.text = "Player 1 Score: " + p1score;

            P2score = GameObject.Find("Canvas/P2score").GetComponent<Text>();
            P2score.text = "Player 2 Score: " + p2score;

            P3score = GameObject.Find("Canvas/P3score").GetComponent<Text>();
            P3score.text = "Player 3 Score: " + p3score;

            P4score = GameObject.Find("Canvas/P4score").GetComponent<Text>();
            P4score.text = "Player 4 Score: " + p4score;

            P5score = GameObject.Find("Canvas/P5score").GetComponent<Text>();
            P5score.text = "Player 5 Score: " + p5score;

            P5score = GameObject.Find("Canvas/P5score").GetComponent<Text>();
            P5score.text = "Player 5 Score: " + p5score;

            P6score = GameObject.Find("Canvas/P6score").GetComponent<Text>();
            P6score.text = "Player 6 Score: " + p6score;

            P7score = GameObject.Find("Canvas/P7score").GetComponent<Text>();
            P7score.text = "Player 7 Score: " + p7score;

            P8score = GameObject.Find("Canvas/P8score").GetComponent<Text>();
            P8score.text = "Player 8 Score: " + p8score;


            Debug.Log("Scoreboard");


            Quit = GameObject.Find("Canvas/Quit").GetComponent<Button>();
            Quit.onClick.AddListener(quitButton);
        }

        
    }

    public void quitButton()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
