using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelDataGame _levelDataGame;
    
    private Tile curTile;
    private List<List<GameObject>> currentGrid;

    /*
        TODO
        Implement a pathfinding algorithm that will traverse through the grid and try to look for 
        possible path with less than 3 turns between tile a and tile b. Djikstra can be taken as the basis
        however it will need to be modified in order to account for out of the grid connections. 
    */
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
