using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hareket_Etme : MonoBehaviour
{
    public float pc_donme;
    public float hiz;
    public float Dokunmatik_donme;
    public float algilama;
    //bu script ana kahvemizin ileri gitmesini ve klavyeden ad tu�lar�na g�re d�nmesini sa�l�yoruz dokunmatik scripti ba�ka scripte
    void Update()
    {
        GameObject.Find("Canvas").gameObject.GetComponent<Play>().Oyundami();//oyundaysak �al��acak oyunda de�ilsek men�deysek hareket etmicek

    }
    public void Donus()
    {  
        algilama = Input.GetAxis("Horizontal") * pc_donme * Time.deltaTime;
        this.transform.Translate(new Vector3(hiz * Time.deltaTime, algilama, 0));
    }
    
}