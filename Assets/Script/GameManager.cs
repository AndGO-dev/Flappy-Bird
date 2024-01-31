using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float obstacleInterval = 1f;
    public float obstacleSpeed = 10f;
    public float obstacleOffsetX = 0;
    public Vector2 obstacleOffsetY = new Vector2(0,0);
    public List<GameObject> obstaclePrefabs;
    [HideInInspector] public int score;
    private bool isGameOver = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
   
   public bool IsGameActive(){
    return !isGameOver;
   }

   public bool IsGameOver(){
    return  isGameOver;
   }

   public void EndGame(){
    isGameOver = true;
    Debug.Log("Game Over " + "Score=" + score);
   }
}
