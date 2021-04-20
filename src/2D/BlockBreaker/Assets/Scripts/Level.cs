using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;

    int currentBlockCount;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = GameObject
            .FindWithTag("SceneLoader")
            .GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update() { }

    public void AddBlock()
    {
        currentBlockCount++;
        Debug.Log($"Current block count is {currentBlockCount}");
    }

    public void RemoveBlock()
    {
        currentBlockCount--;
        Debug.Log($"Current block count is {currentBlockCount}");
        if (currentBlockCount == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
