using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    void Start()
    {
		if (TypeSelect.comedy)
		{
			gameObject.GetComponent<TextMeshProUGUI>().text = Show.score.ToString();
		}
		else
		{
			gameObject.GetComponent<TextMeshProUGUI>().text = (-1 * Show.score).ToString();
		}        
    }
}
