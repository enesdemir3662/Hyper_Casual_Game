using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public int level;
    public GameObject Level;
    public bool level_gecildi;
    public bool oyundayim;
    public GameObject AnaMenu;
    public GameObject Game;
    public GameObject Restart;
    public Text Next_Text;
    public Text Level_Text;
    public int MaxLevel;
    void Start()
    {
        level_gecildi = false;
        oyundayim = false;
        level = 1;
        Oyunda_Degilim();
    }
    void Update()
    {
        
    }
    public void Play_Game()
    {
        AnaMenu.SetActive(false);
        Game.SetActive(true);
        Restart.SetActive(false);
        Oyundayim();
    }
    public void Level_Gec()
    {
        if(Next_Text.text == "NEXT")
        {
            if (Level_Text.text == "Level " + MaxLevel)
            {
                level = 1;
            }
            else
            {
                level++;
                level_gecildi = true;
            }
            Level_Text.text = "Level " + level.ToString();
        }
        GameObject.Find("Coffee_B0").GetComponent<Death>().Sifirla();
    }
    public void Oyundayim()
    {
        oyundayim = true;
    }
    public void Oyunda_Degilim()
    {
        oyundayim = false;
    }
    public void Oyundami()
    {
        if(oyundayim == true)
        {
            GameObject.Find("Coffee_B0").gameObject.GetComponent<Hareket_Etme>().Donus();
        }
    }
}
