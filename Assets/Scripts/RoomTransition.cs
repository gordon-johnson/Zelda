using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
	public float moveCameraTimer = 2f;
	public float movePlayerTimer = 0.375f;
	Camera camera;
	Vector3 newCameraPos;
	Vector3 newPlayerPos;

	// Start is called before the first frame update
	void Start()
	{
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x - camera.transform.position.x > 8f)
		{
			newCameraPos = new Vector3(camera.transform.position.x + 16f, camera.transform.position.y, camera.transform.position.z);
			newPlayerPos = new Vector3((int)transform.position.x + 2f, transform.position.y, transform.position.z);
			StartCoroutine(MoveCamera(camera.transform.position, newCameraPos, newPlayerPos));
		}
		else if (camera.transform.position.x - transform.position.x > 8f)
		{
			newCameraPos = new Vector3(camera.transform.position.x - 16f, camera.transform.position.y, camera.transform.position.z);
			newPlayerPos = new Vector3((int)transform.position.x - 1f, transform.position.y, transform.position.z);
			StartCoroutine(MoveCamera(camera.transform.position, newCameraPos, newPlayerPos));
		}
		else if ((camera.transform.position.y - 1.5f) - transform.position.y > 5.5f)
		{
			newCameraPos = new Vector3(camera.transform.position.x, camera.transform.position.y - 11f, camera.transform.position.z);
			newPlayerPos = new Vector3(transform.position.x, (int)transform.position.y - 1f, transform.position.z);
			StartCoroutine(MoveCamera(camera.transform.position, newCameraPos, newPlayerPos));
		}
		else if (transform.position.y - (camera.transform.position.y - 1.5f) > 5.5f)
		{
			newCameraPos = new Vector3(camera.transform.position.x, camera.transform.position.y + 11f, camera.transform.position.z);
			newPlayerPos = new Vector3(transform.position.x, (int)transform.position.y + 2f, transform.position.z);
			StartCoroutine(MoveCamera(camera.transform.position, newCameraPos, newPlayerPos));
		}
	}

	IEnumerator MoveCamera(Vector3 curPos, Vector3 newPos, Vector3 newPlayerPos)
	{
		GetComponent<ArrowKeyMovement>().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;

		for (float t = 0f; t <= moveCameraTimer; t += Time.deltaTime)
		{
			camera.transform.position = Vector3.Lerp(curPos, newPos, t / moveCameraTimer);
			yield return 0;
		}

		camera.transform.position = newPos;
		StartCoroutine(MovePlayer(transform.position, newPlayerPos));
		GetComponent<ArrowKeyMovement>().enabled = true;
		GetComponent<SpriteRenderer>().enabled = true;
	}

	IEnumerator MovePlayer(Vector3 curPos, Vector3 newPos)
	{
		for (float t = 0f; t <= movePlayerTimer; t += Time.deltaTime)
		{
			transform.position = Vector3.Lerp(curPos, newPos, t / movePlayerTimer);
			yield return 0;
		}
		transform.position = newPos;
	}
}
