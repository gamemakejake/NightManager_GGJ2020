using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    private Transform targetToFollow;

    public float xWest, xEast, yBottom, yTop;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(targetToFollow.position.x, xWest, xEast),
            Mathf.Clamp(targetToFollow.position.y, yBottom, yTop),
            transform.position.z);

        //transform.position = targetToFollow.position;
    }
}
