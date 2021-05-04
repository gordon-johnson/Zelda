using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int rupee_count = 0;
    int key_count = 0;
	int bomb_count = 0;

	private void Update()
	{
		if (Cheats.godMode)
		{
			rupee_count = 999;
			key_count = 999;
			bomb_count = 999;
		}
	}

	public void AddRupees(int num_rupees)
    {
		if (!Cheats.godMode)
		{
			rupee_count += num_rupees;
		}
	}

    public int getRupees()
    {
        return rupee_count;
    }

	public void AddKeys(int num_keys)
    {
		if (!Cheats.godMode)
		{
			key_count += num_keys;
		}
	}

    public int getKeys()
    {
        return key_count;
    }

	public void AddBombs(int num_bombs)
	{
		if (!Cheats.godMode)
		{
			bomb_count += num_bombs;
		}
	}

	public int getBombs()
	{
		return bomb_count;
	}
}
