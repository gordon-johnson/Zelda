using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquamentus : MonoBehaviour
{
	public GameObject breathAttack;
	public GameObject player;

	Rigidbody rb;
	public float movementSpeed = 1f;
	public float minMoveTime = 0f;
	public float maxMoveTime = 2f;
	public float attackSpeed = 2f;
	private float RStopper;
	private float LStopper;
	private int dir;
	private float moveTime;
	private float moveTimeMax;
	private float t;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();

		RStopper = rb.position.x + 3;
		LStopper = rb.position.x - 1;

		dir = 1;

		moveTime = 0f;
		moveTimeMax = (float)(Random.value * (maxMoveTime - minMoveTime) + minMoveTime + 1);

		t = 0f;
	}

	// Update is called once per frame
	void Update()
    {
		Move(dir);

		t += Time.deltaTime;
		if (t >= attackSpeed)
		{
			Attack();
			t = 0f;
		}

		moveTime += Time.deltaTime * movementSpeed;
		if (moveTime >= moveTimeMax || LStopper >= rb.position.x || rb.position.x >= RStopper)
		{
			dir *= -1;
			moveTime = 0f;
			moveTimeMax = (float)(Random.value * (maxMoveTime - minMoveTime) + minMoveTime + 1);
		}
	}

	private void Move(int x)
	{
		if (x == 1)
		{
			rb.position += Vector3.right * Time.deltaTime * movementSpeed;
		}
		if (x == -1)
		{
			rb.position += Vector3.left * Time.deltaTime * movementSpeed;
		}
	}

	private void Attack()
	{
		Vector3 attackRotation = new Vector3(0, 0,(Mathf.Rad2Deg * Mathf.Atan2(player.transform.position.x - transform.position.x, transform.position.y - player.transform.position.y)));


		GameObject spawned = Instantiate(breathAttack, transform.position, transform.rotation);
		spawned.transform.eulerAngles = attackRotation;
	}
}
