using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    
    public Sprite sprite;
    public bool isUsed = false;

    public Item(Sprite sprite) {
        this.sprite = sprite;
    }
}
