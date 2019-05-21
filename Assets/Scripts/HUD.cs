using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Inventory Inventory;

	// Use this for initialization
	void Start () {
        Inventory.ItemRemoved += Inventory_ItemRemoved;
	}
	

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform invetoryPanel = transform.Find("Scroll View");
        foreach (Transform slot in invetoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image =imageTransform.GetComponent<Image>();
            Drag itemDragHandler = imageTransform.GetComponent<Drag>();

            if (itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;

                break;
            }
        }
    }
}
