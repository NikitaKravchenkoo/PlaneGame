using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControler : MonoBehaviour
{
    public static LevelControler instance;

    uint numDestructable = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 2;

    string[] levels = { "Level1", "Level2" };
    int currentLevel = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)
            {
                currentLevel++;
                if(currentLevel <= levels.Length)
                {
                    string sceneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(sceneName);
                }
                else
                {
                    Debug.Log("Game Over");
                }
                nextLevelTimer = 2;
                startNextLevel = false;

            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    public void AddDestructable()
    {
        numDestructable++;
    }

    public void RemoveDestructable()
    {
        numDestructable--;

        if(numDestructable == 0)
        {
            startNextLevel = true;
        }
    }
}
