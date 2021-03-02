using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    // timer support
    timer explodeTimer;

    // Start is called before the first frame update
    void Start()
    {
        explodeTimer = gameObject.AddComponent<timer>();
        explodeTimer.Duration = 1;
        explodeTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (explodeTimer.Finished)
        {
            explodeTimer.Run();

            // blow up C4 teddy bear
            GameObject Batboy = GameObject.FindWithTag("C4 bat");
            if (Batboy != null)
            {
                Instantiate<GameObject>(prefabExplosion,
                    Batboy.transform.position, Quaternion.identity);
                Destroy(Batboy);
            }
        }
    }
}
