using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public static ArrayList sceneOrder;
	public GameObject text6;
	public GameObject text7;
	public GameObject text8;
	public GameObject text9;
	public GameObject text11;
	public GameObject text12;
	public GameObject text13;
	public GameObject text14;
	public GameObject text15;
	
    public void StartPlay()
	{
		sceneOrder = new ArrayList();
		for (int i = 1; i < 6; i++)
		{
			if (text6.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(1);
				continue;
			}
			if (text7.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(2);
				continue;
			}
			if (text8.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(3);
				continue;
			}
			if (text9.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(4);
				continue;
			}
			if (text11.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(5);
				continue;
			}
			if (text12.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(6);
				continue;
			}
			if (text13.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(7);
				continue;
			}
			if (text14.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(8);
				continue;
			}
			if (text15.GetComponent<DragAndDrop>().slot == i)
			{
				sceneOrder.Add(9);
				continue;
			}
		}
		sceneOrder.Add(10); //credits
		nextScene();
	}
	
	public void nextScene()
	{
		SceneManager.LoadScene((int) sceneOrder[0]);
		sceneOrder.RemoveAt(0);
	}
}
