using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vendingMachine : MonoBehaviour
{
    public Transform shop;
    public Transform Player;
    public Transform spawnpoint;
    public Transform ammo;
    public Transform health;
    public Transform repeater;
    public Transform blaster;
    public Transform phaser;
    public Transform flamethrower;
    public bool canBuy;
    public bool isBuying;
    public bool check;

    public int Ammocost = 5;
    public int Healthcost = 10;
    public int Repeatercost = 50;
    public int Blastercost = 40;
    public int Phasercost = 40;
    public int Flamethrowercost = 100;

    public Canvas Vender;
    public Button Ammo;
    public Button Health;
    public Button Repeater;
    public Button Blaster;
    public Button Phaser;
    public Button Flamethrower;
    // Use this for initialization
    void Start()
    {
        Vender = Vender.GetComponent<Canvas>();
        Ammo = Ammo.GetComponent<Button>();
        Health = Health.GetComponent<Button>();
        Repeater = Repeater.GetComponent<Button>();
        Blaster = Blaster.GetComponent<Button>();
        Phaser = Phaser.GetComponent<Button>();
        Flamethrower = Flamethrower.GetComponent<Button>();

        canBuy = false;
        isBuying = false;
        Vender.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (check == false && canBuy == true)
        {
            if (Input.GetKeyDown("f"))
            {
                isBuying = true;
                check = true;
            }
        }
        else if (check == true){
            if (Input.GetKeyDown("f"))
            {
                isBuying = false;
                check = false;
            }
        }

        //Vending UPDATE Machine Button Management###################################################################
        if (isBuying == true)
        {
            Vender.enabled = true;
        }
        else
        {
            Vender.enabled = false;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canBuy = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canBuy = false;
            isBuying = false;
            Vender.enabled = false;
        }
    }
    void OnGUI()
    {
        if (canBuy == true)
        {
            if(isBuying == false)
            GUI.Label(new Rect(Screen.width  / 2 - 100, Screen.height / 2 - 50, 200, 500), "Press [F] to access Vending Machine");
        }
    }

    //Vending Machine Button Management###################################################################
   
    public void ammoSpawn()
    {
        if (GameObject.Find("General").GetComponent<survivalGeneral>().points >= Ammocost)
        {
            Instantiate(ammo, Player.position, repeater.rotation);
            GameObject.Find("General").GetComponent<survivalGeneral>().points -= Ammocost;
        }

    }
    public void healthSpawn()
    {
        if (GameObject.Find("General").GetComponent<survivalGeneral>().points >= Healthcost)
        {
            Instantiate(health, Player.position, repeater.rotation);
            GameObject.Find("General").GetComponent<survivalGeneral>().points -= Healthcost;
        }
    }
    public void repeaterSpawn()
    {
        if (GameObject.Find("General").GetComponent<survivalGeneral>().points >= Repeatercost)
        {
            Instantiate(repeater, Player.position, repeater.rotation);
            GameObject.Find("General").GetComponent<survivalGeneral>().points -= Repeatercost;
        }
    }
    public void blasterSpawn()
    {
        if (GameObject.Find("General").GetComponent<survivalGeneral>().points >= Blastercost)
        {
            Instantiate(blaster, Player.position, blaster.rotation);
            GameObject.Find("General").GetComponent<survivalGeneral>().points -= Blastercost;
        }
        }
    public void phaserSpawn()
    {
        if (GameObject.Find("General").GetComponent<survivalGeneral>().points >= Phasercost)
        {
            Instantiate(phaser, Player.position, phaser.rotation);
            GameObject.Find("General").GetComponent<survivalGeneral>().points -= Phasercost;
        }
        }
    public void flamethrowerSpawn()
    {
        if (GameObject.Find("General").GetComponent<survivalGeneral>().points >= Flamethrowercost)
        {
            Instantiate(flamethrower, Player.position, flamethrower.rotation);
            GameObject.Find("General").GetComponent<survivalGeneral>().points -= Flamethrowercost;
        }
        }







}
