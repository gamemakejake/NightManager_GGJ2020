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
    public GameObject inventorySlots;
    public Toggle openClose;
    public Button[] itemButtons;

    Item[] allItems;

    public void Start() {
        allItems = new Item[maximumItems];
    }

    public void SetActiveInventoryMenu() {
        inventorySlots.SetActive(!inventorySlots.activeInHierarchy);
    }

    public void SetActiveItemButtons(bool isActive) {
        for(int i = 0; i < itemButtons.Length; i++) {
            if(allItems[i] != null) itemButtons[i].interactable = isActive;
        }
    }

    public void SetActiveOpenCloseButton() {
        openClose.interactable = !openClose.interactable;
    }

    public void AddItemToInventory(Item newItem) {
        for(int i = 0; i < allItems.Length; i++) {
            if(allItems[i] == null) {
                allItems[i] = newItem;
                return;
            }
        }

        Debug.Log("No more room in inventory");
    }
}
