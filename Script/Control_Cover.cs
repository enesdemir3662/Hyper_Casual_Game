using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Cover : MonoBehaviour
{
    //Bu scripti kapak koyan objemizin içine attým bir kahve deðdiðinde bu script algýlýyor ve gerekli iþlemleri yapýyor.
    private Vector3 a;
    void Start()
    {
        a = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toplandi") || other.gameObject.CompareTag("Ana_Kahve")) //Toplanan kahve veya ilk kahvemiz deðdiðinde (kapak koyan obejemize)
        {
            GameObject.Find("Canvas").GetComponent<Sayi_Tut>().Kapanan_Sayi_Al(gameObject,other.gameObject); //kaç adet kahve kapaklý hale gelmiþ sayý alýyoruz
            GameObject.Find("Canvas").GetComponent<Sayi_Tut>().Kapatilan_Sayi++;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.589f, transform.position.z);//Kpak koyan objemizin çubuk kýsmýnda çubuðu ileri geri yaptýrarak kapak koyuyor gösteriyorum (görsel)
        }
    }
    public void Sayi_Alindi(int Kapaklanan_Sayi, int Toplanan_Sayi,GameObject otherr) //yukarda sayý almýþtýk sayýyý bu fonksiyona getirttiriyorum, toplanan sayý bizim kaç bardak topladýðýmýzýn sayýsý otherr da yukardaki otherýmýz onu buraya getirttiriyorum
    {
        Toplanan_Sayi = Toplanan_Sayi - Kapaklanan_Sayi; 
        if(Toplanan_Sayi<0)
        {
            Toplanan_Sayi = 0;
        }
        GameObject.Find("Coffee_B" + Toplanan_Sayi).GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Coffee_K" + Toplanan_Sayi).GetComponent<MeshRenderer>().enabled = true;
        if(otherr.gameObject.tag != "Ana_Kahve")//burda çarpan objemiz anakahve deðilse ozmn bu boþ bardaklarýmýzý görünmez tagý veriyoz  
        {
            GameObject.Find("Coffee_B" + Toplanan_Sayi).tag = "Gorunmez_0";//gizli kahvelerimiz var anakahveye baðlý onlara kapaksýza gorunmez0 kapaklýsýna gorunmez1 taglarý verdim
        }
            GameObject.Find("Coffee_K" + Toplanan_Sayi).tag = "Ýlave"; //kapaklanan kahvelere ilave tagýný verdim
        if (Toplanan_Sayi > 0)
            {
            Destroy(GameObject.Find("Coffee_B" + (Toplanan_Sayi - 1).ToString()).GetComponent<Control_Picker>());//burda kapaklý kahveler geleceði için kapaksýz kahvelerden control picker scriptini kaldýrdýk
            Destroy(GameObject.Find("Coffee_K" + (Toplanan_Sayi - 1).ToString()).GetComponent<Control_Picker>());//burda önceden kapaklý hale gelen kahvelerden pickeri kaldýrdýk (amaç arkadaki kapaklý kahveler bir kahveye deðdiðinde toplamasýn)(picker kahve toplamayý saðlýyan script)
        }
        GameObject.Find("Coffee_K" + Toplanan_Sayi).AddComponent<Control_Picker>();//burda kapaklý hale gelen kahvemize picker scriptini ekliyoz
        GameObject.Find("Coffee_B0").GetComponent<Puan>().kapatidi_kahve();//puan vercez kapak koyan yerden geçtiði için.
    }
    private void OnTriggerExit(Collider other)
    {
        transform.position = a;
    }
}
