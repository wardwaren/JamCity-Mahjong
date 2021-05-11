using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelDataGame _levelDataGame;
    
    private Tile curTile;
    private List<List<GameObject>> currentGrid;

    private bool findPath(Tile a, Tile b)
    {
        return false;
    }
    
    public void selectTile(Tile tile)
    {
        Debug.Log(tile.getRow() + " " + tile.getColumn());
        if (curTile != null)
        {
            bool pathExists = findPath(curTile, tile);

            if (pathExists)
            {
                curTile.setEnabled(false);
                tile.setEnabled(false);
                _levelDataGame.addScore(10);
            }
            else
            {
                _levelDataGame.addScore(-15);
                curTile = null;
            }
        }
        else
        {
            curTile = tile;
        }
    }
    
    public void setGrid(List<List<GameObject>> grid)
    {
        currentGrid = grid;
    }
    
}
