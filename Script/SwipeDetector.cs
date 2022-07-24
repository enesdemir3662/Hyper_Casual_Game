using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
	private Vector2 parmak_alt_pozisyon;
	private Vector2 parmak_üst_pozisyon;
	public bool Kaydirma_algila = false;
	public float KAYDIRMA_ESIGI = 20f;
	void Update()
	{
		//Dokunmatik Kontroller
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				parmak_üst_pozisyon = touch.position;
				parmak_alt_pozisyon = touch.position;
			}

			if (touch.phase == TouchPhase.Moved)
			{
				if (!Kaydirma_algila)
				{
					parmak_alt_pozisyon = touch.position;
					DetectSwipe();
				}
			}
			if (touch.phase == TouchPhase.Ended)
			{
				parmak_alt_pozisyon = touch.position;
				DetectSwipe();
			}
		}
	}
	void DetectSwipe()
	{
		if (HorizontalMoveValue() > KAYDIRMA_ESIGI && HorizontalMoveValue() > VerticalMoveValue())
		{
			if (parmak_alt_pozisyon.x - parmak_üst_pozisyon.x > 0)
			{
				OnSwipeRight();
			}
			else if (parmak_alt_pozisyon.x - parmak_üst_pozisyon.x < 0)
			{
				OnSwipeLeft();
			}
			parmak_üst_pozisyon = parmak_alt_pozisyon;
		}
		else
		{
			//Kaydýrma Algýlanamadý
		}
	}
	float VerticalMoveValue()
	{
		return Mathf.Abs(parmak_alt_pozisyon.y - parmak_üst_pozisyon.y);
	}
	float HorizontalMoveValue()
	{
		return Mathf.Abs(parmak_alt_pozisyon.x - parmak_üst_pozisyon.x);
	}
	void OnSwipeLeft()
	{
		if (gameObject.GetComponent<Hareket_Etme>().Dokunmatik_donme != 0 && GameObject.Find("Canvas").GetComponent<Play>().oyundayim == true)
        {
			this.transform.Translate(new Vector3(gameObject.GetComponent<Hareket_Etme>().hiz * Time.deltaTime, -0.10f, 0));
		}
	}
	void OnSwipeRight()
	{
		if (gameObject.GetComponent<Hareket_Etme>().Dokunmatik_donme != 0 && GameObject.Find("Canvas").GetComponent<Play>().oyundayim == true)
		{
			this.transform.Translate(new Vector3(gameObject.GetComponent<Hareket_Etme>().hiz * Time.deltaTime, 0.10f, 0));
		}
	}
}