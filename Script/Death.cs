using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public Text Text_1;
    public Text Text_2;
    public Text Next_Text;
    public GameObject Level;
    public int Bardak_Sayisi;
    private GameObject Kahveler;
    private GameObject Canvas;
    void Start()
    {
        Kahveler = Resources.Load<GameObject>("Kahveler");//ana kahvemizin önündeki gizli olan kahvelerimiz
        Canvas = GameObject.Find("Canvas");
    }
    public void Death_Game()//öldüðümüzde bu fonksiyon çalýþýyor
    {
        GameObject.Find("Canvas").GetComponent<Restart_Menu>().Restart_menu_open();
        Text_1.text = "YOU LOST";
        Text_2.text = "TRY AGAIN";
        Next_Text.text = "RESTART";
        gameObject.transform.position = new Vector3(-460.80f, 4.68f, -2.19f);
        Canvas.GetComponent<Sound_Control>().Lose_Sound_true();//öldün sesi çaldýrýyoruz.
    }
    public void Sifirla()//oyunu baþtan baþlatmak veya sonraki levele geçtiðimizde oyunu sýfýrlýyoruz
    {
        if (gameObject.transform.position.x == -460.81f)//anakahvem baþlangýc pozisyonundamý kontrol ediyorum
        {
            Canvas.GetComponent<Play>().Play_Game();//oyuna girdiðimi belirtiyorum 
        }
        else
        {
            gameObject.transform.position = new Vector3(-460.81f, 4.68f, -2.19f);
            int _level = Canvas.GetComponent<Play>().level;
            if (Canvas.GetComponent<Play>().level_gecildi == true)//level geçtikmi kontrol ediyoz
            {
                Canvas.GetComponent<Play>().level_gecildi = false;
                Destroy(GameObject.Find("Level_" + (_level -1).ToString()));//hangi levelde isek o level adýndaki objemizi siliyoruz
            }
            else
            {
                Destroy(GameObject.Find("Level_" + _level.ToString()));
            }
            Level = Resources.Load<GameObject>("Level_" + Canvas.GetComponent<Play>().level);//leveli resources klosöründen import ediyoz
            for (int i = 0; i < Bardak_Sayisi; i++)
            {
                GameObject.Find("Coffee_B" + i).GetComponent<MeshRenderer>().enabled = false;
                GameObject.Find("Coffee_K" + i).GetComponent<MeshRenderer>().enabled = false;
                Destroy(GameObject.Find("Coffee_B" + i).GetComponent<Control_Picker>());
                Destroy(GameObject.Find("Coffee_K" + i).GetComponent<Control_Picker>());
                GameObject.Find("Coffee_B" + i).tag = "Gorunmez_0";
                GameObject.Find("Coffee_K" + i).tag = "Gorunmez_1";
            }
            GameObject obje = Instantiate(Level, new Vector3(Canvas.GetComponent<Sayi_Tut>().Level_Transformlarý[_level - 1].x, Canvas.GetComponent<Sayi_Tut>().Level_Transformlarý[_level - 1].y, Canvas.GetComponent<Sayi_Tut>().Level_Transformlarý[_level - 1].z), Quaternion.identity);
            //level oluþturma konumunu yerini sayi tut scriptinde bir listede tuttum levele göre oluþturacaðý konumu ordan alýyor þuan max 5 level var 5 konumuda oraya girdim.
            obje.gameObject.name = "Level_" + _level;
            GameObject.Find("Coffee_B0").tag = "Ana_Kahve";
            GameObject.Find("Tas").gameObject.transform.position = new Vector3(-385.67f, 5.00f, -0.4358792f);//oyun sonunmdaki puan yerinde yükselen bir taþýmýz var onu tekrar eski konumuna getiriyoruz
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Puan>().Toplam = 0;
            gameObject.AddComponent<Control_Picker>();
            gameObject.GetComponent<Hareket_Etme>().hiz = 2;//menüdeyken hareket etmesin diye hiz i 0 a düþürmüþtük onu tekrar 2 yapýyoruz
            gameObject.GetComponent<Hareket_Etme>().pc_donme = 2;
            gameObject.GetComponent<Hareket_Etme>().Dokunmatik_donme = 0.01f;
            GameObject.Find("Camera").GetComponent<Kamera>().target = GameObject.Find("Coffee_B0").gameObject.transform;//kameranýn target ýný tekrar bizim ana kahvemiz yapýyoruz 
            GameObject.Find("Camera").GetComponent<Kamera>().offset = new Vector3(-2, 2, 0);//kameranýn hangi uzaklýkta takip edeceði
            Canvas.GetComponent<Sayi_Tut>().Kapatilan_Sayi = 0;
            Canvas.GetComponent<Sayi_Tut>().Toplanan_Sayi = 0;
            Destroy(GameObject.Find("Kahveler"));
            GameObject obje2 = Instantiate(Kahveler, new Vector3(-460.81f, 4.68f, -2.19f), Quaternion.identity);//ana kahvemizin önündeki gizli kahvelerimizi oluþturuyoruz
            obje2.gameObject.name = "Kahveler";
            obje2.transform.parent = gameObject.transform;//bu gizli kahveleri ana kahvemize baðlýyoruz
            Canvas.GetComponent<Sound_Control>().Lose_Sound_false();
            Canvas.GetComponent<Sound_Control>().Death_Sound_false();
            gameObject.GetComponent<Puan>().skor_txt.text = 0.ToString();
            Canvas.GetComponent<Play>().Play_Game();
        }
    }
}
