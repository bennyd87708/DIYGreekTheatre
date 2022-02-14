using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntagonistSelect : MonoBehaviour
{
	public static string antagonist = "man2";
	public static string antagonistName = "Vilnius";
	public GameObject woman1;
	public GameObject woman2;
	public GameObject woman3;
	public GameObject woman4;
	public GameObject man1;
	public GameObject man2;
	public GameObject man3;
	public GameObject man4;
	public Color selectedColor;
	public Color unselectedColor;
	
	public void selectName(string s)
	{
		antagonistName = s;
	}
	
    public void selectAntagonist(string s)
	{
		antagonist = s;
		woman1.GetComponent<Image>().color = unselectedColor;
		woman2.GetComponent<Image>().color = unselectedColor;
		woman3.GetComponent<Image>().color = unselectedColor;
		woman4.GetComponent<Image>().color = unselectedColor;
		man1.GetComponent<Image>().color = unselectedColor;
		man2.GetComponent<Image>().color = unselectedColor;
		man3.GetComponent<Image>().color = unselectedColor;
		man4.GetComponent<Image>().color = unselectedColor;
		switch(s)
		{
			case "woman1":
				woman1.GetComponent<Image>().color = selectedColor;
				break;
			case "woman2":
				woman2.GetComponent<Image>().color = selectedColor;
				break;
			case "woman3":
				woman3.GetComponent<Image>().color = selectedColor;
				break;
			case "woman4":
				woman4.GetComponent<Image>().color = selectedColor;
				break;
			case "man1":
				man1.GetComponent<Image>().color = selectedColor;
				break;
			case "man2":
				man2.GetComponent<Image>().color = selectedColor;
				break;
			case "man3":
				man3.GetComponent<Image>().color = selectedColor;
				break;
			case "man4":
				man4.GetComponent<Image>().color = selectedColor;
				break;
		}
	}
}
