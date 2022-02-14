using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeSelect : MonoBehaviour
{
	public static bool comedy = false;
	public GameObject comedyButton;
	public GameObject tragedyButton;
	public GameObject text;
	
	public void selectType(bool t)
	{
		comedy = t;
		if (comedy)
		{
			text.GetComponent<TextMeshProUGUI>().text = "SELECT A FRIEND";
		} else {
			text.GetComponent<TextMeshProUGUI>().text = "SELECT ANTAGONIST";
		}
	}
}
