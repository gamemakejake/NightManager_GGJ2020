using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterParts : MonoBehaviour
{
    public GameObject[] parts;
    // Start is called before the first frame update
    void Start()
    {
        if (parts == null)
        {
            parts = GameObject.FindGameObjectsWithTag("CenterPiece");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(parts[Random.Range(0, 5)]);
            Destroy(parts[Random.Range(0, 5)]);
        }
    }
}
