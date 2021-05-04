using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    public AudioClip rupee_collection_sound_clip;

    protected Inventory inventory;

    protected virtual void Start()
    {
        inventory = GetComponent<Inventory>();
        if(inventory == null)
        {
            Debug.LogWarning("WARNING: Gameobject with a collector has no inventory to store things in");
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "rupee")
        {
            Debug.Log("Collected rupee!");
            if (inventory)
            {
                inventory.AddRupees(1);
            }
            Destroy(other.gameObject);

            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }
        if (other.gameObject.tag == "key")
        {
            Debug.Log("Collected key!");
            if (inventory)
            {
                inventory.AddKeys(1);
            }
            Destroy(other.gameObject);

            AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
        }
		if (other.gameObject.tag == "bomb")
		{
			Debug.Log("Collected bomb!");
			if (inventory)
			{
				inventory.AddBombs(1);
			}
			Destroy(other.gameObject);

			AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
		}
		if (other.gameObject.tag == "res_heart")
		{
			Debug.Log("Collected restoration heart!");
			if (GetComponent<Health>())
			{
				GetComponent<Health>().AlterHealth(2);
			}
			Destroy(other.gameObject);

			AudioSource.PlayClipAtPoint(rupee_collection_sound_clip, Camera.main.transform.position);
		}

	}
}
