using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batboy : MonoBehaviour
{
    const float ImpulseForceMagnitude = 2.0f;

    bool collecting = false;
    GameObject targetPickup;


    new Rigidbody2D rigidbody2D;
    Bugcollector bugcollector;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;
        position.x = 0;
        position.y = 0;
        position.z = 0;
        transform.position = position;

        // save references for efficiency
        rigidbody2D = GetComponent<Rigidbody2D>();
        bugcollector = Camera.main.GetComponent<Bugcollector>();
    }

    void OnMouseDown()
    {
        // ignore mouse clicks if already collecting
        if (!collecting)
        {
            GoToNextPickup();
        }
    }
    /// <param name="other">collider info</param>
    void OnTriggerStay2D(Collider2D other)
    {
        // only respond if the collision is with the target pickup
        if (other.gameObject == targetPickup)
        {
            // remove collected pickup from game and go to the next one
            bugcollector.RemovePickup(targetPickup);
            rigidbody2D.velocity = Vector2.zero;
            GoToNextPickup();
        }
    }

    public void UpdateTarget(GameObject pickup)
    {
        if (targetPickup == null)
        {
            SetTarget(pickup);
        }
        else
        {
            float targetDistance = GetDistance(targetPickup);
            if (GetDistance(pickup) < targetDistance)
            {
                SetTarget(pickup);
            }
        }
    }

    void SetTarget(GameObject pickup)
    {
        targetPickup = pickup;
        if (collecting)
        {
            GoToTargetPickup();
        }
    }

    void GoToNextPickup()
    {
        // calculate direction to target pickup and start moving toward it
        targetPickup = GetClosestPickup();
        if (targetPickup != null)
        {
            GoToTargetPickup();
        }
        else
        {
            collecting = false;
        }
    }

    void GoToTargetPickup()
    {
        // calculate direction to target pickup and start moving toward it
        Vector2 direction = new Vector2(
            targetPickup.transform.position.x - transform.position.x,
            targetPickup.transform.position.y - transform.position.y);
        direction.Normalize();
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(direction * ImpulseForceMagnitude,
                                  ForceMode2D.Impulse);
    }

    GameObject GetClosestPickup()
    {
        // initial setup
        List<GameObject> pickups = bugcollector.Pickups;
        GameObject closestPickup;
        float closestDistance;
        if (pickups.Count == 0)
        {
            return null;
        }
        else
        {
            closestPickup = pickups[0];
            closestDistance = GetDistance(closestPickup);
        }

        // find and return closest pickup
        foreach (GameObject pickup in pickups)
        {
            float distance = GetDistance(pickup);
            if (distance < closestDistance)
            {
                closestPickup = pickup;
                closestDistance = distance;
            }
        }
        return closestPickup;
    }
    float GetDistance(GameObject pickup)
    {
        return Vector3.Distance(transform.position, pickup.transform.position);
    }


}
