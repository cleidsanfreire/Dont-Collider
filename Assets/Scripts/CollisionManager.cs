using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SensorScore"))
        {
            // Pontuação aumenta em 1!
            Debug.Log("GAME OVER!!");
            GameManager.Instance.EndGame();

        }
    }
}
