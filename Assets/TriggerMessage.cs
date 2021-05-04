using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TriggerMessage : MonoBehaviour
{
	private bool showText;
	public GameObject oldManText;
	public float shift;
	public float typeSpeed = 0.1f;
	public string message = "";

    // Start is called before the first frame update
    void Start()
    {
		oldManText.GetComponent<TextMesh>().text = "";
		showText = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!showText)
			{
				StartCoroutine(AnimateText(message));
				showText = true;
				transform.position = new Vector3(transform.position.x + shift, transform.position.y, transform.position.z);
			}
			else if (showText)
			{
				oldManText.GetComponent<TextMesh>().text = "";
				showText = false;
				transform.position = new Vector3(transform.position.x - shift, transform.position.y, transform.position.z);
			}
		}
	}

	IEnumerator AnimateText(string message)
	{
		int i = 0;
		while (i < message.Length)
		{
			oldManText.GetComponent<TextMesh>().text += message[i++];
			yield return new WaitForSeconds(typeSpeed);
		}
	}
}
