using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement2 : AIMovement
{
	Rigidbody rb;
	public float movementSpeed = 1f;
	public float gridSize = 0.5f;
	public float rayLength = 1f;
	public float minTime = 2f;
	public float maxTime = 6f;

	private RaycastHit hit = new RaycastHit();
	private Vector3 lookN, lookE, lookS, lookW;

	protected int N, E, S, W;
    protected int direction;
	private int newDir;
	private bool turning;
	private float timer = 0;
	private float time;
    private int mask;


    // Start is called before the first frame update
    protected virtual void Start()
    {
		rb = GetComponent<Rigidbody>();
		direction = (int)(Random.value * 4);
		turning = true;

		lookN = transform.TransformDirection(Vector3.up);
		lookE = transform.TransformDirection(Vector3.right);
		lookS = transform.TransformDirection(Vector3.down);
		lookW = transform.TransformDirection(Vector3.left);

		N = 0;
		E = 1;
		S = 2;
		W = 3;

		time = (float)(Random.value * (maxTime - minTime) + minTime + 1);

        mask = LayerMask.GetMask("Wall") | LayerMask.GetMask("LowWall");
	}

    // Update is called once per frame
    protected virtual void Update()
	{
		move(direction);

		timer += Time.deltaTime * movementSpeed;
		if (timer >= time * gridSize || hitWall())
		{
			snapToGrid();
			look();
			direction = chooseDir();
			clean();
		}
	}

	private void snapToGrid()
	{
		rb.position = new Vector3(getNearestGrid(rb.position.x), getNearestGrid(rb.position.y), 0f);
	}

	float getNearestGrid(float position)
	{
		float lowerGuess = ((int)(position / gridSize)) * gridSize;
		float higherGuess = lowerGuess + gridSize;
		if (Mathf.Abs(position - lowerGuess) < Mathf.Abs(higherGuess - position))
		{
			return lowerGuess;
		}
		else
		{
			return higherGuess;
		}
	}

	private void look()
	{
		if (direction == N  || Physics.Raycast(transform.position, lookN, out hit, rayLength, mask))
		{
			N = -1;
		}
		if (direction == E || Physics.Raycast(transform.position, lookE, out hit, rayLength, mask))
		{
			E = -1;
		}
		if (direction == S || Physics.Raycast(transform.position, lookS, out hit, rayLength, mask))
		{
			S = -1;
		}
		if (direction == W || Physics.Raycast(transform.position, lookW, out hit, rayLength, mask))
		{
			W = -1;
		}
	}

	private bool hitWall()
	{
		return (direction == N && Physics.Raycast(transform.position, lookN, out hit, rayLength, mask))
			|| (direction == E && Physics.Raycast(transform.position, lookE, out hit, rayLength, mask))
			|| (direction == S && Physics.Raycast(transform.position, lookS, out hit, rayLength, mask))
			|| (direction == W && Physics.Raycast(transform.position, lookW, out hit, rayLength, mask));
	}

	private int chooseDir()
	{
		int rand = (int)(Random.value * 4);

		if (rand == N)
		{
			return N;
		}
		if (rand == E)
		{
			return E;
		}
		if (rand == S)
		{
			return S;
		}
		if (rand == W)
		{
			return W;
		}
		return chooseDir();
	}

	private void move(int dir)
	{
		if (dir == N)
		{
			rb.position += Vector3.up * Time.deltaTime * movementSpeed;
		}
		if (dir == E)
		{
			rb.position += Vector3.right * Time.deltaTime * movementSpeed;
		}
		if (dir == S)
		{
			rb.position += Vector3.down * Time.deltaTime * movementSpeed;
		}
		if (dir == W)
		{
			rb.position += Vector3.left * Time.deltaTime * movementSpeed;
		}
	}

	private void clean()
	{
		N = 0;
		E = 1;
		S = 2;
		W = 3;
		timer = 0f;
		time = (float)(Random.value * (maxTime - minTime) + minTime + 1);
	}
}
