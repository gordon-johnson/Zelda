using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public bool isPlayer = false;
	public int maxHealth;

    [System.Serializable]
    public class Drop
    {
        public GameObject dropObject;
        public int dropChance;
    }
    public Drop[] dropList;

	private int health;

	private void Start()
	{
		health = maxHealth;
	}

	private void Update()
	{
		if (Cheats.godMode  && isPlayer)
		{
			health = maxHealth;
		}
	}

	public void AlterHealth(int delta_health)
	{
        if(GetComponent<ControlableMovement>() && isPlayer)
        {
            GameControl.instance.player.GetComponent<Health>().AlterHealth(delta_health);
            return;
        }
		health += delta_health;
		if (health >= maxHealth)
		{
			health = maxHealth;
		}
		if (health <= 0)
		{
			Debug.Log("health = 0");
            OnDeath();
			gameObject.SetActive(false);
			if (isPlayer)
			{
				Debug.Log("game over");
				GameControl.instance.PlayerDied();
			}
		}
	}

    public void OnDeath()
    {
        float dropValue = Random.value;
        Debug.Log("Drop Value: " + dropValue);
        float currentValue = 0;
        for(int i = 0; i < dropList.Length; i++)
        {
            currentValue += (dropList[i].dropChance / 100f);
            if (currentValue >= dropValue)
            {
                Instantiate(dropList[i].dropObject, transform.position, Quaternion.identity);
                break;
            }
        }
    }

	public int GetHealth()
	{
		return health;
	}
}
