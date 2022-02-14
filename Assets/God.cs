using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class God : MonoBehaviour
{
    public Sprite[] maleSprites;
    public Sprite[] femaleSprites;
	public static string godGender;
	public static string godName;
	public static Sprite godSprite;
	
    void Start()
    {
		if (!(godGender == "God" || godGender == "Goddess"))
		{
			if (SceneManager.GetActiveScene().buildIndex == 10)
			{
				gameObject.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0f);
			}
			if (Random.value > 0.5f)
			{
				godGender = "God";
				godSprite = maleSprites[Random.Range(0, maleSprites.Length)];
				godName = godSprite.name;
			}
			else
			{
				godGender = "Goddess";
				godSprite = femaleSprites[Random.Range(0, femaleSprites.Length)];
				godName = godSprite.name;
			}
		}
		GetComponent<SpriteRenderer>().sprite = godSprite;
    }
}
