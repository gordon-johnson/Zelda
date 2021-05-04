using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UntriggerMessage : MonoBehaviour
{
	public GameObject oldManText;

	// Start is called before the first frame update
	void Start()
	{
		oldManText.GetComponent<Text>().enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			oldManText.GetComponent<Text>().enabled = false;
		}
	}
}
