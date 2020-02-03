using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour
{
    public GameObject[] parts;
    //bool[] check = new bool[6];
    // Start is called before the first frame update
    void Start()
    {

        if (parts == null)
        {
            parts = GameObject.FindGameObjectsWithTag("Body");
        }
        
        //setActive();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(parts[Random.Range(0, 5)]);//isDeleted(Random.Range(0, 5))
            Destroy(parts[Random.Range(0, 5)]);//isDeleted(Random.Range(0, 5))
        }

    }

    //void setActive()
    //{
    //    for(int i = 0; i < parts.Length; i++)
    //    {
    //        check[i] = true;
    //    }
    //}

    //int isDeleted(int pos)
    //{
    //    int i = 0;
    //    while (isActive())
    //    {
    //        if (i == pos)
    //        {
    //            check[i] = false;
    //        }
    //        i++;
    //    }
    //    return pos;
    //}

    //bool isActive()
    //{
    //    bool active = true;
    //    int count = 0;
    //    for (int i = 0; i < check.Length; i++)
    //    {
    //        if (check[i] == false)
    //        {
    //            count++;
    //        }
    //    }
    //    if (count >= 6)
    //    {
    //        active = false;
    //    }
    //    return active;
    //}

    //GameObject findPart(GameObject part)
    //{
    //    GameObject temp = new GameObject();
    //    for(int i = 0; i < parts.Length; i++)
    //    {
    //        if (parts[i] == part)
    //        {
    //            temp = parts[i];
    //        }
    //    }
    //    return temp;
    //}
}
