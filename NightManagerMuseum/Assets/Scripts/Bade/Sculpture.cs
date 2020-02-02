using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sculpture : MonoBehaviour
{
    public GameObject sculptureToDisassemble;
    public Sprite[] sprites; 
    bool isDisassembled;

    public void SetDisassembled() {
        isDisassembled = true;
    }

    public bool GetDisassembled() {
        return isDisassembled;
    }

    public bool CheckIfMultipart() {
        return sculptureToDisassemble != null;
    }
}
