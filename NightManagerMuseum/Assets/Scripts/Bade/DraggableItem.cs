using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    /*  This class does the following:
        >> OnDragStart: selects 'current piece' for AssemblyManager -> AssemblyManager
        >> OnDrag: moves piece to pointer transform, cannot move outside of Assembly window (offset by image size) -> AssemblyManager
    */

    public Image outline;
    public Image image;

    Item itemRef;
    AssemblyManager manager;

    public void Initialize() {
        image.sprite = itemRef.sprite;
        image.GetComponent<RectTransform>().sizeDelta = new Vector2(image.sprite.texture.height, image.sprite.texture.width); 

        //outline.sprite = itemRef.sprite;
        outline.GetComponent<RectTransform>().sizeDelta = image.GetComponent<RectTransform>().sizeDelta;
    }

    public void SetItemRef(Item itemRef) {
        this.itemRef = itemRef;
    }

    public void SetAssemblyManager(AssemblyManager manager) {
        this.manager = manager;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if(manager != null) {
            manager.SetCurrentItem(this);
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if(manager != null) {
            manager.MoveCurrentItemToPointer(eventData);
        }
    }

    public void SetActiveOutline(bool isActive) {
        outline.enabled = isActive;
    }

    public void FlipImage(int horz, int vert) {
        var scale = image.transform.localScale;
        image.transform.localScale = new Vector2(scale.x * horz, scale.y * vert);
    }

    public void RotateImage(int axis) {
        var newRot = image.transform.localRotation.eulerAngles.z + (45f * axis);
        image.transform.localRotation = Quaternion.Euler(0, 0, newRot);
    }
}
