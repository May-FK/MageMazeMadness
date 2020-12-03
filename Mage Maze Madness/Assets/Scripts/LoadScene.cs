using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadScene : MonoBehaviour
{
    public GameObject cyc;
    public GameObject Fire;
    public GameObject Wind;
    public GameObject Lightning;
    public GameObject Title;
    public GameObject Play;
    public GameObject quit;
    public GameObject Back;
    public GameObject Volume;
    public GameObject VolumeTitle;
    public GameObject BackBtn;
    public GameObject Settings;
    public GameObject Hunter;
    public GameObject FireText;
    public GameObject WindText;
    public GameObject LightText;
    public GameObject HunterText;
    public GameObject TipText;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        cyc.SetActive(false);
        Fire.SetActive(false);
        Wind.SetActive(false);
        Lightning.SetActive(false);
        Back.SetActive(false);
        Title.SetActive(true);
        Play.SetActive(true);
        quit.SetActive(true);
        Settings.SetActive(true);
        Volume.SetActive(false);
        VolumeTitle.SetActive(false);
        BackBtn.SetActive(false);
        Hunter.SetActive(false);
        FireText.SetActive(false);
        WindText.SetActive(false);
        LightText.SetActive(false);
        HunterText.SetActive(false);
        TipText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        cyc.SetActive(true);
        Fire.SetActive(true);
        Wind.SetActive(true);
        Lightning.SetActive(true);
        Back.SetActive(true);
        Title.SetActive(false);
        Play.SetActive(false);
        quit.SetActive(false);
        Settings.SetActive(false);
        Volume.SetActive(false);
        VolumeTitle.SetActive(false);
        BackBtn.SetActive(false);
        Hunter.SetActive(true);
        FireText.SetActive(true);
        WindText.SetActive(true);
        LightText.SetActive(true);
        HunterText.SetActive(true);
        TipText.SetActive(true);

    }
    public void Click()
    {
        SceneManager.LoadScene("Level 1");
        Cursor.visible = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
   public void Quit()
    {
        Application.Quit();
    }
    public void GoBack()
    {
        cyc.SetActive(false);
        Fire.SetActive(false);
        Wind.SetActive(false);
        Lightning.SetActive(false);
        Back.SetActive(false);
        Title.SetActive(true);
        Play.SetActive(true);
        quit.SetActive(true);
        Settings.SetActive(true);
        Volume.SetActive(false);
        VolumeTitle.SetActive(false);
        BackBtn.SetActive(false);
        Hunter.SetActive(false);
        FireText.SetActive(false);
        WindText.SetActive(false);
        LightText.SetActive(false);
        HunterText.SetActive(false);
        TipText.SetActive(false);
    }
    public void SettingsClicked()
    {
        cyc.SetActive(false);
        Fire.SetActive(false);
        Wind.SetActive(false);
        Lightning.SetActive(false);
        Back.SetActive(false);
        Title.SetActive(false);
        Play.SetActive(false);
        quit.SetActive(false);
        Settings.SetActive(false);
        Volume.SetActive(true);
        VolumeTitle.SetActive(true);
        BackBtn.SetActive(true);
        Hunter.SetActive(false);
        FireText.SetActive(false);
        WindText.SetActive(false);
        LightText.SetActive(false);
        HunterText.SetActive(false);
        TipText.SetActive(false);
    }
}
