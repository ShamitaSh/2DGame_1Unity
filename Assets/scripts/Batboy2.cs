using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batboy2 : MonoBehaviour
{

    /// <summary>
    /// Take damage on collision with fish
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject collisionObject = coll.gameObject;
        if (collisionObject.CompareTag("Snake"))
        {
            // take damage and destroy fish
            Snake script = collisionObject.GetComponent<Snake>();
            script.DesTroy();
            Destroy(gameObject);

           
        }
    }
}
