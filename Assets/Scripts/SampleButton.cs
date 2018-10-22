using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour {
    public Button buttonComponent;
    public Text nameLabel;
    public Image iconImage;
    public Text priceText;

    private Item item;
    private ShopScrollList scrollList;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setup(Item currentItem, ShopScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        iconImage.sprite = item.icon;
        priceText.text = item.price.ToString();
        scrollList = currentScrollList;

    }
}
