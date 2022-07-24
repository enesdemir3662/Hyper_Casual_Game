using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ana_Menu : MonoBehaviour
{
    public GameObject AnaMenu;
    public GameObject Game;
    public GameObject Restart;
    public void Ana_Menu_Don()
    {
        AnaMenu.SetActive(true);
        Game.SetActive(false);
        Restart.SetActive(false);
        gameObject.GetComponent<Play>().Oyunda_Degilim(); //Menü açýkmý onu kontrol ediyorum.
    }
}
