using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sayi_Tut : MonoBehaviour
{
    public int Toplanan_Sayi;
    public int Kapatilan_Sayi;
    public List<Vector3> Level_Transformlarý;
    void Start()
    {
        Toplanan_Sayi = 0;
        Kapatilan_Sayi = 0;
    }
    void Update()
    {
        
    }
    public void Toplanan_Sayi_Al(GameObject obje)
    {
        obje.gameObject.GetComponent<Control_Picker>().Sayi_Alindi(Toplanan_Sayi);
    }
    public void Kapanan_Sayi_Al(GameObject obje,GameObject otherr)
    {
        obje.gameObject.GetComponent<Control_Cover>().Sayi_Alindi(Kapatilan_Sayi,Toplanan_Sayi,otherr);
    }
    public void Toplanan_Sayi_Al_2()
    {
        GameObject.Find("Kesici").GetComponent<Control_Saw>().Sayi_Alindi(Toplanan_Sayi);//testerenin kesici kýsmýndaki saw scripti
    }
    public void Kapanan_Sayi_Al_2()
    {
        GameObject.Find("Kesici").GetComponent<Control_Saw>().Sayi_Alindi(Kapatilan_Sayi);
    }
}
