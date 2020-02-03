using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + (int)timer;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            text.text = "0";
            SceneManager.LoadScene("Main");
        }
    }
}
