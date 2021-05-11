using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private List<String> names;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameManager _gameManager;
    
    private String name;
    private int row;
    private int column;
    private bool enabled;

    public void setTile(int id)
    {
        name = names[id];
        sprite.sprite = sprites[id];
        setEnabled(enabled);
    }
    
    public void setEnabled(bool val)
    {
        enabled = val;
        gameObject.SetActive(val);
    }

    public void setRowColumn(int row, int column)
    {
        this.row = row;
        this.column = column;
    }

    public void setManager(GameManager manager)
    {
        _gameManager = manager;
    }
    
    public bool getEnabled()
    {
        return enabled;
    }

    public int getRow()
    {
        return row;
    }
    
    public int getColumn()
    {
        return column;
    }
    
    private void OnMouseDown()
    {
        _gameManager.selectTile(this);
    }
}
