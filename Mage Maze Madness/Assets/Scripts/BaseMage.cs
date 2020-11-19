using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BaseMage : MonoBehaviour
{
    //these are the variables that all players will use.
    public GameObject Player;


    #region CharacterSelect
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FireMageSelector")
        {
            Debug.Log("Fire Mage Chosen.");
            other.gameObject.SetActive(false);
            Player.GetComponent<fireMage>().isFireMage = true;
            Player.GetComponent<Renderer>().material = FireRed;
            Player.GetComponent<theHunter>().isTheHunter = false;
        }

        if (other.gameObject.name == "HunterMageSelector")
        {
            Debug.Log("You are the Hunter.");
            other.gameObject.SetActive(false);
            Player.GetComponent<theHunter>().isTheHunter = true;
            Player.GetComponent<Renderer>().material = HunterBlack;
            Player.GetComponent<fireMage>().isFireMage = false;

        }*/
    #endregion
    //We only need this if we want to do a physical character select instead of a UI Character Select.

    //tbh this script is kinda useless. I was learning about inheritance in class and wanted to try it out.
}




