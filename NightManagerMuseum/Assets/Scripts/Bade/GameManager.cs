using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture2D cursor;
    private Vector2 cursorHotspot;

    public GameObject[] objectsToSpawn;
    public Transform locationToSpawn;

    void Start()
    {
        cursorHotspot = new Vector2 (cursor.width * 0.6f, cursor.height * 0.1f);
        Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);

        for(int i = 0; i < objectsToSpawn.Length; i++) {
            Instantiate(objectsToSpawn[i], locationToSpawn);
        }
    }
}
