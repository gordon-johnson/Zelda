using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorOnMove : MonoBehaviour
{
	public Sprite switchToSprite;
	public GameObject blockTrigger;

	private Vector3 triggerPos;
	private bool triggered;

	// Start is called before the first frame update
	void Start()
    {
		triggerPos = blockTrigger.transform.position;
		triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (!triggered)
		{
			if (blockTrigger.transform.position.x == triggerPos.x + 1 ||
				blockTrigger.transform.position.x == triggerPos.x - 1 ||
				blockTrigger.transform.position.y == triggerPos.y + 1 ||
				blockTrigger.transform.position.y == triggerPos.y - 1)
			{
				Debug.Log("Triggered");
				GetComponent<BoxCollider>().isTrigger = true;
				GetComponent<SpriteRenderer>().sprite = switchToSprite;
				triggered = true;
			}
		}
    }
}
