using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_Menu : MonoBehaviour
{
    public GameObject AnaMenu;
    public GameObject Game;
    public GameObject Restart;
    private GameObject anakahve;
    void Start()
    {
        anakahve = GameObject.Find("Coffee_B0");
    }
    void Update()
    {
        
    }
    public void Restart_menu_open()
    {
        anakahve.GetComponent<Hareket_Etme>().hiz = 0;
        anakahve.GetComponent<Hareket_Etme>().pc_donme = 0;
        anakahve.GetComponent<Hareket_Etme>().Dokunmatik_donme = 0;
        AnaMenu.SetActive(false);
        Game.SetActive(false);
        Restart.SetActive(true);
        GameObject.Find("Canvas").GetComponent<Play>().Oyunda_Degilim();
    }
}
