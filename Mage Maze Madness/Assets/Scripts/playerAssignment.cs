using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerAssignment : MonoBehaviour
{
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


    public Button Quit;

    bool tallyScore;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        tallyScore = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (SceneManager.GetActiveScene().name == "Scoreboard")
        {

            if (tallyScore == false)
            {
                sortScores();
                tallyScore = true;
            }

            Quit = GameObject.Find("Canvas/Quit").GetComponent<Button>();
            Quit.onClick.AddListener(quitButton);
        }


    }

    public void quitButton()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void sortScores()
    {
     
        P1score = GameObject.Find("Canvas/P1score").GetComponent<Text>();
        P1score.text = "";

        P2score = GameObject.Find("Canvas/P2score").GetComponent<Text>();
        P2score.text = "";

        P3score = GameObject.Find("Canvas/P3score").GetComponent<Text>();
        P3score.text = "";

        P4score = GameObject.Find("Canvas/P4score").GetComponent<Text>();
        P4score.text = "";

        P5score = GameObject.Find("Canvas/P5score").GetComponent<Text>();
        P5score.text = "";

        P6score = GameObject.Find("Canvas/P6score").GetComponent<Text>();
        P6score.text = "";

        P7score = GameObject.Find("Canvas/P7score").GetComponent<Text>();
        P7score.text = "";

        P8score = GameObject.Find("Canvas/P8score").GetComponent<Text>();
        P8score.text = "";

        var scores = new List<float>();
        if (P1score != null)
        {
            scores.Add(p1score);
        }

        if (P2score != null)
        {
            scores.Add(p2score);
        }
      
        if (P3score != null)
        {
            scores.Add(p3score);
        }

        if (P4score != null)
        {
            scores.Add(p4score);
        }

        if (P5score != null)
        {
            scores.Add(p5score);
        }

        if (P6score != null)
        {
            scores.Add(p6score);
        }

        if (P7score != null)
        {
            scores.Add(p7score);
        }

        if (P8score != null)
        {
            scores.Add(p8score);
        }

        scores.Sort();
        foreach (var x in scores)
        {
            if (P1score.text == "")
            {
                P1score.text = "1st Place Score: " + Mathf.Round(x * 100f) / 100f;
            }
            else if (P2score.text == "")
            {
                P2score.text = "2nd Place Score: " + Mathf.Round(x * 100f) / 100f;
            }
            else if (P3score.text == "")
            {
                P3score.text = "3rd Place Score: " + Mathf.Round(x * 100f) / 100f;

            }
        }
        Debug.Log("scoreboard screen");

        


    }


}
