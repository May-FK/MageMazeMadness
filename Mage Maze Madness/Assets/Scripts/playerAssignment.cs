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

        var scores = new List<float>();
        scores.Add(p1score);
        scores.Add(p2score);
        scores.Add(p3score);
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

    }


}
