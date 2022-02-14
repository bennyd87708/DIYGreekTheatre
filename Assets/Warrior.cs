using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warrior : MonoBehaviour
{
    public Sprite[] sprites;
	public static Sprite warrior;
	
    void Start()
    {
		if (warrior == null)
		{
			if (SceneManager.GetActiveScene().buildIndex == 10)
			{
				gameObject.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0f);
			}
			warrior = sprites[Random.Range(0, sprites.Length)];
		}
		GetComponent<SpriteRenderer>().sprite = warrior;
    }
}
