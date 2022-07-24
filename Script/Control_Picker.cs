using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Picker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //bu scripte toplanmamýþ kahve topluyoruz 
        if (other.gameObject.CompareTag("Toplanacak"))
        {
            GameObject.Find("Canvas").GetComponent<Sayi_Tut>().Toplanan_Sayi++;
            GameObject.Find("Canvas").GetComponent<Sayi_Tut>().Toplanan_Sayi_Al(gameObject);
            other.gameObject.SetActive(false);
        }
    }
    public void Sayi_Alindi(int Toplanan_Sayi)
    {
        GameObject.Find("Coffee_B" + Toplanan_Sayi).AddComponent<Control_Picker>();
        GameObject.Find("Coffee_B" + Toplanan_Sayi).gameObject.tag = "Toplandi";
        GameObject.Find("Coffee_B" + Toplanan_Sayi).GetComponent<MeshRenderer>().enabled = true;
        Destroy(GameObject.Find("Coffee_B" + (Toplanan_Sayi - 1).ToString()).GetComponent<Control_Picker>());
        Destroy(GameObject.Find("Coffee_K" + (Toplanan_Sayi - 1).ToString()).GetComponent<Control_Picker>());
        GameObject.Find("Coffee_B0").GetComponent<Puan>().Toplandi_Kahve();
    }
}