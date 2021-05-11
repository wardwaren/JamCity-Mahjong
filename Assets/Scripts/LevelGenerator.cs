using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelDataGame _levelDataGame;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private List<TextAsset> _levelsTxt;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilePosition;
    
    
    private List<List<GameObject>> tileGrid;
    private TextAsset curLevel;
    private int tileCount;
    private int activeTiles;
    
    void Start()
    {
        tileGrid = new List<List<GameObject>>();
        curLevel = _levelsTxt[_levelDataGame.getLevel()];
        activeTiles = 0;
        tileCount = 0;
        generateTiles();
    }

    private void generateTiles()
    {
        List<String> text = curLevel.text.Split("\n"[0]).ToList();
        
        for (int i = 0; i < text.Count; i++)
        {
            Vector3 curPosition = _tilePosition.position;
            List<GameObject> row = new List<GameObject>();
            
            for (int j = 0; j < text[i].Length; j++)
            {
                if (text[i][j] == 'X' || text[i][j] == '0')
                {
                    GameObject newTileFile = GameObject.Instantiate(_tilePrefab);
                    newTileFile.transform.position = curPosition;
                    //TODO change tile positioning to grid instead of manual placement.
                    float newPosX = curPosition.x + _tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
                    curPosition = new Vector3(newPosX,curPosition.y,curPosition.z);
                
                    Tile curTile = newTileFile.GetComponent<Tile>();
                
                    if (text[i][j] == 'X')
                    {
                        curTile.setEnabled(true);
                        tileCount++;
                    }
                    else
                    {
                        curTile.setEnabled(false);
                    }
                    curTile.setRowColumn(i,j);
                    curTile.setManager(_gameManager);
                    
                    row.Add(newTileFile);
                }
            }
            
            float newPosY = _tilePosition.position.y - _tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y;
            _tilePosition.position = new Vector3(_tilePosition.position.x,newPosY,_tilePosition.position.z);
            tileGrid.Add(row);
        }

        _levelDataGame.generateTilesSetup(tileCount);
        GenerateGrid(_levelDataGame.getTileCounts());
        _gameManager.setGrid(tileGrid);
    }

    public void GenerateGrid(Dictionary<int, int> tileCounts)
    {
        foreach(var tile in tileCounts)
        {
            Debug.Log(tile.Value + " " + tile.Key);
        }
        
        for (int i = 0; i < tileGrid.Count; i++)
        {
            for (int j = 0; j < tileGrid[i].Count; j++)
            {
                Tile curTile = tileGrid[i][j].GetComponent<Tile>();
                if (curTile.getEnabled())
                {
                    int id = getNonZeroID(tileCounts);
                    Debug.Log(id);
                    curTile.setTile(id);
                }
            }
        }
    }

    public int getNonZeroID(Dictionary<int, int> tileCounts)
    {
        int id = -1;
        
        while (id == -1)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            
            int temp = Random.Range(0, tileCounts.Count);
            
            if (tileCounts[temp] > 0)
            {
                tileCounts[temp] -= 1;
                id = temp;
            }
        }

        return id;
    }
}
