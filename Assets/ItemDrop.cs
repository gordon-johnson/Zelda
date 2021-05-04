using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
	public bool timeout = false;
	public float life = 0f;

    // Start is called before the first frame update
    void Start()
    {
		GetComponent<BoxCollider>().enabled = false;
		if (timeout)
		{
			StartCoroutine("Timeout");
		}
    }

    // Update is called once per frame
    void Update()
    {
		StartCoroutine("enableDrop");
    }

	IEnumerator enableDrop()
	{
		yield return new WaitForSeconds(1);
		GetComponent<BoxCollider>().enabled = true;
	}

	IEnumerator Timeout()
	{
		yield return new WaitForSeconds(life);
		gameObject.SetActive(false);
	}
}
