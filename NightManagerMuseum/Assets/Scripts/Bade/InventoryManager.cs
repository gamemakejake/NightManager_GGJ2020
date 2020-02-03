using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    /*  This class does the following:
        >> Handles adding new items to inventory
        >> Handles open or closing inventory menu
        >> Allows other objects to get an array of current inventory items
    */

    public int maximumItems;
    public Sprite defaultImage;
    public GameObject inventorySlots;
    public Toggle openClose;
    public List<Button> itemButtons;

    List<Item> allItems;

    private void Start() {
        allItems = new List<Item>();
    }

    public Item GetItemFromInventory(int index) {
        return allItems[index];
    }

    public void SetActiveInventoryMenu() {
        inventorySlots.SetActive(!inventorySlots.activeInHierarchy);
    }

    public void SetActiveItemButtons(bool isActive) {
        for(int i = 0; i < itemButtons.Count; i++) {
            if(i < allItems.Count) itemButtons[i].interactable = isActive;
        }
    }

    public void SetActiveOpenCloseButton() {
        openClose.interactable = !openClose.interactable;
    }

    public void AddItemToInventory(Item newItem) {
        /*if(allItems == null) { 
            allItems = new Item[10];
            for(int i = 0; i < allItems.Length; i++) {
                allItems[i] = new Item(true);
            } 
        }
        else Debug.Log("Inventory exists. There are " + allItems.Length + " items");*/
        if(allItems.Count > 9) return;

        allItems.Add(newItem);
        RepopulateButtons();

        Debug.Log("Inventory exists. There are " + allItems.Count + " items");
        //return;
        
        /*for(int i = 0; i < allItems.Count; i++) {
            Debug.Log("Index: " + i + "; Empty? " + allItems[i].isEmpty);
            allItems.Add(newItem);
            itemButtons[i].GetComponent<Image>().sprite = allItems[i].sprite;
            return;
            Debug.Log("Iterating " + i);
        }*/

        //Debug.Log("No more room in inventory");
    }

    void RepopulateButtons() {
        for(int i = 0; i < itemButtons.Count; i++) {
            if(i < allItems.Count) {
                Debug.Log(allItems[i].sprite.name);
                itemButtons[i].GetComponent<Image>().sprite = allItems[i].sprite;
            }
            else itemButtons[i].GetComponent<Image>().sprite = defaultImage;
        }

        Debug.Log("Buttons repopulated. " + itemButtons.Count);
    }
}
