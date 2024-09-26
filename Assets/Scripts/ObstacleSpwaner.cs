using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpwaner : MonoBehaviour
{

    private float cooldown = 0;
    private Vector3 originPoint = new Vector3(0,0.53f,20.84f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameActive()){
            return;
        }
        
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            cooldown = GameManager.Instance.intervalObstacle;
            SpawnerObstacle();
        }   
    }

    void SpawnerObstacle() {
        var gameManager = GameManager.Instance;
         int prefabIndex = Random.Range(0, gameManager.prefabs.Count);
            GameObject prefab = gameManager.prefabs[prefabIndex];

            float gameWidth = gameManager.gameWidth;
            float xOffset = Random.Range(-gameWidth / 2, gameWidth / 2);
            Vector3 position = originPoint + new Vector3(xOffset, 0, 0);

            Quaternion rotation = prefab.transform.rotation;

            Instantiate(prefab, position, rotation);
    }
}
