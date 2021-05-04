using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindControlOnTriggerEnter : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GameControl.instance.player.GetComponent<SpriteRenderer>().color = GameControl.instance.mindControlColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameControl.instance.player.GetComponent<Knockback>().invincible)
        {
            return;
        }
        if (other.GetComponent<ControlableMovement>())
        {
            other.GetComponent<ArrowKeyMovement>().enabled = true;
            other.GetComponent<AIMovement>().enabled = false;
            other.GetComponent<BoxCollider>().isTrigger = false;
            other.GetComponent<EnemyCollector>().NoUse = false;
            other.GetComponent<Animator>().speed = 1;
            other.GetComponent<SpriteRenderer>().color = GameControl.instance.mindControlColor;
            other.GetComponent<Health>().isPlayer = true;
            GameControl.instance.particleEffect.transform.position = other.transform.position + new Vector3(0, 0, -1);
            GameControl.instance.particleEffect.transform.parent = other.transform;
            GameControl.instance.player.GetComponent<SpriteRenderer>().color = GameControl.instance.startingColor;
            GameControl.instance.player.GetComponent<ArrowKeyMovement>().enabled = false;
            GameControl.instance.player.GetComponent<InputToAnimator>().enabled = false;
            GameControl.instance.player.GetComponent<Animator>().speed = 0;
            GameControl.instance.mainHandWeapon.sprite = other.GetComponent<ControlableMovement>().weaponImage;
        }
    }
}
