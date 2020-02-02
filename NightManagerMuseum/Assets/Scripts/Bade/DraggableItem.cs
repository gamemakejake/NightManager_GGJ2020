using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    /*  This class does the following:
        >> OnDragStart: selects 'current piece' for AssemblyManager -> AssemblyManager
        >> OnDrag: moves piece to pointer transform, cannot move outside of Assembly window (offset by image size) -> AssemblyManager
    */

    Item itemRef;
    AssemblyManager manager;

    //public void SetAssemblyManager()
}
