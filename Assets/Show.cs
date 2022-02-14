using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Show : MonoBehaviour
{
	public GameObject curtains_open;
	public GameObject curtains_close;
	public GameObject killButton;
	public GameObject talking;
	public AudioSource hit;
	public Sprite comedy;
	public Sprite tragedy;
	public Slider bar;
	public Image handle;
	public Image barbg;
	public Image fill;
	public GameObject curtains_closed;
	public static GameObject chatBubble;
	public Transform protagonist;
	public Transform antagonist;
	public Transform god;
	public Transform warrior;
	public SpriteRenderer basket;
	public Vector3 pPos;
	public Vector3 aPos;
	public Vector3 gPos;
	public Vector3 wPos;
	public Button cont;
	public string pN;
	public string aN;
	public string gN;
	public bool paused;
	public static bool comedyType = TypeSelect.comedy;
	public static int score = 0;
	public static int activeBubble = 0;
	public static bool night;
	public float speed;
	public float flashSpeed;
	public float timeLeft;
	public bool pGender;
	public bool aGender;
	public bool pFadeIn;
	public bool bFadeIn;
	public bool pFadeOut;
	public bool aFadeIn;
	public bool aFadeOut;
	public bool rFadeOut;
	public bool rFadeIn1;
	public bool rFadeIn2;
	public bool betFadeIn;
	public bool betFadeOut;
	public bool rotate;
	public bool flash;
	public bool flashIncrease;
	public Image fade;
	public TextMeshProUGUI te;
	public Color32 black;
	public Color32 blue;
	public Color32 toptextBefore;
	public Color32 toptextAfter;
	public Color32 bottomtextBefore;
	public Color32 bottomtextAfter;
	public Color white;
	public Color darkblue;
	public Color barAfter;
	public Color barBefore;
	public Color fillBefore;
	public Color fillAfter;
	
    void Start()
    {
		flashSpeed = 0.03f;
		rotate = false;
		night = false;
		timeLeft = 2.0f;
		black = new Color32(0, 0, 0, 255);
		blue = new Color32(12, 0, 255, 255);
		betFadeIn = false;
		betFadeOut = false;
		pFadeIn = false;
		pFadeOut = false;
		aFadeIn = false;
		aFadeOut = false;
		rFadeOut = false;
		flash = false;
		bFadeIn = false;
		flashIncrease = true;
		switch (AntagonistSelect.antagonist)
		{
			case "woman1":
				aGender = false;
				break;
			case "woman2":
				aGender = false;
				break;
			case "woman3":
				aGender = false;
				break;
			case "woman4":
				aGender = false;
				break;
			case "man1":
				aGender = true;
				break;
			case "man2":
				aGender = true;
				break;
			case "man3":
				aGender = true;
				break;
			case "man4":
				aGender = true;
				break;
		}
		
		switch (ProtagonistSelect.protagonist)
		{
			case "woman1":
				pGender = false;
				break;
			case "woman2":
				pGender = false;
				break;
			case "woman3":
				pGender = false;
				break;
			case "woman4":
				pGender = false;
				break;
			case "man1":
				pGender = true;
				break;
			case "man2":
				pGender = true;
				break;
			case "man3":
				pGender = true;
				break;
			case "man4":
				pGender = true;
				break;
		}
		
		speed = 0.03f;
		pPos = protagonist.localPosition;
		aPos = antagonist.localPosition;
		gPos = god.localPosition;
		wPos = warrior.localPosition;
		bar.value = score;
		if (score < 0)
		{
			handle.sprite = tragedy;
		} else {
			handle.sprite = comedy;
		}
		chatBubble = Resources.Load("chatbubble") as GameObject;
		pN = ProtagonistSelect.protagonistName;
		aN = AntagonistSelect.antagonistName;
		gN = God.godName;
		curtains_open.SetActive(true);
		curtains_close.SetActive(false);
		switch(SceneManager.GetActiveScene().buildIndex)
		{
			case 1:
				StartCoroutine(rejoice());
				break;
			case 2:
				StartCoroutine(catharsis());
				break;
			case 3:
				StartCoroutine(hubris());
				break;
			case 4:
				StartCoroutine(fall());
				break;
			case 5:
				StartCoroutine(betrayal());
				break;
			case 6:
				StartCoroutine(contest());
				break;
			case 7:
				StartCoroutine(background());
				break;
			case 8:
				StartCoroutine(introduction());
				break;
			case 9:
				StartCoroutine(deusexmachina());
				break;
		}
    }
	
	public void startTalking()
	{
		talking.GetComponent<AudioSource>().mute = false;
	}
	
	public void stopTalking()
	{
		talking.GetComponent<AudioSource>().mute = true;
	}
	
	IEnumerator def()
    {
        yield return new WaitForSeconds(5);
		
		pS("how bout you manifest some bitches");
		changeScore(50);
		
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pPos += new Vector3(-10f, 0f, 0f);
		flip(protagonist);
		yield return new WaitForSeconds(2);
		aS("what");
		changeScore(-100);
		
		yield return new WaitForUIButtons(cont).Reset();
		kill();
    
		closeCurtains();
		killButton.SetActive(true);
	}
	
	IEnumerator rejoice()
	{
		yield return new WaitForSeconds(5);
		speed = 0.004f;
		wPos += new Vector3(25f, 0f, 0f);
		
		for (int i = 0; i < 10; i++)
		{
			yield return new WaitForSeconds(1);
			wPos += new Vector3(0f, -0.05f, 0f);
			warrior.localPosition = warrior.localPosition + new Vector3(0f, -0.05f, 0f);
			yield return new WaitForSeconds(1);
			wPos += new Vector3(0f, 0.05f, 0f);
			warrior.localPosition = warrior.localPosition + new Vector3(0f, 0.05f, 0f);
			if (i == 6 || i == 7)
			{
				flip(antagonist);
			}
			if (i == 3)
			{
				gS("CHORUS:\nAnd so, they sailed on a boat...");
			}
			if (i == 6)
			{
				pS("CHORUS:\ntheir friendship holding it afloat...");
			}
		}
		changeScore(20);
		closeCurtains();
		yield return new WaitForSeconds(1);
		killButton.SetActive(true);
	}
	
	IEnumerator catharsis()
	{
		night = true;
		curtains_open.SetActive(false);
		betFadeIn = true;
		yield return new WaitForSeconds(10);
		
		speed = 0.0015f;
		pPos += new Vector3(25f, 0f, 0f);
		
		for (int i = 0; i < 17; i++)
		{
			yield return new WaitForSeconds(1);
			pPos += new Vector3(0f, -0.02f, 0f);
			protagonist.localPosition = protagonist.localPosition + new Vector3(0f, -0.02f, 0f);
			yield return new WaitForSeconds(1);
			pPos += new Vector3(0f, 0.02f, 0f);
			protagonist.localPosition = protagonist.localPosition + new Vector3(0f, 0.02f, 0f);
			if (i == 10)
			{
				speed = 0.0012f;
			}
			if (i == 8)
			{
				if (pGender)
				{
					gS("CHORUS:\nAnd so, away he floated...");
				}
				else
				{
					gS("CHORUS:\nAnd so, away she floated...");
				}
			}
			if (i == 13)
			{
				wS("CHORUS:\nfor this ending, we would not have voted...");
			}
		}
		
		changeScore(-20);
		closeCurtains();
		yield return new WaitForSeconds(5);
		betFadeOut = true;
		yield return new WaitForSeconds(2);
		killButton.SetActive(true);
	}
	
	IEnumerator hubris()
	{
		yield return new WaitForSeconds(5);
		speed = 0.007f;
		pPos += new Vector3(-11.5f, 0f, 0f);
		aPos += new Vector3(-11.5f, 0f, 0f);
			
		yield return new WaitForSeconds(7);
			
		pS("Ahh... The Mediterranean...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(protagonist);
		
		yield return new WaitForSeconds(2);
		
		aS("It really is beautiful...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		yield return new WaitForSeconds(2);
		pS("Oh how I would love to enjoy it from within...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("But alas, I don't know how to swim...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		yield return new WaitForSeconds(2);
		
		if (comedyType)
		{
			pS("Maybe someday I'll get a boat!");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
		}
		
		flip(protagonist);
		pPos += new Vector3(-11.5f, 0f, 0f);
		
		yield return new WaitForSeconds(3);
		aS("This gives me an idea...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		if (!comedyType)
		{
			yield return new WaitForSeconds(1);
			aS("MUAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA");
		}
		
		speed = 0.01f;
		aPos += new Vector3(-11.5f, 0f, 0f);
		yield return new WaitForSeconds(1);
		
		if (comedyType)
		{
			changeScore(20);
		}
		else
		{
			changeScore(-20);
		}
		
		closeCurtains();
		killButton.SetActive(true);
	}
	
	IEnumerator fall()
	{
		yield return new WaitForSeconds(3);
		speed = 0.005f;
		aPos = new Vector3(0f, -3.37f, 0f);
		
		yield return new WaitForSeconds(6);
		if (pGender)
		{
			aS("Who does he think he is?");
		}
		else
		{
			aS("Who does she think she is?");
		}
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		if (pGender)
		{
			aS("I'm glad to show him how we do things in this biz.");
		}
		else
		{
			aS("I'm glad to show her how we do things in this biz.");
		}
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		aS("I don't even care how long we've been friends...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		aS("Now I am certain that tonight is where this ends.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		if (pGender)
		{
			aS("Even though he's only ever been nice to me...");
		}
		else
		{
			aS("Even though she's only ever been nice to me...");
		}
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		if (pGender)
		{
			aS("He still must pay for drinking my iced tea!");
		}
		else
		{
			aS("She still must pay for drinking my iced tea!");
		}
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		aS("Even if this does not end up going well...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		aS("At least I can die knowing that I don't smell.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		aS("The clock is ticking, now I must away...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		flip(antagonist);
		
		aS("For tomorrow I will wish " + pN + " a happy death day!");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("MUAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA");
		yield return new WaitForSeconds(1);
		aPos = new Vector3(9.23f, -3.37f, 0f);
		yield return new WaitForSeconds(2);
		
		changeScore(-20);
		closeCurtains();
		killButton.SetActive(true);
	}
	
	IEnumerator betrayal()
	{
		flashSpeed = 0.06f;
		night = true;
		curtains_open.SetActive(false);
		betFadeIn = true;
		yield return new WaitForSeconds(10);
		
		speed = 0.007f;
		pPos += new Vector3(11.5f, 0f, 0f);
			
		yield return new WaitForSeconds(7);
			
		pS("What a beautiful night for a stroll...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		speed = 0.01f;
		aPos += new Vector3(6f, 0f, 0f);
		yield return new WaitForSeconds(4);
		
		flip(antagonist);
		yield return new WaitForSeconds(1);
		flip(antagonist);
		yield return new WaitForSeconds(2);
		
		speed = 0.003f;
		aPos += new Vector3(7.5f, 0f, 0f);
		yield return new WaitForSeconds(2);
		
		pS("doo... duh... doo...");
		yield return new WaitForSeconds(3);
		kill();
		yield return new WaitForSeconds(4);
		speed = 0.1f;
		yield return new WaitForSeconds(0.15f);
		flip(protagonist);
		flash = true;
		hit.Play();
		yield return new WaitForSeconds(0.15f);
		rotate = true;
		speed = 0.03f;
		aPos += new Vector3(-1f, 0f, 0f);
		yield return new WaitForSeconds(2);
		flip(antagonist);
		yield return new WaitForSeconds(0.5f);
		flip(antagonist);
		yield return new WaitForSeconds(2);
		flip(antagonist);
		aPos += new Vector3(-15f, 0f, 0f);
		yield return new WaitForSeconds(1);
		
		
		changeScore(-40);
		closeCurtains();
		yield return new WaitForSeconds(5);
		betFadeOut = true;
		yield return new WaitForSeconds(2);
		killButton.SetActive(true);
	}
	
	IEnumerator contest()
	{
		speed = 0.01f;
		yield return new WaitForSeconds(7);
		
		aPos = new Vector3(5.13f, -3.37f, 0f);
		
		yield return new WaitForSeconds(4);
		
		pS("Oh hello, " + aN);
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("Hi " + pN + ". Sorry I'm late. I lost track of time...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		
		pS("No worries at all.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		string[] words = new string[]{"turtles", "chocolate", "soup", "government"};
		pS("I've been studying the importance of " + words[Random.Range(0, words.Length)] + " in the mean time.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("Fascinating stuff.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		yield return new WaitForSeconds(2);
		aS("Have you noticed that guard over there?");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		yield return new WaitForSeconds(1);
		flip(protagonist);
		yield return new WaitForSeconds(2);
		
		pS("Looks very strong...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("Not as strong as me!");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		flip(protagonist);
		pS("You must be joking...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS(".....");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("I could take him.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("You couldn't.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("And it is a pointless hypothetical anyways...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("...because strength is meaningless in comparison to intellect.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("I disagree.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		string[] words2 = new string[]{"Trojans", "Spartans", "Persians"};
		aS("What good will your intellect be when the " + words2[Random.Range(0, words2.Length)] + " come knocking down our walls?");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("Perhaps it will provide us with superior weaponry.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("I still think raw strength matters more.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("Why don't you go test your theory with the help of that guard?");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		speed = 0.015f;
		aPos = new Vector3(-2f, -3.37f, 0f);
		yield return new WaitForSeconds(1);
		flip(protagonist);
		yield return new WaitForSeconds(3);
		
		speed = 0.03f;
		aPos = new Vector3(-2.83f, -3.37f, 0f);
		hit.Play();
		yield return new WaitForSeconds(0.15f);
		
		speed = 0.02f;
		wPos += new Vector3(-0.3f, 0f, 0f);
		aPos = new Vector3(-2f, -3.37f, 0f);
		yield return new WaitForSeconds(0.5f);
		
		flip(warrior);
		yield return new WaitForSeconds(1);
		
		if (aGender)
		{
			wS("Goodness sir! Please mind where your fists fly!");
		} else {
			wS("Goodness ma'am! Please mind where your fists fly!");
		}
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		wS("Or I'll have no choice but to remove you from this library.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("I apologize. That was stupid.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		flip(antagonist);
		speed = 0.01f;
		aPos = new Vector3(1.4f, -3.37f, 0f);
		yield return new WaitForSeconds(2f);
		
		flip(warrior);
		wPos += new Vector3(-5.0f, 0f, 0f);
		yield return new WaitForSeconds(1f);
		
		pS("Haha, you fool, you almost got kicked out!");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("I'll be exploring the geography section if you need me.");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("Otherwise, I'll see you at the beach later!");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		flip(protagonist);
		pPos += new Vector3(6f, 0f, 0f);
		yield return new WaitForSeconds(2f);
		
		flip(antagonist);
		yield return new WaitForSeconds(2f);
		
		if(comedyType)
		{
			aS(pN + " was right, that was an arrogant way of thinking...");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("I think I've learned to respect " + pN + "'s idea about intellect.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			if (pGender)
			{
				aS("I should go catch up with him...");
			} else {
				aS("I should go catch up with her...");
			}
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			flip(antagonist);
			aPos = new Vector3(9f, -3.37f, 0f);
			yield return new WaitForSeconds(2);
			changeScore(20);
		} else {
			aS("How dare " + pN + " mock me like this!?");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			if (pGender)
			{
				aS("He made a complete fool out of me!");
			} else {
				aS("She made a complete fool out of me!");
			}
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("I'll have my revenge!!");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("MUAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA");
			yield return new WaitForSeconds(2);
			aPos = new Vector3(-9f, -3.37f, 0f);
			yield return new WaitForSeconds(4);
			kill();
			changeScore(-20);
		}
		closeCurtains();
		killButton.SetActive(true);
	}
	
	IEnumerator background()
	{
		yield return new WaitForSeconds(5);
		//talking.GetComponent<AudioSource>().volume = 0.0f;
		if (!comedyType)
		{
			gS("CHORUS:\nWelcome, friends, to the land without end...");
			yield return new WaitForSeconds(3);
			
			wS("CHORUS:\nThe ocean and death are the closest of friends.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			pFadeIn = true;
			if (pGender)
			{
				gS("CHORUS:\nWe sing of his courage in magnificent song...");
				yield return new WaitForSeconds(3.5f);
				wS("CHORUS:\npay close attention, he won't be here long.");
			} else {
				gS("CHORUS:\nWe sing of her courage in magnificent song...");
				yield return new WaitForSeconds(3.5f);
				wS("CHORUS:\npay close attention, she won't be here long.");
			}
			yield return new WaitForSeconds(3);
			pFadeOut = true;
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			yield return new WaitForSeconds(3);
			aFadeIn = true;
			if (pGender)
			{
				gS("CHORUS:\nThe worst part about it, the killer is his friend...");
			} else {
				gS("CHORUS:\nThe worst part about it, the killer is her friend...");
			}
			yield return new WaitForSeconds(3.5f);
			wS("CHORUS:\nwhat an unfortunate way to meet one's own end.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			aFadeOut = true;
			yield return new WaitForSeconds(3);
			changeScore(-20);
		} else {
			gS("CHORUS:\nWelcome to all, sit back with your friends...");
			yield return new WaitForSeconds(3);
			
			wS("CHORUS:\nfor this is a story we truly recommend.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			pFadeIn = true;
			if (pGender)
			{
				gS("CHORUS:\nWe sing of his courage in this magnificent song...");
			} else {
				gS("CHORUS:\nWe sing of her courage in this magnificent song...");
			}
			yield return new WaitForSeconds(3.5f);
			wS("CHORUS:\npay close attention, for it's not very long.");
			yield return new WaitForSeconds(3);
			pFadeOut = true;
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			yield return new WaitForSeconds(3);
			aFadeIn = true;
			gS("CHORUS:\nThese two people, are really quite funny...");
			yield return new WaitForSeconds(3);
			wS("CHORUS:\nthank you again, for giving us your money.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			aFadeOut = true;
			yield return new WaitForSeconds(3);
			changeScore(20);
		}
		closeCurtains();
		//talking.GetComponent<AudioSource>().volume = 1.0f;
		killButton.SetActive(true);
	}
	
	IEnumerator introduction()
	{
		yield return new WaitForSeconds(5);
		speed = 0.03f;
		pS("Oh what a lovely day it is today!");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("Birds chirping, sun shining, blue skies...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		pS("If only my good friend " + aN + " was here to enjoy it too...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		flip(protagonist);
		if (aGender)
		{
			pS("I guess I'll go look for him!");
		} else {
			pS("I guess I'll go look for her!");
		}
		yield return new WaitForSeconds(3);
		pPos += new Vector3(-15f, 0f, 0f);
		yield return new WaitForSeconds(3);
		kill();
		
		speed = 0.01f;
		aPos += new Vector3(-10f, 0f, 0f);
		yield return new WaitForSeconds(2);
		
		aS("Hmmm...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		aS("I wonder where that bozo " + pN + " ran off to...");
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		flip(antagonist);
		yield return new WaitForSeconds(2);
		flip(antagonist);
		yield return new WaitForSeconds(2);
		if (pGender)
		{
			aS("I guess he's gone...");
		} else {
			aS("I guess she's gone...");
		}
		yield return new WaitForUIButtons(cont).Reset();
		kill();
		
		if (!comedyType)
		{
			if (pGender)
			{
				aS("I wonder if he's figured out my plans...");
			} else {
				aS("I wonder if she's figured out my plans...");
			}
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			flip(antagonist);
			aS("MUAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA");
			yield return new WaitForSeconds(2);
			aPos += new Vector3(10f, 0f, 0f);
			yield return new WaitForSeconds(2);
			kill();
			changeScore(-20);
		} else {
			aS("I wonder if we had any plans I've forgotten about...");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			flip(antagonist);
			aS("Better go double check!");
			yield return new WaitForSeconds(3);
			
			speed = 0.03f;
			aPos += new Vector3(10f, 0f, 0f);
			yield return new WaitForSeconds(2);
			kill();
			changeScore(20);
		}
		closeCurtains();
		killButton.SetActive(true);
	}
	
	IEnumerator deusexmachina()
	{
		if (comedyType)
		{
			protagonist.localPosition = new Vector3(9f, -3.37f, 0f);
			flip(protagonist);
			pPos = new Vector3(9f, -3.37f, 0f);
			antagonist.localPosition = new Vector3(14f, -3.37f, 0f);
			aPos = new Vector3(14f, -3.37f, 0f);
			speed = 0.01f;
			yield return new WaitForSeconds(5);
			
			pPos += new Vector3(-11.5f, 0f, 0f);
			aPos += new Vector3(-11.5f, 0f, 0f);
			
			yield return new WaitForSeconds(5);
			
			aS("We finally made it to the river!");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			flip(protagonist);
			pS("You were right, this is the perfect place for a picnic!");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("Can't wait to enjoy some delicious wine..!");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			pS("Wine..? I thought you said you brought honey.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("Wait a second...");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("I thought you were bringing the food!");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			pS("Oh no...");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			yield return new WaitForSeconds(2);
			flash = true;
			speed = 0.004f;
			god.localPosition = new Vector3(0f, 5.63f, 0f);
			gPos = new Vector3(0f, 5.63f, 0f);
			gPos += new Vector3(0f, -9f, 0f);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(1);
			aPos += new Vector3(0.3f, 0f, 0f);
			pPos += new Vector3(-0.3f, 0f, 0f);
			yield return new WaitForSeconds(1);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			rFadeOut = true;
			yield return new WaitForSeconds(2);
			
			ggS("It is I, the benevolent " + God.godGender + " " + God.godName + ".");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			flip(god);
			ggS("I sympathize with your lack of snack.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			flip(god);
			ggS("That is why I have brought you a picnic basket full of snacks.");
			aPos += new Vector3(1f, 0f, 0f);
			yield return new WaitForSeconds(2);
			bFadeIn = true;
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			aS("Wow! Thank you!");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			flip(god);
			pS("Did you bring honey or wine?");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			ggS("Yes.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			flip(god);
			ggS("Now, away!");
			rFadeIn1 = true;
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			flip(god);
			
			gPos += new Vector3(0f, 9f, 0f);
			
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flash = true;
			changeScore(20);
		}
		else
		{
			speed = 0.004f;
			protagonist.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
			yield return new WaitForSeconds(5);
			
			aS("It's all over for me now...");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("I've done it, but at what cost...");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			yield return new WaitForSeconds(2);
			flash = true;
			gPos += new Vector3(0f, -9f, 0f);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(1);
			aPos += new Vector3(0.3f, 0f, 0f);
			yield return new WaitForSeconds(1);
			flip(god);
			yield return new WaitForSeconds(2);
			flip(god);
			yield return new WaitForSeconds(2);
			rFadeOut = true;
			yield return new WaitForSeconds(2);
			
			ggS("It is I, the benevolent " + God.godGender + " " + God.godName + ".");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			ggS("I sympathize with you, even though you are a murderer.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			ggS("That is why I have arrived to take you away.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("Wow! Thank you!");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			aS("Does this mean my crimes are absolved?");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			ggS("Yes.");
			yield return new WaitForUIButtons(cont).Reset();
			kill();
			
			ggS("Now, let us away!");
			rFadeIn1 = true;
			rFadeIn2 = true;
			yield return new WaitForSeconds(3);
			kill();
			flip(god);
			
			gPos += new Vector3(0f, 9f, 0f);
			aPos += new Vector3(0f, 9f, 0f);
			
			yield return new WaitForSeconds(2);
			flip(god);
			flip(antagonist);
			yield return new WaitForSeconds(2);
			flip(god);
			flip(antagonist);
			yield return new WaitForSeconds(2);
			flip(god);
			flip(antagonist);
			yield return new WaitForSeconds(2);
			flip(god);
			flip(antagonist);
			yield return new WaitForSeconds(2);
			flip(god);
			flip(antagonist);
			yield return new WaitForSeconds(2);
			flash = true;
			changeScore(-20);
		}
		closeCurtains();
		killButton.SetActive(true);
	}
	
	void kill()
	{
		stopTalking();
		foreach(var bubble in GameObject.FindGameObjectsWithTag("chat")){
			Destroy(bubble);
		}
	}
	
	public void closeCurtains()
	{
		curtains_open.SetActive(false);
		curtains_close.SetActive(true);
	}
	
	public void pS(string s)
	{
		activeBubble += 1;
		startTalking();
		ChatBubble.Create(protagonist, new Vector2(0.265f, 0.312f), s, activeBubble, black);
	}
	
	public void aS(string s)
	{
		activeBubble += 1;
		startTalking();
		ChatBubble.Create(antagonist, new Vector2(0.265f, 0.312f), s, activeBubble, black);
	}
	
	public void gS(string s)
	{
		activeBubble += 1;
		startTalking();
		ChatBubble.Create(god, new Vector2(0.3f, 0.4f), s, activeBubble, black);
	}
	
	public void ggS(string s)
	{
		activeBubble += 1;
		startTalking();
		ChatBubble.Create(god, new Vector2(0.3f, 0.4f), s, activeBubble, blue);
	}
	
	public void wS(string s)
	{
		activeBubble += 1;
		startTalking();
		ChatBubble.Create(warrior, new Vector2(0.265f, 0.312f), s, activeBubble, black);
	}
	
	public void changeScore(int amount)
	{
		if (score + amount > 100)
		{
			score = 100;
		} else if (score + amount < -100) {
			score = -100;
		} else {
			score += amount;
		}
		if (score < 0)
		{
			handle.sprite = tragedy;
		} else {
			handle.sprite = comedy;
		}
	}
	
	void flip(Transform t)
	{
		t.localScale = new Vector3(-t.localScale.x, t.localScale.y, t.localScale.z);
	}
	
	void FixedUpdate()
	{
		if (score != bar.value)
		{
			bar.value = Mathf.Lerp(bar.value, score, 20 * Time.deltaTime);
		}
		if (aPos != antagonist.localPosition)
		{
			antagonist.localPosition = Vector3.MoveTowards(antagonist.localPosition, aPos, 4 * speed);
		}
		if (pPos != protagonist.localPosition)
		{
			protagonist.localPosition = Vector3.MoveTowards(protagonist.localPosition, pPos, 4 * speed);
		}
		if (gPos != god.localPosition)
		{
			god.localPosition = Vector3.MoveTowards(god.localPosition, gPos, 4 * speed);
		}
		if (wPos != antagonist.localPosition)
		{
			warrior.localPosition = Vector3.MoveTowards(warrior.localPosition, wPos, 4 * speed);
		}
		if (pFadeIn)
		{
			if (protagonist.GetComponent<SpriteRenderer>().color.a < 1.0f)
			{
				protagonist.GetComponent<SpriteRenderer>().color = new Color(protagonist.GetComponent<SpriteRenderer>().color.r, protagonist.GetComponent<SpriteRenderer>().color.g, protagonist.GetComponent<SpriteRenderer>().color.b, protagonist.GetComponent<SpriteRenderer>().color.a + 0.008f);
			} else {
				pFadeIn = false;
			}
		}
		if (pFadeOut)
		{
			if (protagonist.GetComponent<SpriteRenderer>().color.a > 0.0f)
			{
				protagonist.GetComponent<SpriteRenderer>().color = new Color(protagonist.GetComponent<SpriteRenderer>().color.r, protagonist.GetComponent<SpriteRenderer>().color.g, protagonist.GetComponent<SpriteRenderer>().color.b, protagonist.GetComponent<SpriteRenderer>().color.a - 0.008f);
			} else {
				pFadeOut = false;
			}
		}
		if (aFadeIn)
		{
			if (antagonist.GetComponent<SpriteRenderer>().color.a < 1.0f)
			{
				antagonist.GetComponent<SpriteRenderer>().color = new Color(antagonist.GetComponent<SpriteRenderer>().color.r, antagonist.GetComponent<SpriteRenderer>().color.g, antagonist.GetComponent<SpriteRenderer>().color.b, antagonist.GetComponent<SpriteRenderer>().color.a + 0.008f);
			} else {
				aFadeIn = false;
			}
		}
		if (aFadeOut)
		{
			if (antagonist.GetComponent<SpriteRenderer>().color.a > 0.0f)
			{
				antagonist.GetComponent<SpriteRenderer>().color = new Color(antagonist.GetComponent<SpriteRenderer>().color.r, antagonist.GetComponent<SpriteRenderer>().color.g, antagonist.GetComponent<SpriteRenderer>().color.b, antagonist.GetComponent<SpriteRenderer>().color.a - 0.008f);
			} else {
				aFadeOut = false;
			}
		}
		if (flash)
		{
			if (flashIncrease)
			{
				if (fade.color.a < 1.0f)
				{
					fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a + (flashSpeed * 4));
				}
				else
				{
					flashIncrease = false;
				}
			}
			else
			{
				if (fade.color.a > 0.0f)
				{
					fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fade.color.a - (flashSpeed * 4));
				}
				else
				{
					flash = false;
					flashIncrease = true;
				}
			}
		}
		if (rFadeOut)
		{
			if (god.Find("rope").GetComponent<SpriteRenderer>().color.a > 0.0f)
			{
				god.Find("rope").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, god.Find("rope").GetComponent<SpriteRenderer>().color.a - 0.02f);
			} else {
				rFadeOut = false;
			}
		}
		if (rFadeIn1)
		{
			if (god.Find("rope").GetComponent<SpriteRenderer>().color.a < 1.0f)
			{
				god.Find("rope").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, god.Find("rope").GetComponent<SpriteRenderer>().color.a + 0.02f);
			} else {
				rFadeIn1 = false;
			}
		}
		if (rFadeIn2)
		{
			if (antagonist.Find("rope").GetComponent<SpriteRenderer>().color.a < 1.0f)
			{
				antagonist.Find("rope").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, god.Find("rope").GetComponent<SpriteRenderer>().color.a + 0.02f);
			} else {
				rFadeIn2 = false;
			}
		}
		if (bFadeIn)
		{
			if (basket.color.a < 1.0f)
			{
				basket.color = new Color(1f, 1f, 1f, basket.color.a + 0.02f);
			} else {
				bFadeIn = false;
			}
		}
		if (betFadeIn)
		{
			if (timeLeft <= Time.deltaTime)
			{
				curtains_closed.GetComponent<SpriteRenderer>().color = darkblue;
				barbg.color = barAfter;
				fill.color = fillAfter;
				handle.color = darkblue;
				te.colorGradient = new VertexGradient(toptextAfter, toptextAfter, bottomtextAfter, bottomtextAfter);
				
				timeLeft = 2.0f;
				betFadeIn = false;
				curtains_closed.SetActive(false);
				curtains_open.SetActive(true);
			}
			else
			{
				curtains_closed.GetComponent<SpriteRenderer>().color = Color.Lerp(curtains_closed.GetComponent<SpriteRenderer>().color, darkblue, Time.deltaTime / timeLeft);
				barbg.color = Color.Lerp(barbg.color, barAfter, Time.deltaTime / timeLeft);
				fill.color = Color.Lerp(fill.color, fillAfter, Time.deltaTime / timeLeft);
				handle.color = Color.Lerp(handle.color, darkblue, Time.deltaTime / timeLeft);
				te.colorGradient = new VertexGradient(Color.Lerp(te.colorGradient.topLeft, toptextAfter, Time.deltaTime / timeLeft), Color.Lerp(te.colorGradient.topLeft, toptextAfter, Time.deltaTime / timeLeft), Color.Lerp(te.colorGradient.bottomLeft, bottomtextAfter, Time.deltaTime / timeLeft), Color.Lerp(te.colorGradient.bottomLeft, bottomtextAfter, Time.deltaTime / timeLeft));
				timeLeft -= Time.deltaTime;
			}
		}
		if (betFadeOut)
		{
			if (timeLeft <= Time.deltaTime)
			{
				curtains_close.GetComponent<SpriteRenderer>().color = white;
				barbg.color = barBefore;
				fill.color = fillBefore;
				handle.color = white;
				te.colorGradient = new VertexGradient(toptextBefore, toptextBefore, bottomtextBefore, bottomtextBefore);
				
				timeLeft = 2.0f;
				betFadeOut = false;
			}
			else
			{
				curtains_close.GetComponent<SpriteRenderer>().color = Color.Lerp(curtains_close.GetComponent<SpriteRenderer>().color, white, Time.deltaTime / timeLeft);
				barbg.color = Color.Lerp(barbg.color, barBefore, Time.deltaTime / timeLeft);
				fill.color = Color.Lerp(fill.color, fillBefore, Time.deltaTime / timeLeft);
				handle.color = Color.Lerp(handle.color, white, Time.deltaTime / timeLeft);
				te.colorGradient = new VertexGradient(Color.Lerp(te.colorGradient.topLeft, toptextBefore, Time.deltaTime / timeLeft), Color.Lerp(te.colorGradient.topLeft, toptextBefore, Time.deltaTime / timeLeft), Color.Lerp(te.colorGradient.bottomLeft, bottomtextBefore, Time.deltaTime / timeLeft), Color.Lerp(te.colorGradient.bottomLeft, bottomtextBefore, Time.deltaTime / timeLeft));
				timeLeft -= Time.deltaTime;
			}
		}
		if (rotate)
		{
			if (protagonist.rotation.z > -0.7071068f)
			{
				protagonist.Rotate(0, 0, -12f);
			} else {
				rotate = false;
			}
		}
	}
}
