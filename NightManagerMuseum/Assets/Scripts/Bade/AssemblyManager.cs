using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AssemblyManager : MonoBehaviour
{
    /*  This class does the following:
        >> Opens/closes assembly menu
        >> Enables items to be added to assembly window [click to add to window; adds to list of objects on statue]
        >> Modifies currently selected DraggableItem
        >> Mirror, Lock, and Rotate functions on current DraggableItem
    */

    public int maximumItems;
    public DraggableItem draggableItemRef;
    public Image lockedImageRef;
    public GameObject assemblyMenu;
    public Transform itemSpawnPoint;
    public Transform newSculpturePoint;
    public Rect dropArea;
    public Button backButton;
    public Button lockButton;
    public Button mirrorHorzButton;
    public Button mirrorVertButton;
    public Button rotateLeftButton;
    public Button rotateRightButton;
    public InventoryManager inventory;

    Item[] items;
    DraggableItem currentDraggableItem;
    List<DraggableItem> allDragItems;
    List<Image> allImages;

    public void SetActiveAssemblyMenu() {
        assemblyMenu.SetActive(!assemblyMenu.activeInHierarchy);
    }

    public void AddItemToAssemblyFromInventory(int index) {
        if(allDragItems == null) allDragItems = new List<DraggableItem>();
        
        Item item = inventory.GetItemFromInventory(index);
        inventory.itemButtons[index].interactable = false;
        item.isUsed = true;

        DraggableItem dragItem = Instantiate(draggableItemRef, itemSpawnPoint);
        dragItem.SetItemRef(item);
        dragItem.Initialize();
        allDragItems.Add(dragItem);
        SetCurrentItem(dragItem);
    }

    public void SetCurrentItem(DraggableItem dragItem) {
        if(currentDraggableItem != null) {
            currentDraggableItem.SetActiveOutline(false);
        }

        currentDraggableItem = dragItem;
        currentDraggableItem.SetActiveOutline(true);
    }

    public void MirrorHorizontally() {
        currentDraggableItem.FlipImage(-1, 1);
    }

    public void MirrorVertically() {
        currentDraggableItem.FlipImage(1, -1);
    }
    
    public void RotateLeft() {
        currentDraggableItem.RotateImage(-1);
    }
    
    public void RotateRight() {
        currentDraggableItem.RotateImage(1);
    }

    public void LockCurrentItem() {
        if(allImages == null) allImages = new List<Image>();
        allDragItems.Remove(currentDraggableItem);

        var lockedSprite = Instantiate(lockedImageRef, newSculpturePoint);
        lockedImageRef.GetComponent<RectTransform>().sizeDelta = currentDraggableItem.image.GetComponent<RectTransform>().sizeDelta;
        allImages.Add(lockedSprite);

        Destroy(currentDraggableItem);
    }

    public void MoveCurrentItemToPointer(PointerEventData eventData) {
        var mousePos = eventData.position;
        var rect = currentDraggableItem.GetComponent<RectTransform>();
        if(!dropArea.Overlaps(new Rect(mousePos.x, mousePos.y, rect.sizeDelta.x, rect.sizeDelta.y))) {
            currentDraggableItem.transform.position = mousePos;
        }
    }
}
