using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMananger : MonoBehaviour
{
    private float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager = GameManager.Instance;
        if(gameManager.IsGameOver()) 
        {
            return;
        }
        cooldown -= Time.deltaTime;
        if(cooldown <= 0f)
        {
            cooldown = GameManager.Instance.obstacleInterval;
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject  prefab = gameManager.obstaclePrefabs[prefabIndex];
            float x = gameManager.obstacleOffsetX;
            float y = Random.Range(gameManager.obstacleOffsetY.x, gameManager.obstacleOffsetY.y);
            float z = -4.45f;

            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
}
