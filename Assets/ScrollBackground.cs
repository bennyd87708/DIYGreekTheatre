using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
	
	public float speed = 0.04f;
	
    void FixedUpdate()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
		
		GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
