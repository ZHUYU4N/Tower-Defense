using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;

	[HideInInspector]

	public float startHealth = 100;
	private float health;

    public float speed = 4;

    public int worth = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]

	private bool isDead = false;
    public Transform target;

    void Start ()
	{
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}

	public void Slow (float pct)
	{
		speed = startSpeed * (1f - pct);
	}

	void Die ()
	{
		isDead = true;

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);


		Destroy(gameObject);
	}

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }                                                                            

}
