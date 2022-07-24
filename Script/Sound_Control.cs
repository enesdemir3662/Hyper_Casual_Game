using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Control : MonoBehaviour
{
    public GameObject Death_Sound;
    public GameObject Lose_Sound;
    public GameObject Background_Sound;
    public GameObject Water_Drop_Sound;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Death_Sound_true()
    {
        Death_Sound.gameObject.SetActive(true);
    }
    public void Background_Sound_true()
    {
        Background_Sound.gameObject.SetActive(true);
    }
    public void Lose_Sound_true()
    {
        Lose_Sound.gameObject.SetActive(true);
    }
    public void Water_Sound_true()
    {
        Water_Drop_Sound.gameObject.SetActive(false);
        Water_Drop_Sound.gameObject.SetActive(true);
    }
    public void Death_Sound_false()
    {
        Death_Sound.gameObject.SetActive(false);
    }
    public void Background_Sound_false()
    {
        Background_Sound.gameObject.SetActive(false);
    }
    public void Lose_Sound_false()
    {
        Lose_Sound.gameObject.SetActive(false);
    }
}
