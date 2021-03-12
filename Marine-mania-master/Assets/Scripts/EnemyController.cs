using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] waypoints;
    public int num = 0;
    public float speed = 4;
    public float minDist = 1;

    public bool go = true;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].transform.position);
        if (go)
        {
            if (dist > minDist)
            {
                Move();
            }
            else
            {
                if (num + 1 == waypoints.Length)
                {
                    Destroy(gameObject);
                }
                else
                {
                    num++;
                }
            }
        }
    }
    public void Move()
    {
        gameObject.transform.LookAt(waypoints[num].transform.position);
        gameObject.transform.localPosition += gameObject.transform.forward * speed * Time.deltaTime;
    }
}