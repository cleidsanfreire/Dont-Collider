using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float interval = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameActive()) {
            return;
        }
        
        var gameManager = GameManager.Instance;

        float z = gameManager.speedObstacle * Time.deltaTime;
        transform.position -= new Vector3(0,0,z);

        if(transform.position.z <= -20) {
            Destroy(gameObject);
        }
    }
}
