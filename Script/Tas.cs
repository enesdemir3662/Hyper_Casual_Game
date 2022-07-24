using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tas : MonoBehaviour
{
    public float hiz;
    public float h;
    private GameObject canvas;
    public Text Text_1;
    public Text Text_2;
    public Text Next_Text;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    void Update()
    {
        //oyun sonunda puaný gösteren taþýmýz
        if (hiz > 0)
        {
            if(h > transform.position.y)//h bizim ne kadar yükseleceðimiz puana göre taþ ona göre tepeye çýkacak gelmek istediði pozisyone gelene kadar tepeye çýkacak (puan scriptinde h ý belirledik)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.fixedDeltaTime * hiz, transform.position.z);
            }
            else
            {
                hiz = 0;//geldiðinde
                if(Text_1.text == "YOU LOST")
                {
                    Text_1.text = "YOU WIN";
                    Text_2.text = "AWESOME";
                    Next_Text.text = "NEXT";
                }
                canvas.gameObject.GetComponent<Restart_Menu>().Restart_menu_open();
            }
        }
    }
}
