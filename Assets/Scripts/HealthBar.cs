using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Health health;
	Text text_component;

	// Start is called before the first frame update
	void Start()
	{
		text_component = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		if (health != null && text_component != null)
		{
			text_component.text = " - LIFE - \n\n";
			for (int i = 0; i < health.GetHealth(); ++i)
			{
				if (i % 2 == 0)
				{
					text_component.text += " <";
				}
				else
				{
					text_component.text += "3 ";
				}
			}
		}
	}
}
