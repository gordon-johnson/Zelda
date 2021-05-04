using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock : MonoBehaviour
{
	private Vector3 origin;

	private void Start()
	{
		origin = transform.position;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (transform.position == origin)
		{
			PushBlock(collision);
		}
	}

	private void PushBlock(Collision collision)
	{
		Vector3 dir = collision.transform.position - transform.position;
		dir = -dir.normalized;

		if (dir.x == 0f && dir.y == -1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.0f)
		{
			StartCoroutine(Delay(collision, dir.x, dir.y));
		}
		if (dir.x == 0f && dir.y == 1f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.0f)
		{
			StartCoroutine(Delay(collision, dir.x, dir.y));
		}
		if (dir.x == -1f && dir.y == 0f && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.0f)
		{
			StartCoroutine(Delay(collision, dir.x, dir.y));
		}
		if (dir.x == 1f && dir.y == 0f && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.0f)
		{
			StartCoroutine(Delay(collision, dir.x, dir.y));
		}
	}

	IEnumerator Delay(Collision collision, float deltaX, float deltaY)
	{
		for (float t = 0f; t <= 0.5f; t += Time.deltaTime)
		{
			yield return 0;
		}
		StartCoroutine(MoveBlockAfterDelay(collision, deltaX, deltaY));
	}


	IEnumerator MoveBlockAfterDelay(Collision collision, float deltaX, float deltaY)
	{
		collision.other.GetComponent<ArrowKeyMovement>().enabled = false;

		float moveTimer = 1f;
		Vector3 playerCurPos = collision.other.transform.position;
		Vector3 playerNewPos = new Vector3(collision.other.transform.position.x + deltaX, collision.other.transform.position.y + deltaY, collision.other.transform.position.z);
		Vector3 blockCurPos = transform.position;
		Vector3 blockNewPos = new Vector3(transform.position.x + deltaX, transform.position.y + deltaY, transform.position.z);

		for (float t = 0f; t <= moveTimer; t += Time.deltaTime)
		{
			collision.other.transform.position = Vector3.Lerp(playerCurPos, playerNewPos, t / moveTimer);
			transform.position = Vector3.Lerp(blockCurPos, blockNewPos, t / moveTimer);
			yield return 0;
		}
		collision.other.transform.position = playerNewPos;
		transform.position = blockNewPos;

		collision.other.GetComponent<ArrowKeyMovement>().enabled = true;
	}
}
