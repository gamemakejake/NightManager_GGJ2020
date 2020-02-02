using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyMapGenerator
{
    /*  This class does the following:
        >> Converts 2d textures to boolean maps indicating whether pixel is transparent or not
        >> Merges smaller boolean maps with larger boolean maps
    */
    
    public bool[,] ConvertTexture2DToBooleanAlphaMap(Texture2D texture) {
        bool[,] boolMap = new bool[texture.width, texture.height];

        for(int x = 0; x < boolMap.GetLength(0); x++) {
            for(int y = 0; y < boolMap.GetLength(1); y++) {
                if(texture.GetPixel(x, y).a > 0) boolMap[x, y] = true;
                else boolMap[x, y] = false;
            }
        }

        return boolMap;
    }

    public void MergeBooleanMapWithMasterBooleanMap(bool[,] masterMap, bool[,] boolMap, Vector2Int boolMapOrigin) {
        int startXMaster = boolMapOrigin.x - (boolMap.GetLength(0) / 2);
        int xBoolMapStart = 0;
        int startYMaster = boolMapOrigin.y - (boolMap.GetLength(1) / 2);
        int yBoolMapStart = 0;

        int x2, y2;

        while(startXMaster < 0) {
            startXMaster++;
            xBoolMapStart++;
        }

        while(startYMaster < 0) {
            startYMaster++;
            yBoolMapStart++;
        }

        x2 = xBoolMapStart;
        
        for(int x = startXMaster; x < boolMapOrigin.x + (boolMap.GetLength(0) / 2); x++) {
            y2 = yBoolMapStart;

            if(x >= masterMap.GetLength(0)) {
                break;
            }

            for(int y = startYMaster; y < boolMapOrigin.y + (boolMap.GetLength(1) / 2); y++) {
                
                
                if(y >= masterMap.GetLength(1)) {
                    break;
                }
                if(boolMap[x2, y2]) masterMap[x,y] = boolMap[x2, y2];

                y2++;
            }

            x2++;
        }
    }
}
