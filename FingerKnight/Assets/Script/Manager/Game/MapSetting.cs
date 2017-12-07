using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetting : MonoBehaviour {
    int MAP_SIZE = 10;
    int XS = -10, YS = 10;
    float DIST = 2.5f;

    public GameObject o_Parent;

    private TextAsset txtFile;
    private string full_txt;
    
    public void Setting() {
        txtFile = (TextAsset)Resources.Load("Map") as TextAsset;
        full_txt = txtFile.text;

        string[] arr_Line = full_txt.Split('\n');//라인별 나누기
        
        for(int i=0;i< MAP_SIZE; i++) {//라인을 ,로 한자씩 나눠 타일깔기
            string[] arr_Word = arr_Line[0].Split(',');
            //x-25y25
            for(int j = 0; j < MAP_SIZE; j++) {
                GameObject load_tile = null;

                switch (int.Parse(arr_Word[j])) {
                    case 0:
                        load_tile = (GameObject)Resources.Load("Prefabs/Map/Tile0") as GameObject;
                        break;
                    case 1:
                        load_tile = (GameObject)Resources.Load("Prefabs/Map/Tile1") as GameObject;
                        break;
                    case 2:
                        load_tile = (GameObject)Resources.Load("Prefabs/Map/Tile2") as GameObject;
                        break;
                }

                GameObject set_tile = Instantiate(load_tile, o_Parent.transform);
                set_tile.transform.position = new Vector2(XS + DIST * j, YS - DIST * i);
            }
        }

    }
}
