using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]
    public float range = 10f;
    // Start is called before the first frame update
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Setup fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    void Start()
    {
        //caculate distance is computional cosuming so only do it 2 times every second
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			// targetEnemy = nearestEnemy.GetComponent<Enemy>();
		} else
		{
			target = null;
		}
    }
        // Update is called once per frame
    void Update()
    {
        if (target == null){
            return;
        }
        LockOnTarget ();

        // fire part
        if (fireCountdown <= 0f)
        {
            shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
	void shoot ()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(target);
	}

    //rotate function
    void LockOnTarget ()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //only rotate with y 
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        //all direction rotate
        //partToRotate.rotation = lookRotation;
	}
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
