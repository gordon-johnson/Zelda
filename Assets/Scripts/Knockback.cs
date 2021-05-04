using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
	public float distance = 3;
	public float timeToMove = 0.2f;

	private Vector3 target;
	private bool active = false;
	private float moveTimer;

    public float invincibilityTime = 1f;
    float invincibilityTimer;
    public bool invincible;

    public Color invincibilityColor = Color.red;
    Color originalColor;

    private void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    private void Update()
	{
        if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
            invincible = true;
            if(invincibilityTimer <= 0)
            {
                invincible = false;
                GetComponent<SpriteRenderer>().color = originalColor;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<BoxCollider>().enabled = true;
            }
        }

		if (active)
		{
			transform.position += ((target - transform.position) / moveTimer) * Time.deltaTime;
			if (Time.deltaTime >= moveTimer)
			{
				transform.position = target;
				active = false;
			}
			moveTimer -= Time.deltaTime;
		}

	}

	public void GetKnockedBack(float otherXPos, float otherYPos)
	{
        moveTimer = timeToMove;
        target = GetTarget(otherXPos, otherYPos, KnockbackDir(otherXPos, otherYPos));
		active = true;
        invincibilityTimer = invincibilityTime;
        originalColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = invincibilityColor;
	}

    private Vector3 GetTarget(float otherXPos, float otherYPos, Vector3 direction)
    {
        float rayLength = distance;
        RaycastHit hit;
        int mask = LayerMask.GetMask("Wall") | LayerMask.GetMask("LowWall");
        while (distance > 0 && Physics.Raycast(transform.position, direction, out hit, rayLength, mask))
        {
            rayLength -= GameControl.instance.gridSize;
        }
        return (KnockbackDir(otherXPos, otherYPos).normalized * rayLength) + transform.position;

    }

	private Vector3 KnockbackDir(float otherXPos, float otherYPos)
	{
		if (transform.position.y % GameControl.instance.gridSize == 0)
		{
            Debug.Log("Transform X: " + transform.position.x);
			if (otherXPos >= transform.position.x)
			{
				return Vector3.left;
			}
			else
			{
				return Vector3.right;
			}
		}
		else
		{
            Debug.Log("Transform Y: " + transform.position.y);
            if (otherYPos >= transform.position.y)
			{
				return Vector3.down;
			}
			else
			{
				return Vector3.up;
			}
		}
	}

	public bool stunByBommerang = false;
	public bool immuneToBoomerang = false;
	public float stunTime = 5f;
	private bool stunned = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<DamageOnTriggerEnter>() != null)
		{
			if (stunByBommerang && other.tag == "p_boomerang")
			{
				if (!stunned)
				{
					StartCoroutine("stun");
				}
				return;
			}
		}
	}

	IEnumerator stun()
	{
		stunned = true;
		if (GetComponent<AIMovement2>() != null)
		{
			GetComponent<AIMovement2>().enabled = false;
			Debug.Log("begin stun");
			yield return new WaitForSeconds(stunTime);
			Debug.Log("end stun");
			GetComponent<AIMovement2>().enabled = true;
		}
		if (GetComponent<GoriyaMovement>() != null)
		{
			GetComponent<GoriyaMovement>().enabled = false;
			yield return new WaitForSeconds(stunTime);
			GetComponent<GoriyaMovement>().enabled = true;
		}
		stunned = false;
	}


}
