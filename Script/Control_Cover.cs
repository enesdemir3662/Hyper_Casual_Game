using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Cover : MonoBehaviour
{
    //Bu scripti kapak koyan objemizin i�ine att�m bir kahve de�di�inde bu script alg�l�yor ve gerekli i�lemleri yap�yor.
    private Vector3 a;
    void Start()
    {
        a = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toplandi") || other.gameObject.CompareTag("Ana_Kahve")) //Toplanan kahve veya ilk kahvemiz de�di�inde (kapak koyan obejemize)
        {
            GameObject.Find("Canvas").GetComponent<Sayi_Tut>().Kapanan_Sayi_Al(gameObject,other.gameObject); //ka� adet kahve kapakl� hale gelmi� say� al�yoruz
            GameObject.Find("Canvas").GetComponent<Sayi_Tut>().Kapatilan_Sayi++;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.589f, transform.position.z);//Kpak koyan objemizin �ubuk k�sm�nda �ubu�u ileri geri yapt�rarak kapak koyuyor g�steriyorum (g�rsel)
        }
    }
    public void Sayi_Alindi(int Kapaklanan_Sayi, int Toplanan_Sayi,GameObject otherr) //yukarda say� alm��t�k say�y� bu fonksiyona getirttiriyorum, toplanan say� bizim ka� bardak toplad���m�z�n say�s� otherr da yukardaki other�m�z onu buraya getirttiriyorum
    {
        Toplanan_Sayi = Toplanan_Sayi - Kapaklanan_Sayi; 
        if(Toplanan_Sayi<0)
        {
            Toplanan_Sayi = 0;
        }
        GameObject.Find("Coffee_B" + Toplanan_Sayi).GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Coffee_K" + Toplanan_Sayi).GetComponent<MeshRenderer>().enabled = true;
        if(otherr.gameObject.tag != "Ana_Kahve")//burda �arpan objemiz anakahve de�ilse ozmn bu bo� bardaklar�m�z� g�r�nmez tag� veriyoz  
        {
            GameObject.Find("Coffee_B" + Toplanan_Sayi).tag = "Gorunmez_0";//gizli kahvelerimiz var anakahveye ba�l� onlara kapaks�za gorunmez0 kapakl�s�na gorunmez1 taglar� verdim
        }
            GameObject.Find("Coffee_K" + Toplanan_Sayi).tag = "�lave"; //kapaklanan kahvelere ilave tag�n� verdim
        if (Toplanan_Sayi > 0)
            {
            Destroy(GameObject.Find("Coffee_B" + (Toplanan_Sayi - 1).ToString()).GetComponent<Control_Picker>());//burda kapakl� kahveler gelece�i i�in kapaks�z kahvelerden control picker scriptini kald�rd�k
            Destroy(GameObject.Find("Coffee_K" + (Toplanan_Sayi - 1).ToString()).GetComponent<Control_Picker>());//burda �nceden kapakl� hale gelen kahvelerden pickeri kald�rd�k (ama� arkadaki kapakl� kahveler bir kahveye de�di�inde toplamas�n)(picker kahve toplamay� sa�l�yan script)
        }
        GameObject.Find("Coffee_K" + Toplanan_Sayi).AddComponent<Control_Picker>();//burda kapakl� hale gelen kahvemize picker scriptini ekliyoz
        GameObject.Find("Coffee_B0").GetComponent<Puan>().kapatidi_kahve();//puan vercez kapak koyan yerden ge�ti�i i�in.
    }
    private void OnTriggerExit(Collider other)
    {
        transform.position = a;
    }
}
