using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTerrain : MonoBehaviour
{
    [Header("Wymiary Terenu")] 
    public int width;
    public int height;

    [Header("Klocki do budowy")]
    [SerializeField] GameObject ground;
    [SerializeField] GameObject grass;

    [Header("Gracz")]
    [SerializeField] GameObject Player;

    [Header("Skrypt kamery")]
    [SerializeField] MoveCamera cameraScript;

    void Start()
    {
        if (cameraScript.GetComponent<MoveCamera>() != null) Generation();     //Debug.Log("Skrypt znaleziony");
        else Debug.Log("Nie znaleziono skryptu");
        //Generation();
    }
    void Generation()
    {
        for(int x = 0; x < width; x ++)
        {
            for(int y = 0; y < height; y ++)
            {
                GameObject groundObj = SpawnObj(ground, x, y);
                groundObj.AddComponent<ClickSprite>();
                //groundObj.AddComponent<ClickSpriteReycast>();
            }
            GameObject grassObj = SpawnObj(grass, x, height);
            grassObj.AddComponent<ClickSprite>();
            //grassObj.AddComponent<ClickSpriteReycast>();
        }
        SpawnPlayer(Player, width, height);

        if (cameraScript != null)
        {
            cameraScript.minX = 10;
            cameraScript.maxX = width;
            cameraScript.minY = 0;
            cameraScript.maxY = height;
        }
        else
        {
            throw new System.Exception("Nie znaleziono skryptu MoveCamera!"); // Zg³oœ wyj¹tek w przypadku braku skryptu
        }
    }

    private GameObject SpawnObj(GameObject obj, int width, int height)
    {
        GameObject newObj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        newObj.transform.parent = this.transform;
        return newObj;
    }

    private void SpawnPlayer(GameObject pl, int x, int y)
    {
        pl.transform.position = new Vector2(x / 2, y + 1);
    }
}
