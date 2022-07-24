using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_ice : MonoBehaviour
{
    private Vector3 Pozisyon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("buz"))
        {
            Pozisyon = GameObject.Find("buz_konum").gameObject.transform.position;
            other.gameObject.transform.position = new Vector3(Pozisyon.x, Pozisyon.y, Pozisyon.z); //Buz_doldurucunun buzlar� s�rekli rg sayesinde d��t���nden yere bir buz de�di�inde o buzu tekrar yukar� do�ru ���nlat�yorum ki s�rekli devir daim yaps�n buzlar s�rekli d��s�n.
        }
        else if (other.gameObject.CompareTag("Toplandi") || other.gameObject.CompareTag("Ana_Kahve"))
        {
            GameObject.Find("Coffee_B0").gameObject.GetComponent<Puan>().Buzlu_Kahve();
        }
    }
}
