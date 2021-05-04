using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTrap : MonoBehaviour
{
	public float xTime = 0.954f;
	public float yTime = 0.5f;

	private Vector3 origin; 
	private Vector3 N = Vector3.up;
	private Vector3 S = Vector3.down;
	private Vector3 E = Vector3.right;
	private Vector3 W = Vector3.left;
	private RaycastHit hit;
	private float rayLength = 100f;
	private int mask;

	// Start is called before the first frame update
	void Start()
    {
		origin = transform.position;
		mask = LayerMask.GetMask("Wall") | LayerMask.GetMask("LowWall") | LayerMask.GetMask("Player");
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.position == origin)
		{
			if (Physics.BoxCast(origin, new Vector3(0.4f, 0.4f, 0.4f), N, out hit, Quaternion.identity, rayLength, mask) && hit.collider.tag == "Player")
			{
				Debug.Log("N");
				StartCoroutine(Trigger(new Vector3(origin.x, origin.y + 2.75f, origin.z), yTime));
			}
			if (Physics.BoxCast(origin, new Vector3(0.4f, 0.4f, 0.4f), S, out hit, Quaternion.identity, rayLength, mask) && hit.collider.tag == "Player")
			{
				Debug.Log("S");
				StartCoroutine(Trigger(new Vector3(origin.x, origin.y - 2.75f, origin.z), yTime));
			}
			if (Physics.BoxCast(origin, new Vector3(0.4f, 0.4f, 0.4f), E, out hit, Quaternion.identity, rayLength, mask) && hit.collider.tag == "Player")
			{
				StartCoroutine(Trigger(new Vector3(origin.x + 5.25f, origin.y, origin.z), xTime));
			}
			if (Physics.BoxCast(origin, new Vector3(0.4f, 0.4f, 0.4f), W, out hit, Quaternion.identity, rayLength, mask) && hit.collider.tag == "Player")
			{
				StartCoroutine(Trigger(new Vector3(origin.x - 5.25f, origin.y, origin.z), xTime));
			}
		}
    }

	IEnumerator Trigger(Vector3 newPos, float time)
	{
		for (float t = 0f; t <= time; t += Time.deltaTime)
		{
			transform.position = Vector3.Lerp(origin, newPos, t / time);
			yield return 0;
		}

		transform.position = newPos;

		StartCoroutine(Reset(newPos, time * 2f));
	}

	IEnumerator Reset(Vector3 oldPos, float time)
	{
		for (float t = 0f; t <= time; t += Time.deltaTime)
		{
			transform.position = Vector3.Lerp(oldPos, origin, t / time);
			yield return 0;
		}

		transform.position = origin;
	}
}
