using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antagonist : MonoBehaviour
{
	public Sprite man1;
	public Sprite man2;
	public Sprite man3;
	public Sprite man4;
	public Sprite woman1;
	public Sprite woman2;
	public Sprite woman3;
	public Sprite woman4;
	
	
    // Start is called before the first frame update
    void Start()
    {
        switch(AntagonistSelect.antagonist)
		{
			case "woman1":
				GetComponent<SpriteRenderer>().sprite = woman1;
				break;
			case "woman2":
				GetComponent<SpriteRenderer>().sprite = woman2;
				break;
			case "woman3":
				GetComponent<SpriteRenderer>().sprite = woman3;
				break;
			case "woman4":
				GetComponent<SpriteRenderer>().sprite = woman4;
				break;
			case "man1":
				GetComponent<SpriteRenderer>().sprite = man1;
				break;
			case "man2":
				GetComponent<SpriteRenderer>().sprite = man2;
				break;
			case "man3":
				GetComponent<SpriteRenderer>().sprite = man3;
				break;
			case "man4":
				GetComponent<SpriteRenderer>().sprite = man4;
				break;
		}
    }
}
