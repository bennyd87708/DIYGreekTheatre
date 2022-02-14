using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
	public int slotNumber;
	public bool occupied;
	
    public void OnDrop(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null && !occupied)
		{
			eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
			eventData.pointerDrag.GetComponent<DragAndDrop>().slot = slotNumber;
			occupied = true;
		}
    }
}
