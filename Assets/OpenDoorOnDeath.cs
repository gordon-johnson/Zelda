using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnDeath : MonoBehaviour
{
	public Sprite switchToSprite;
	public GameObject other;

	private bool triggered;

	// Start is called before the first frame update
	void Start()
	{
		triggered = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (!triggered)
		{
			if (other.activeSelf == false)
			{
				GetComponent<BoxCollider>().isTrigger = true;
				GetComponent<SpriteRenderer>().sprite = switchToSprite;
				triggered = true;
			}
		}
	}
}
