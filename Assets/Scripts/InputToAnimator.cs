using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToAnimator : MonoBehaviour
{

    public Animator animator;

    public bool overRideGo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        overRideGo = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontal_input", Input.GetAxisRaw("Horizontal"));
        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetFloat("vertical_input", Input.GetAxisRaw("Vertical"));
        } else
        {
            animator.SetFloat("vertical_input", 0);
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && !overRideGo)
        {
            animator.speed = 0.0f;
        } else
        {
            animator.speed = 1.0f;
        }
    }
}
