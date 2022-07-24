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
            other.gameObject.transform.position = new Vector3(Pozisyon.x, Pozisyon.y, Pozisyon.z); //Buz_doldurucunun buzlarý sürekli rg sayesinde düþtüðünden yere bir buz deðdiðinde o buzu tekrar yukarý doðru ýþýnlatýyorum ki sürekli devir daim yapsýn buzlar sürekli düþsün.
        }
        else if (other.gameObject.CompareTag("Toplandi") || other.gameObject.CompareTag("Ana_Kahve"))
        {
            GameObject.Find("Coffee_B0").gameObject.GetComponent<Puan>().Buzlu_Kahve();
        }
    }
}
