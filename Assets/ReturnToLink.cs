using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToLink : Weapon
{
    protected override void OnUse()
    {
        base.OnUse();
        health.GetComponent<ArrowKeyMovement>().enabled = false;
        health.GetComponent<AIMovement>().enabled = true;
        health.GetComponent<BoxCollider>().isTrigger = true;
        health.GetComponent<EnemyCollector>().NoUse = true;
        health.GetComponent<SpriteRenderer>().color = GameControl.instance.startingColor;
        health.isPlayer = false;
        GameControl.instance.particleEffect.transform.position = GameControl.instance.player.transform.position + new Vector3(0, 0, -1);
        GameControl.instance.particleEffect.transform.parent = GameControl.instance.player.transform;
        GameControl.instance.player.GetComponent<SpriteRenderer>().color = GameControl.instance.mindControlColor;
        GameControl.instance.player.GetComponent<ArrowKeyMovement>().enabled = true;
        GameControl.instance.player.GetComponent<InputToAnimator>().enabled = true;
        GameControl.instance.player.GetComponent<Animator>().speed = 1;
        GameControl.instance.mainHandWeapon.sprite = GameControl.instance.startingMainHandWeapon;
    }
}
