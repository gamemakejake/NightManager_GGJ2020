using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructScript : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instructions()
    {
        panel.SetActive(true);
    }

    public void Back()
    {
        panel.SetActive(false);
    }
}
