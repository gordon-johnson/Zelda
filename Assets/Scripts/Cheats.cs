using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
	public static bool godMode = false;

	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			godMode = !godMode;
        }

        if (godMode)
		{
			//Debug.Log("God Mode");
		}
    }
}
