using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private GameObject levelFitter;
    [SerializeField] private GameObject buttonPrefab;
    
    private int levelNum = 5;
    
    private void Start()
    {
        for (int i = 0; i < levelNum; i++)
        {
            GameObject button = GameObject.Instantiate(buttonPrefab);
            LevelButton buttonScript = button.GetComponent<LevelButton>();
            button.transform.SetParent(levelFitter.transform);
            buttonScript.setSceneID(i);
        }
    } 
}
