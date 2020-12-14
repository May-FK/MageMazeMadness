using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;

public class Abilities : MonoBehaviourPunCallbacks
{
    #region Time Tagged Float
    private float timeTagged = 0f;
    #endregion

    #region Mage Type
    public enum MageType
    {
        Hunter,
        Fire,
        Wind,
        Lightning
    }

    private MageType CurrentType;
    private MageType NextType;
    #endregion

    public bool hasMana;
    private bool useAbility;
    private bool canBurn;

    #region Speeds
    float defaultSpeed = 7.5f;
    float hunterMuliplier = 1.25f;
    float speedBoost = 2f;
    public float jumpSpeed = 20.0f;
    #endregion

    #region Timers
    const float BURN_TIMER = 5.0f;
    const float SPEED_TIMER = 2.0f;

    float burnTimer;
    float speedtimer;
    #endregion

    #region Object References
    PlayerController pc;
    GameObject manaText;
    [SerializeField]
    GameObject HunterModel;
    [SerializeField]
    GameObject FireModel;
    [SerializeField]
    GameObject WindModel;
    [SerializeField]
    GameObject LightningModel;
    GameObject wall;
    #endregion

    public void SetType (MageType mt)
    {
        CurrentType = mt;
    }

    public MageType GetCurrentType()
    {
        return CurrentType;
    }

    // Start is called before the first frame update
    void Awake()
    {
        pc = this.gameObject.GetComponent<PlayerController>();
        manaText = GameObject.Find("Mana");
    }

    // Update is called once per frame
    void Update()
    {
        #region Common Updates

        #region Mana Text
        if (hasMana)
        {
            manaText.SetActive(true);
        }
        
        else manaText.SetActive(false);
        #endregion

        #endregion

        #region Interaction
        if (Input.GetKeyDown(KeyCode.F) && hasMana == true)
        {
            switch (CurrentType)
            {
                case MageType.Hunter:
                    break;
                case MageType.Fire:
                    burnWall();
                    burnTimer = BURN_TIMER;
                    break;
                case MageType.Wind:
                    pc.jump = true;
                    hasMana = false;
                    break;
                case MageType.Lightning:
                    pc.speed = defaultSpeed * speedBoost;
                    speedtimer = SPEED_TIMER;
                    hasMana = false;
                    break;
            }
            
        }

        else if (Input.GetKeyDown(KeyCode.F) && hasMana == false)
        {
            Debug.Log("You need mana to use this ability");
        }
        #endregion

        #region Timers
        if (burnTimer > 0)
        {
            burnTimer -= Time.deltaTime;
        }

        //TODO: Set wall to active

        if (speedtimer > 0)
        {
            speedtimer -= Time.deltaTime;
        }

        else if ((speedtimer <= 0) && CurrentType != MageType.Hunter)
        {
            pc.speed = defaultSpeed;
        }

        if (CurrentType == MageType.Hunter)
        {
            timeTagged += Time.deltaTime;
        }
        #endregion
    }

    #region OnTrigger
    private void OnTriggerEnter(Collider col)
    {
        if ((CurrentType != MageType.Hunter) && col.GetComponent<Abilities>().GetCurrentType() == MageType.Hunter)
        {
            this.photonView.RPC("Tagged", RpcTarget.AllBuffered);
            return;
        }

        if (col.gameObject.CompareTag("iWall") && col.gameObject.activeInHierarchy == true)
        {
            canBurn = true;
            Debug.Log("Ability can be used");
        }

        if (CurrentType == MageType.Hunter)
        {
            NextType = col.GetComponent<Abilities>().GetCurrentType();

            switch (NextType)
            {
                case MageType.Hunter:
                    return;
                case MageType.Fire:
                    this.photonView.RPC("BecomeFire", RpcTarget.AllBuffered);
                    break;
                case MageType.Wind:
                    this.photonView.RPC("BecomeWind", RpcTarget.AllBuffered);
                    break;
                case MageType.Lightning:
                    this.photonView.RPC("BecomeLightning", RpcTarget.AllBuffered);
                    break;
            }
        }
    }

    private void OnTriggerStay(Collider col)
    {
        //If the FireMage has an orb and is next to an interactable hedge they will use their abiliy 
        if (CurrentType == MageType.Fire)
        {
            if (col.gameObject.CompareTag("iWall") && useAbility == true)
            {
                if (wall == null)
                {
                    wall = col.gameObject;
                    wall.SetActive(false);
                }

                canBurn = false;
                useAbility = false;
                hasMana = false;
            }
        }

    }

    private void OnTriggerExit(Collider col)
    {
        //The FireMage can only use their ability next to a interactable hedge
        if (CurrentType == MageType.Fire)
        {
            useAbility = false;
        }
    }
    #endregion

    void burnWall()
    {
        useAbility = true;
    }

    public float getTimeTagged()
    {
        return timeTagged;
    }

    #region Change Mages
    [PunRPC]
    void Tagged()
    {
        Invoke("BecomeHunter", 1.0f);
    }

    void BecomeHunter()
    {
        this.FireModel.SetActive(false);
        this.WindModel.SetActive(false);
        this.LightningModel.SetActive(false);
        this.HunterModel.SetActive(true);
    }

    [PunRPC]
    void BecomeFire()
    {
        this.HunterModel.SetActive(false);
        this.FireModel.SetActive(true);
    }

    [PunRPC]
    void BecomeWind()
    {
        this.HunterModel.SetActive(false);
        this.WindModel.SetActive(true);
    }

    [PunRPC]
    void BecomeLightning()
    {
        this.HunterModel.SetActive(false);
        this.LightningModel.SetActive(true);
    }
    #endregion
}
