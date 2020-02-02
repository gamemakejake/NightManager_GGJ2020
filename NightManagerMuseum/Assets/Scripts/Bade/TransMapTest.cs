using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class TransMapTest : MonoBehaviour
{

    public Texture2D texture;
    public Texture2D textureToMerge;
    TransparencyMapGenerator transparencyMapGenerator = new TransparencyMapGenerator();

    void Start()
    {
        bool[,] boolMap = transparencyMapGenerator.ConvertTexture2DToBooleanAlphaMap(texture);
        StringBuilder text = new StringBuilder("", 80000);
        StringBuilder text2 = new StringBuilder("", 80000);

        Debug.Log("Width: " + boolMap.GetLength(0));
        Debug.Log("Height: " + boolMap.GetLength(1));

        for(int x = 0; x < boolMap.GetLength(0); x++) {
            for(int y = 0; y < boolMap.GetLength(1); y++) {
                if(boolMap[x,y]) text.Append("1");
                else text.Append("0");
            }

            text.Append("\n");
        }

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Bade\Documents\GitHub\textTransparencyMap.txt"))
        {
            file.WriteLine(text.ToString()); // "sb" is the StringBuilder
        }

        bool[,] boolMap2 = transparencyMapGenerator.ConvertTexture2DToBooleanAlphaMap(textureToMerge);
        transparencyMapGenerator.MergeBooleanMapWithMasterBooleanMap(boolMap, boolMap2, new Vector2Int(100, 100));

        for(int x = 0; x < boolMap.GetLength(0); x++) {
            for(int y = 0; y < boolMap.GetLength(1); y++) {
                if(boolMap[x,y]) text2.Append("1");
                else text2.Append("0");
            }

            text2.Append("\n");
        }

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Bade\Documents\GitHub\textTransparencyMap2.txt"))
        {
            file.WriteLine(text2.ToString()); // "sb" is the StringBuilder
        }
    }
}

