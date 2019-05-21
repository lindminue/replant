using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag :  MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    public  IInventoryItem Item { get; set; }
	//private Vector3 prevPos;

	private Transform canvasTran;
	private GameObject draggingObject;

	public GameObject Flower;

	void Awake()
	{
		canvasTran = transform.parent.parent;
	}   
	//ドラック開始
	public void OnBeginDrag(PointerEventData eventData){
		//Debug.Log ("dragStart");
		CreateDragObject();
		draggingObject.transform.position = eventData.position;
	}
	//ドラック中
	public void OnDrag(PointerEventData eventData){
		//Debug.Log ("dragging");
		draggingObject.transform.position = eventData.position;
	}
	//ドラック終了
	public void OnEndDrag(PointerEventData eventData){
		//Debug.Log ("dragEnd");
		gameObject.GetComponent<Image>().color = Vector4.one;
		Destroy(draggingObject);
	}
	private void CreateDragObject()
	{
		draggingObject = new GameObject("Dragging Object");
		draggingObject.transform.SetParent(canvasTran);
		draggingObject.transform.SetAsLastSibling();
		draggingObject.transform.localScale = Vector3.one;

		// レイキャストがブロックされないように
		CanvasGroup canvasGroup = draggingObject.AddComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;

		Image draggingImage = draggingObject.AddComponent<Image>();
		Image sourceImage = GetComponent<Image>();

		draggingImage.sprite = sourceImage.sprite;
		draggingImage.rectTransform.sizeDelta = sourceImage.rectTransform.sizeDelta;
		draggingImage.color = sourceImage.color;
		draggingImage.material = sourceImage.material;

		gameObject.GetComponent<Image>().color = Vector4.one * 0.6f;
	}
}
