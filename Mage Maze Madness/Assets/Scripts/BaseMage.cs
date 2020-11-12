using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BaseMage : MonoBehaviour
{

    public GameObject Player;
    //Looking up how to make an array of materials so the mages can change looks

    //these are the variables that all players will use.


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


}




