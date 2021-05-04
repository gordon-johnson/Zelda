using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock_E : MonoBehaviour
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
		Vector3 dir = collision.contacts[0].point - transform.position;
		dir = -dir.normalized;

		if (dir.x > 0 && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.0f)
		{
			StartCoroutine(Delay(collision));
		}
	}

	IEnumerator Delay(Collision collision)
	{
		for (float t = 0f; t <= 1f; t += Time.deltaTime)
		{
			yield return 0;
		}
		StartCoroutine(MoveBlockAfterDelay(collision));
	}

	IEnumerator MoveBlockAfterDelay(Collision collision)
	{
		collision.other.GetComponent<ArrowKeyMovement>().enabled = false;

		float moveTimer = 1f;
		Vector3 playerCurPos = collision.other.transform.position;
		Vector3 playerNewPos = new Vector3(collision.other.transform.position.x + 1f, collision.other.transform.position.y, collision.other.transform.position.z);
		Vector3 blockCurPos = transform.position;
		Vector3 blockNewPos = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);

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
