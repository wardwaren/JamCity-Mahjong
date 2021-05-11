using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

// 10 types 120 
public class LevelDataGame : MonoBehaviour
{
    
    [SerializeField] private List<int> tileTypes;

    
    private Dictionary<int, int> tileTypesCount;

    private int curLevel;
    private int tileCount;
    private int activeTiles;
    private int score;
    
    private void Awake()
    {
        curLevel = LevelData.levelID;
        activeTiles = 0;
        score = 0;
        
        tileTypesCount = new Dictionary<int, int>();
        foreach (var type in tileTypes)
        {
            tileTypesCount[type] = 0;
        }
    }

    public int getLevel()
    {
        return curLevel;
    }

    public void generateTilesSetup(int tilesNum)
    {
        tileCount = tilesNum;

        int typeNum = tileCount / tileTypesCount.Count + 1;

        if (typeNum % 2 == 1)
        {
            typeNum++;
        }

        foreach (var tileType in tileTypesCount.Keys.ToList())
        {
            if (activeTiles + typeNum < tileCount)
            {
                tileTypesCount[tileType] = typeNum;
                activeTiles += typeNum;
            }
            else
            {
                tileTypesCount[tileType] = tileCount - activeTiles;
                activeTiles += tileTypesCount[tileType];
            }
        }
    }

    public void addScore(int val)
    {
        score += val;
    }
    
    public Dictionary<int, int> getTileCounts()
    {
        return tileTypesCount;
    }

}
