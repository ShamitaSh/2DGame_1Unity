using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    void OnMouseUpAsButton()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(0, 5000),
            ForceMode2D.Impulse);
    }

    void OnBecomingInvisible()
    {
       Destroy(gameObject);
    }

    public void DesTroy()
    {
      
       Destroy(gameObject);
    }

}

