using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snakesquadron : MonoBehaviour
{
    [SerializeField]
    GameObject prefabSnake;

    GameObject[] snake;
    float[] xPositions;
    float baseY;

    int numSnake;
    Vector2 snakeLocation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject tempSnake = Instantiate<GameObject>(prefabSnake);
        BoxCollider2D collider = tempSnake.GetComponent<BoxCollider2D>();
        float snakeWidth = collider.size.x;
        float snakeHeight = collider.size.y;
        Destroy(tempSnake);

        
        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        numSnake = (int)(screenWidth / snakeWidth);
        float totalsnakeWidth = numSnake * snakeWidth;
        float leftSnakeOffset = ScreenUtils.ScreenLeft +
                               (screenWidth - totalsnakeWidth) / 2 +
                               snakeWidth / 2;

        
        baseY = ScreenUtils.ScreenBottom + snakeHeight / 2;
        snake = new GameObject[numSnake];
        xPositions = new float[numSnake];

        
        snakeLocation = new Vector2(leftSnakeOffset, baseY);
        int snakeIndex = 0;
        for (int column = 0; column < numSnake; column++)
        {
            snake[snakeIndex] = Instantiate<GameObject>(prefabSnake,
                snakeLocation, Quaternion.identity);
            xPositions[snakeIndex] = snakeLocation.x;
            snakeLocation.x += snakeWidth;
            snakeIndex++;
        }
    }


    // Update is called once per frame
    void Update()
    {
      for (int i = 0; i < numSnake; i++)
      {
        if (snake[i] == null)
        {
            snakeLocation.x = xPositions[i];
            snake[i] = Instantiate<GameObject>(prefabSnake,
                snakeLocation, Quaternion.identity);
        }
      }
    }
}
