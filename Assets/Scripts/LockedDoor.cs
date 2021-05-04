using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public Sprite switchToSprite;

    public LockedDoor[] neighbors;

    private void OnCollisionStay(Collision collision)
    {
		Vector3 align = collision.transform.position - transform.position;
		align = -align.normalized;
		
		if ((int)(align.y * 10) == 8 && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.0f)
		{
			OpenDoor(collision);
		}
		if ((int)(Mathf.Abs(align.x)) == 1 && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.0f)
		{
			OpenDoor(collision);
		}
	}

	private void OpenDoor(Collision collision)
	{
		if (collision.other.GetComponent<Inventory>() && collision.other.GetComponent<Inventory>().getKeys() > 0)
		{
			if ((Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.0f) || (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.0f))
			{
				StartCoroutine(PushDoor(collision));
			}
		}
	}

	IEnumerator PushDoor(Collision collision)
	{
		for (float t = 0f; t <= 0.1f; t += Time.deltaTime)
		{
			yield return 0;
		}
        if (!GetComponent<BoxCollider>().isTrigger)
        {
            collision.other.GetComponent<Inventory>().AddKeys(-1);
        }
        turnOff();
		for (int i = 0; i < neighbors.Length; i++)
		{
			neighbors[i].turnOff();
		}
    }

    public void turnOff()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        GetComponent<SpriteRenderer>().sprite = switchToSprite;
    }
}
