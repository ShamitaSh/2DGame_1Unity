using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batchanger : MonoBehaviour
{
    List<GameObject>prefabats = new List<GameObject>();

    // need for location of new character
    GameObject currentCharacter;

    bool previousFrameChangeCharacterInput = false;


    // Start is called before the first frame update
    void Start()
    {
        prefabats.Add((GameObject)Resources.Load(@"prefabs/batboy"));
        prefabats.Add((GameObject)Resources.Load(@"prefabs/bluebat"));
        prefabats.Add((GameObject)Resources.Load(@"prefabs/greenbat"));
        prefabats.Add((GameObject)Resources.Load(@"prefabs/redbat"));
        currentCharacter = Instantiate<GameObject>(
             prefabats[0], Vector3.zero,
             Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Batchanger") > 0)
        {
            if (!previousFrameChangeCharacterInput)
            {
                previousFrameChangeCharacterInput = true;
                // save current position and destroy current character
                Vector3 position = currentCharacter.transform.position;
                Destroy(currentCharacter);

                // instantiate a new random character
                currentCharacter = Instantiate(
                    prefabats[Random.Range(0, 4)],
                    position, Quaternion.identity);
            }
            else
            {
                previousFrameChangeCharacterInput = false;
            }

        }
    }
}
