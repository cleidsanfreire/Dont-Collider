using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameActive())
        {
            return;
        }

        bool isPressingLeft = Input.GetKey(KeyCode.LeftArrow);
        bool isPressingRight = Input.GetKey(KeyCode.RightArrow);

        if (isPressingLeft == isPressingRight)
        {
            return;
        }


        float movement = (speed * Time.deltaTime);
        if (isPressingLeft)
        {
            movement *= -1f;
        }
        transform.position += new Vector3(movement, 0, 0);

        float movementLimit = GameManager.Instance.gameWidth / 2;
        float positionY = transform.position.y;
        float positionZ = transform.position.z;

        if (transform.position.x < -movementLimit)
        {
            transform.position = new Vector3(-movementLimit, positionY, positionZ);
        }
        else if (transform.position.x > movementLimit)
        {
            transform.position = new Vector3(movementLimit, positionY, positionZ);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SensorScore"))
        {
            // Pontuação aumenta em 1!
            GameManager.Instance.score++;
            Debug.Log("Your Score is: " + GameManager.Instance.score);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("SensorScoreBrind"))
        {
            GameManager.Instance.score += 3;
            Debug.Log("Gift!! Your Score is: " + GameManager.Instance.score);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Sensor"))
        {
            Debug.Log("GAME OVER!!");
            GameManager.Instance.EndGame();
        }
    }
}
