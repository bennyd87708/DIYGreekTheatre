using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour
{
	private SpriteRenderer backgroundSpriteRenderer;
	private TextMeshPro textMeshPro;
	private RectTransform textTransform;
	private Color32 textColor;
	
	public static void Create(Transform parent, Vector2 localPosition, string text, int number, Color32 c)
	{
		Transform chatBubbleTransform = Instantiate(Show.chatBubble, parent).GetComponent<Transform>();
		chatBubbleTransform.localPosition = localPosition;
		chatBubbleTransform.localScale /= parent.localScale.y;
		chatBubbleTransform.GetComponent<ChatBubble>().Setup(text, number, c);
		if (parent.localScale.x < 0)
		{
			chatBubbleTransform.GetComponent<ChatBubble>().Flip();
		}
	}
	
    private void Awake()
	{
		backgroundSpriteRenderer = transform.Find("background").GetComponent<SpriteRenderer>();
		textTransform = transform.Find("text").GetComponent<RectTransform>();
		textMeshPro = transform.Find("text").GetComponent<TextMeshPro>();
	}
	
	private void Setup(string text, int id, Color32 c)
	{
		textColor = c;
		textMeshPro.SetText(text);
		textMeshPro.ForceMeshUpdate();
		Vector2 textSize = textMeshPro.GetRenderedValues(false);
		
		Vector2 padding = new Vector2(0.05f, 0.1f);
		backgroundSpriteRenderer.size = (textSize / 7) + padding;
		if (Show.night)
		{
			backgroundSpriteRenderer.color = new Color32(14, 23, 69, 255);
		}
		textTransform.sizeDelta = (textSize) + new Vector2(0.06f, 0.15f);
		textMeshPro.ForceMeshUpdate();
		
		textMeshPro.color = new Color32(0, 0, 0, 0);
		TextWriter.AddWriter_Static(textMeshPro, id, text, .05f, true, true, () => { });
		StartCoroutine(waitOneFrame());
	}
	
	IEnumerator waitOneFrame()
	{
		yield return 0;
		textMeshPro.color = textColor;
	}
	
	public void Flip()
	{
		textTransform.localScale = new Vector3(-1, 1, 1);
		textTransform.anchoredPosition = textTransform.anchoredPosition + new Vector2(textTransform.sizeDelta.x, 0);
	}
}
