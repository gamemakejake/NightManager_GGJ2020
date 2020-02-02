using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblyManager : MonoBehaviour
{
    /*  This class does the following:
        >> Opens/closes assembly menu
        >> Enables items to be added to assembly window [click to add to window; adds to list of objects on statue]
        >> Modifies currently selected DraggableItem
        >> Mirror, Lock, and Rotate functions on current DraggableItem
    */

    public int maximumItems;
    public GameObject assemblyMenu;
    public Button backButton;
    public Button lockButton;
    public Button mirrorHorzButton;
    public Button mirrorVertButton;
    public Button rotateLeftButton;
    public Button rotateRightButton;
    public InventoryManager inventory;

    Item[] items;
    DraggableItem currentDraggableItem;

    //public void AddItemToAssemblyFromInventory(int index)
    //public void MirrorHorizontally()
    //public void MirrorVertically()
    //public void RotateLeft()
    //public void RotateRight()
    //public void LockCurrentItem()
    //public void SetCurrentItem(DraggableItem newItem)
    //public void MoveCurrentItem()
}
