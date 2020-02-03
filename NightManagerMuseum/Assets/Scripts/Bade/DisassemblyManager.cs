using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisassemblyManager : MonoBehaviour
{
    /*  This class does the following:
        >> Opens/closes disassembly menu
        >> Instantiates sculpture object in disassembly menu
        >> Denies disassembly to player if unable to disassemble object
    */

    public GameObject disassemblyMenu;
    public GameObject currentSculpture;
    public Transform sculptureSpawnPoint;
    public InventoryManager inventory;

    public void EnableDisassemblyMenu(Sculpture sculpture) {
        disassemblyMenu.SetActive(true);
        inventory.SetActiveInventoryMenu();
        inventory.SetActiveOpenCloseButton();
        currentSculpture = Instantiate(sculpture.sculptureToDisassemble, sculptureSpawnPoint);
    }

    public void EnableDisassemblyMenu(GameObject sculpture) {
        disassemblyMenu.SetActive(true);
        inventory.SetActiveInventoryMenu();
        inventory.SetActiveOpenCloseButton();
        currentSculpture = Instantiate(sculpture, sculptureSpawnPoint);
    }

    public void DisableDisassemblyMenu() {
        Destroy(currentSculpture);
        inventory.SetActiveInventoryMenu();
        inventory.SetActiveOpenCloseButton();
        disassemblyMenu.SetActive(false);
    }

    public void AddSculpturePieceToInventory(Image item) {
        Item itemToBeAdded = new Item(false); 
        itemToBeAdded.sprite = item.sprite;
        inventory.AddItemToInventory(itemToBeAdded);
        DisableDisassemblyMenu();
    }

    public void AttemptDisassembly(Sculpture sculpture) {
        if(sculpture.CheckIfMultipart()) {
            if(sculpture.GetDisassembled()) {
                //play error sound
                return;
            }

            EnableDisassemblyMenu(sculpture);
        }
    }
}
