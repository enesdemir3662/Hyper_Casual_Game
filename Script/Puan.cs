using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puan : MonoBehaviour
{
    public float Toplanan_Kahve_Fiyat;
    public float Doldurulan_Kahve_Fiyat;
    public float Kapatilan_Kahve_Fiyat;
    public float Buzlu_Kahve_Fiyat;
    public float Toplam;
    private GameObject Tas;
    public TextMeshProUGUI skor_txt;
    void Start()
    {
        Tas = GameObject.Find("Tas");
    }
    void Update()
    {
        
    }
    public void Destroy_Doldurulan()
    {
        Toplam = Toplam - Doldurulan_Kahve_Fiyat;
        Text_Degistir();
    }
    public void Destroy_Kapatilan()
    {
        Toplam = Toplam - Kapatilan_Kahve_Fiyat;
        Text_Degistir();
    }
    public void Destroy_Toplandi()
    {
        Toplam = Toplam - Toplanan_Kahve_Fiyat;
        Text_Degistir();
    }
    public void Toplandi_Kahve()
    {
        Toplam = Toplam + Toplanan_Kahve_Fiyat;
        GameObject.Find("Canvas").GetComponent<Sound_Control>().Water_Sound_true();
        Text_Degistir();
    }
    public void kapatidi_kahve()
    {
        Toplam = Toplam + Kapatilan_Kahve_Fiyat;
        GameObject.Find("Canvas").GetComponent<Sound_Control>().Water_Sound_true();
        Text_Degistir();
    }
    public void doldu_kahve()
    {
        Toplam = Toplam + Doldurulan_Kahve_Fiyat;
        GameObject.Find("Canvas").GetComponent<Sound_Control>().Water_Sound_true();
        Text_Degistir();
    }
    public void Buzlu_Kahve()
    {
        Toplam = Toplam + Buzlu_Kahve_Fiyat;
        GameObject.Find("Canvas").GetComponent<Sound_Control>().Water_Sound_true();
        Text_Degistir();
    }
    private void Text_Degistir()
    {
        skor_txt.text = (Toplam + 0).ToString();
    }
    public void puan_hesapla()
    {
        float H = 0;
        if(Toplam>560)
        {
            H = 33;
        }
        else if (Toplam > 540)
        {
            H = 32;
        }
        else if (Toplam > 520)
        {
            H = 31;
        }
        else if (Toplam > 500)
        {
            H = 30;
        }
        else if (Toplam > 480)
        {
            H = 29;
        }
        else if (Toplam > 460)
        {
            H = 28;
        }
        else if (Toplam > 440)
        {
            H = 27;
        }
        else if (Toplam > 420)
        {
            H = 26;
        }
        else if(Toplam>400)
        {
            H = 25;
        }
        else if(Toplam>380)
        {
            H = 24;
        }
        else if(Toplam>360)
        {
            H = 23;
        }
        else if (Toplam > 340)
        {
            H = 22;
        }
        else if (Toplam > 320)
        {
            H = 21;
        }
        else if (Toplam > 300)
        {
            H = 20;
        }
        else if (Toplam > 280)
        {
            H = 19;
        }
        else if (Toplam > 260)
        {
            H = 18;
        }
        else if (Toplam > 240)
        {
            H = 17;
        }
        else if (Toplam > 220)
        {
            H = 16;
        }
        else if (Toplam > 200)
        {
            H = 15;
        }
        else if (Toplam > 180)
        {
            H = 14;
        }
        else if (Toplam > 160)
        {
            H = 13;
        }
        else if (Toplam > 140)
        {
            H = 12;
        }
        else if (Toplam > 120)
        {
            H = 11;
        }
        else if (Toplam > 100)
        {
            H = 10;
        }
        else if (Toplam > 80)
        {
            H = 9;
        }
        else if (Toplam > 60)
        {
            H = 8;
        }
        else if (Toplam > 40)
        {
            H = 7;
        }
        else if (Toplam > 20)
        {
            H = 6;
        }
        else
        {
            H = 5;
        }
        Tas.gameObject.GetComponent<Tas>().h = H;//taþa diyoruz ki sen h kadar tepeye çýk 
    }
}
