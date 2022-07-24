using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Doldurucu : MonoBehaviour
{
    private GameObject ana_kahve;
    public GameObject Uc_Kisim;
    void Start()
    {
        ana_kahve = GameObject.Find("Coffee_B0");
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Toplandi") || other.gameObject.CompareTag("Ana_Kahve"))
        {
            //kahve bardaðýnýn içine kahve dolmasýný göstermelik yaptým prototip oyun yapýyoruz diye (silindir gizledim)
            Uc_Kisim.GetComponent<MeshRenderer>().enabled = true;//silindiri aktif ediyorum kahve doluyor gözüksün diye puaný vs control doldurucu scriptinde verdim.
         
            ana_kahve.gameObject.GetComponent<Puan>().doldu_kahve();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        Uc_Kisim.GetComponent<MeshRenderer>().enabled = false;
    }
}
