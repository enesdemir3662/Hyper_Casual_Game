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
    //testereye att�m bu scripti
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toplandi"))//toplanan kahveye de�di�inde(kapaks�z)
        {
            Canvas.GetComponent<Sayi_Tut>().Toplanan_Sayi--;
            Canvas.GetComponent<Sayi_Tut>().Toplanan_Sayi_Al_2();//Toplanan kahve say�s�n� al�yoruz ve ald���m�zda alttaki fonksiyon �al���yor(daha k�sa yoldanda yapabilirdim ama ozmn b�yle yapm���m)
            ana_kahve.GetComponent<Puan>().Destroy_Toplandi();//puan siliyoruz
            Canvas.GetComponent<Sound_Control>().Death_Sound_true();//ses ��kmas�n� sa�l�yorum
        }
        else if (other.gameObject.CompareTag("�lave"))//kapakl� kahveye de�di�inde
        {
            Canvas.GetComponent<Sayi_Tut>().Kapatilan_Sayi--;
            Canvas.GetComponent<Sayi_Tut>().Kapanan_Sayi_Al_2();//kapakl� kahve say�s�n� al�yoruz ve ald���m�zda alttaki fonksiyon �al���yor
            ana_kahve.GetComponent<Puan>().Destroy_Kapatilan();
            Canvas.GetComponent<Sound_Control>().Death_Sound_true();
        }
        else if (other.gameObject.CompareTag("Ana_Kahve"))//ana kahvemize de�di�inde(ilk olan kahvemiz)
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
        transform.Rotate(Vector3.up * Time.fixedDeltaTime * hiz);//testerenin kesici k�sm�n�n d�nmesini sa�l�yor
    }
}