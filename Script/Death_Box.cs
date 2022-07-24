using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Box : MonoBehaviour
{
    private GameObject ana_kahve;
    //Yanlara çarparsa ölüm
    void Start()
    {
        ana_kahve = GameObject.Find("Coffee_B0");
    }
    private void OnCollisionEnter(Collision collision)
    {
        ana_kahve.gameObject.GetComponent<Death>().Death_Game();
    }
}
