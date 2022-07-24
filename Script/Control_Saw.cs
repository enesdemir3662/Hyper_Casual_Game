using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Saw : MonoBehaviour
{
    private GameObject Canvas;
    private GameObject ana_kahve;
    public float hiz;
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        ana_kahve = GameObject.Find("Coffee_B0");
    }
    void Update()
    {

    }
    //testereye attým bu scripti
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toplandi"))//toplanan kahveye deðdiðinde(kapaksýz)
        {
            Canvas.GetComponent<Sayi_Tut>().Toplanan_Sayi--;
            Canvas.GetComponent<Sayi_Tut>().Toplanan_Sayi_Al_2();//Toplanan kahve sayýsýný alýyoruz ve aldýðýmýzda alttaki fonksiyon çalýþýyor(daha kýsa yoldanda yapabilirdim ama ozmn böyle yapmýþým)
            ana_kahve.GetComponent<Puan>().Destroy_Toplandi();//puan siliyoruz
            Canvas.GetComponent<Sound_Control>().Death_Sound_true();//ses çýkmasýný saðlýyorum
        }
        else if (other.gameObject.CompareTag("Ýlave"))//kapaklý kahveye deðdiðinde
        {
            Canvas.GetComponent<Sayi_Tut>().Kapatilan_Sayi--;
            Canvas.GetComponent<Sayi_Tut>().Kapanan_Sayi_Al_2();//kapaklý kahve sayýsýný alýyoruz ve aldýðýmýzda alttaki fonksiyon çalýþýyor
            ana_kahve.GetComponent<Puan>().Destroy_Kapatilan();
            Canvas.GetComponent<Sound_Control>().Death_Sound_true();
        }
        else if (other.gameObject.CompareTag("Ana_Kahve"))//ana kahvemize deðdiðinde(ilk olan kahvemiz)
        {
            ana_kahve.GetComponent<Death>().Death_Game();
            Canvas.GetComponent<Sound_Control>().Death_Sound_true();
        }
    }
    public void Sayi_Alindi(int sayi)
    {
        GameObject.Find("Coffee_B" + (sayi + 1)).GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Coffee_B" + (sayi +1)).tag = "Gorunmez_0";
        GameObject.Find("Coffee_K" + (sayi + 1)).tag = "Gorunmez_1";
        GameObject.Find("Coffee_K" + (sayi + 1)).GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Coffee_K" + sayi.ToString()).AddComponent<Control_Picker>();
        GameObject.Find("Coffee_B" + sayi.ToString()).AddComponent<Control_Picker>();
        Canvas.GetComponent<Sound_Control>().Death_Sound_false();
    }
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.fixedDeltaTime * hiz);//testerenin kesici kýsmýnýn dönmesini saðlýyor
    }
}