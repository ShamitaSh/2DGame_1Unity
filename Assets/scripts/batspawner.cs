using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batspawner : MonoBehaviour
{

    // saved for efficiency
    [SerializeField]
    GameObject prefabBat;


    // spawn control
    const float SpawnDelaySec = 2;
    timer spawnTimer;

    // spawn location support
    float spawnMinX;
    float spawnMaxX;
    Vector2 spawnLocation = Vector2.zero;

    void Awake()
    {
        ScreenUtils.Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {

        GameObject tempBat = Instantiate(prefabBat) as GameObject;
        BoxCollider2D collider = tempBat.GetComponent<BoxCollider2D>();
        float batWidth = collider.size.x;
        float batHeight = collider.size.y;
        Destroy(tempBat);

        spawnMinX = ScreenUtils.ScreenLeft + batWidth / 2;
        spawnMaxX = ScreenUtils.ScreenRight - batWidth / 2;
        spawnLocation.y = ScreenUtils.ScreenTop + batHeight / 2;

        // start spawn timer
        spawnTimer = gameObject.AddComponent<timer>();
        spawnTimer.Duration = SpawnDelaySec;
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            spawnTimer.Run();
            spawnLocation.x = Random.Range(spawnMinX, spawnMaxX);
            Instantiate(prefabBat, spawnLocation, Quaternion.identity);
        }
    }


      //void SpawnBat()
      //{  
        // generate random location and create new teddy bear
       // location.x = Random.Range(minSpawnX, maxSpawnX);
        //location.y = Random.Range(minSpawnY, maxSpawnY);
        //location.z = -Camera.main.transform.position.z;
        //Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);
        //SetMinAndMax(worldLocation);

        //int spawnTries = 1;
        //while (Physics2D.OverlapArea(min, max) != null &&
               //spawnTries < MaxSpawnTries)
        //{
            // change location and calculate new rectangle points
            //location.x = Random.Range(minSpawnX, maxSpawnX);
            //location.y = Random.Range(minSpawnY, maxSpawnY);
            //worldLocation = Camera.main.ScreenToWorldPoint(location);
           // SetMinAndMax(worldLocation);

            //pawnTries++;
        //}

        //if (Physics2D.OverlapArea(min, max) == null)
        //{


            //int prefabNumber = Random.Range(0, 4);
            //if (prefabNumber == 0)
            //{
               // GameObject Batboy = Instantiate(batboy) as GameObject;
                //Batboy.transform.position = worldLocation;
            //}
            //else if (prefabNumber == 1)
            //{
                //GameObject Batboy = Instantiate(bluebat) as GameObject;
                //Batboy.transform.position = worldLocation;
            //}
            //else if (prefabNumber == 2)
           // {
               // GameObject Batboy = Instantiate(greenbat) as GameObject;
               // Batboy.transform.position = worldLocation;
            //}
            //else
            //{
               // GameObject Batboy = Instantiate(redbat) as GameObject;
                //Batboy.transform.position = worldLocation;

            //}
        //}

        //void SetMinAndMax(Vector3 location)
        //{
            //min.x = location.x - batColliderHalfWidth;
            //min.y = location.y - batColliderHalfHeight;
           // max.x = location.x + batColliderHalfWidth;
           // max.y = location.y + batColliderHalfHeight;
        //}
      //}
}
