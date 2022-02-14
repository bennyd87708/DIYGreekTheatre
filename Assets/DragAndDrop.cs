using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	public Canvas canvas;
	
	public GameObject slot1;
	public GameObject slot2;
	public GameObject slot3;
	public GameObject slot4;
	public GameObject slot5;
	public GameObject slot6;
	public GameObject slot7;
	public GameObject slot8;
	public GameObject slot9;
	public GameObject slot11;
	public GameObject slot12;
	public GameObject slot13;
	public GameObject slot14;
	public GameObject slot15;
	
	private RectTransform rectTransform;
	private CanvasGroup canvasGroup;
	private Vector3 lastPosition;
	public int slot;
	public int lastSlot;
	
	void Start()
	{
		switch (slot)
			{
				case 1:
					rectTransform.anchoredPosition = slot1.GetComponent<RectTransform>().anchoredPosition;
					slot1.GetComponent<ItemSlot>().occupied = true;
					break;
				case 2:
					rectTransform.anchoredPosition = slot2.GetComponent<RectTransform>().anchoredPosition;
					slot2.GetComponent<ItemSlot>().occupied = true;
					break;
				case 3:
					rectTransform.anchoredPosition = slot3.GetComponent<RectTransform>().anchoredPosition;
					slot3.GetComponent<ItemSlot>().occupied = true;
					break;
				case 4:
					rectTransform.anchoredPosition = slot4.GetComponent<RectTransform>().anchoredPosition;
					slot4.GetComponent<ItemSlot>().occupied = true;
					break;
				case 5:
					rectTransform.anchoredPosition = slot5.GetComponent<RectTransform>().anchoredPosition;
					slot5.GetComponent<ItemSlot>().occupied = true;
					break;
				case 6:
					rectTransform.anchoredPosition = slot6.GetComponent<RectTransform>().anchoredPosition;
					slot6.GetComponent<ItemSlot>().occupied = true;
					break;
				case 7:
					rectTransform.anchoredPosition = slot7.GetComponent<RectTransform>().anchoredPosition;
					slot7.GetComponent<ItemSlot>().occupied = true;
					break;
				case 8:
					rectTransform.anchoredPosition = slot8.GetComponent<RectTransform>().anchoredPosition;
					slot8.GetComponent<ItemSlot>().occupied = true;
					break;
				case 9:
					rectTransform.anchoredPosition = slot9.GetComponent<RectTransform>().anchoredPosition;
					slot9.GetComponent<ItemSlot>().occupied = true;
					break;
				case 11:
					rectTransform.anchoredPosition = slot11.GetComponent<RectTransform>().anchoredPosition;
					slot11.GetComponent<ItemSlot>().occupied = true;
					break;
				case 12:
					rectTransform.anchoredPosition = slot12.GetComponent<RectTransform>().anchoredPosition;
					slot12.GetComponent<ItemSlot>().occupied = true;
					break;
				case 13:
					rectTransform.anchoredPosition = slot13.GetComponent<RectTransform>().anchoredPosition;
					slot13.GetComponent<ItemSlot>().occupied = true;
					break;
				case 14:
					rectTransform.anchoredPosition = slot14.GetComponent<RectTransform>().anchoredPosition;
					slot14.GetComponent<ItemSlot>().occupied = true;
					break;
				case 15:
					rectTransform.anchoredPosition = slot15.GetComponent<RectTransform>().anchoredPosition;
					slot15.GetComponent<ItemSlot>().occupied = true;
					break;
			}
	}
	
	private void Awake() {
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (slot != 0)
		{
			switch (slot)
			{
				case 1:
					slot1.GetComponent<ItemSlot>().occupied = false;
					break;
				case 2:
					slot2.GetComponent<ItemSlot>().occupied = false;
					break;
				case 3:
					slot3.GetComponent<ItemSlot>().occupied = false;
					break;
				case 4:
					slot4.GetComponent<ItemSlot>().occupied = false;
					break;
				case 5:
					slot5.GetComponent<ItemSlot>().occupied = false;
					break;
				case 6:
					slot6.GetComponent<ItemSlot>().occupied = false;
					break;
				case 7:
					slot7.GetComponent<ItemSlot>().occupied = false;
					break;
				case 8:
					slot8.GetComponent<ItemSlot>().occupied = false;
					break;
				case 9:
					slot9.GetComponent<ItemSlot>().occupied = false;
					break;
				case 11:
					slot11.GetComponent<ItemSlot>().occupied = false;
					break;
				case 12:
					slot12.GetComponent<ItemSlot>().occupied = false;
					break;
				case 13:
					slot13.GetComponent<ItemSlot>().occupied = false;
					break;
				case 14:
					slot14.GetComponent<ItemSlot>().occupied = false;
					break;
				case 15:
					slot15.GetComponent<ItemSlot>().occupied = false;
					break;
			}
		}
		lastSlot = slot;
		slot = 0;
		canvasGroup.alpha = 0.6f;
		canvasGroup.blocksRaycasts = false;
		lastPosition = rectTransform.anchoredPosition;
	}
	
	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}
	
	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.alpha = 1.0f;
		canvasGroup.blocksRaycasts = true;
		if (slot == 0)
		{
			rectTransform.anchoredPosition = lastPosition;
			slot = lastSlot;
			switch (slot)
			{
				case 1:
					slot1.GetComponent<ItemSlot>().occupied = true;
					break;
				case 2:
					slot2.GetComponent<ItemSlot>().occupied = true;
					break;
				case 3:
					slot3.GetComponent<ItemSlot>().occupied = true;
					break;
				case 4:
					slot4.GetComponent<ItemSlot>().occupied = true;
					break;
				case 5:
					slot5.GetComponent<ItemSlot>().occupied = true;
					break;
				case 6:
					slot6.GetComponent<ItemSlot>().occupied = true;
					break;
				case 7:
					slot7.GetComponent<ItemSlot>().occupied = true;
					break;
				case 8:
					slot8.GetComponent<ItemSlot>().occupied = true;
					break;
				case 9:
					slot9.GetComponent<ItemSlot>().occupied = true;
					break;
				case 11:
					slot11.GetComponent<ItemSlot>().occupied = true;
					break;
				case 12:
					slot12.GetComponent<ItemSlot>().occupied = true;
					break;
				case 13:
					slot13.GetComponent<ItemSlot>().occupied = true;
					break;
				case 14:
					slot14.GetComponent<ItemSlot>().occupied = true;
					break;
				case 15:
					slot15.GetComponent<ItemSlot>().occupied = true;
					break;
			}
		}
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
