using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fnish : MonoBehaviour
{
    private GameObject cam;
    private GameObject Tas;
    private GameObject anakahve;
    void Start()
    {
        cam = GameObject.Find("Camera");
        Tas = GameObject.Find("Tas");
        anakahve = GameObject.Find("Coffee_B0");
    }
    //fnish scripti haritada sonda 1$ yazýsý olan yerde
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ana_Kahve"))//fnish çizgisini ana kahvemiz geçtiðide çalýþacak
        {
            anakahve.GetComponent<Puan>().puan_hesapla();//puaný hesaplattýrýyoruz skor gösterecek omna göre
            cam.gameObject.GetComponent<Kamera>().target = GameObject.Find("Tas").transform;
            cam.gameObject.GetComponent<Kamera>().offset = new Vector3(-9, 3, -2);
            anakahve.GetComponent<Hareket_Etme>().hiz = 0;
            Tas.gameObject.GetComponent<Tas>().hiz = 3;
        }
    }
}