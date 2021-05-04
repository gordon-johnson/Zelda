using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public static bool spawn = false;
	public static bool despawn = false;
	public float minX, minY;

	Camera camera;
	private RaycastHit hit = new RaycastHit();
	public float radius = 0.5f;
	private int mask;
	private bool active = false;
	private Vector3 newPos;


	// Start is called before the first frame update
	void Start()
	{
		camera = Camera.main;
		mask = LayerMask.GetMask("Wall") | LayerMask.GetMask("LowWall") | LayerMask.GetMask("Enemy");
		Spawner();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void Spawner()
	{
		float spawnAtX = (float)((int)(Random.value * 12) + minX);
		float spawnAtY = (float)((int)(Random.value * 7) + minY);

		newPos = new Vector3(spawnAtX, spawnAtY, 0f);

		if (Physics.CheckSphere(newPos, radius, mask))
		{
			Spawner();
		}

		transform.position = newPos;
		// GetComponent<Health>().AlterHealth(GetComponent<Health>().maxHealth);
	}
}
