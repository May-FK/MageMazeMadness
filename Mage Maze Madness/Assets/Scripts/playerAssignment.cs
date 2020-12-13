using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAssignment : MonoBehaviour
{

    public GameObject p1;
    public float p1score;

    public GameObject p2;
    public float p2score;

    public GameObject p3;
    public float p3score;

    void Start()
    {

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



    }
}
