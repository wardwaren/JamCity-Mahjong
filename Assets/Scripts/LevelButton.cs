using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int levelID;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private List<GameObject> stars;
    
    private int numberOfStars = 0;

    private void OnEnable()
    {
        foreach (var star in stars)
        {
            star.SetActive(false);
        }

        for (int i = 0; i < numberOfStars; i++)
        {
            stars[i].SetActive(true);
        }
    }

    public void loadScene()
    {
        LevelData.levelID = levelID;
        SceneManager.LoadScene(1);
        
    }

    public void setStarsNum(int num)
    {
        numberOfStars = num;
    }
    
    public void setSceneID(int id)
    {
        levelID = id;
        buttonText.text = id.ToString();
    }
}
