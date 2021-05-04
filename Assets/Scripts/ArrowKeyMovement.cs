using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyMovement : MonoBehaviour
{

    Rigidbody rb;

    public float movement_speed = 4;

    float gridSize;

    public bool freezePosition;

    WeaponHolder weaponHolder;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gridSize = GameControl.instance.gridSize;
        freezePosition = false;
        rb = GetComponent<Rigidbody>();
        weaponHolder = GetComponentInChildren<WeaponHolder>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        rb.velocity = Vector3.zero;
        Vector2 current_input = GetInput();
        CheckActions();
        if (!freezePosition)
        {
            UpdatePosition(current_input);
        }
    }

    void UpdatePosition(Vector2 input)
    {
        if (Mathf.Abs(input.x) > 0.0f)
        {
            weaponHolder.transform.eulerAngles = new Vector3(0, 0, 90);
            if (input.x < 0)
            {
                weaponHolder.transform.eulerAngles = new Vector3(0, 0, -90);
            }
        }
        else if (Mathf.Abs(input.y) > 0.0f)
        {
            weaponHolder.transform.eulerAngles = new Vector3(0, 0, 0);
            if (input.y > 0)
            {
                weaponHolder.transform.eulerAngles = new Vector3(0, 0, 180);
            }
        }

        if (Mathf.Abs(input.x) > 0)
        {
            if(rb.position.y % gridSize == 0)
            {
                rb.position += new Vector3(input.x,0,0) * movement_speed * Time.deltaTime;
            } else
            {
                float nearestCorner = getNearestGrid(rb.position.y);
                if(rb.position.y < nearestCorner)
                {
                    rb.position += new Vector3(0, 1, 0) * movement_speed * Time.deltaTime;
                    if(rb.position.y > nearestCorner)
                    {
                        rb.position = new Vector3(rb.position.x, nearestCorner, rb.position.z);
                    }
                } else
                {
                    rb.position += new Vector3(0, -1, 0) * movement_speed * Time.deltaTime;
                    if (rb.position.y > nearestCorner)
                    {
                        rb.position = new Vector3(rb.position.x, nearestCorner, rb.position.z);
                    }
                }
            }
        } else if (Mathf.Abs(input.y) > 0)
        {
            if (rb.position.x % gridSize == 0)
            {
                rb.position += new Vector3(0, input.y, 0) * movement_speed * Time.deltaTime;
            }
            else
            {
                float nearestCorner = getNearestGrid(rb.position.x);
                if (rb.position.x < nearestCorner)
                {
                    rb.position += new Vector3(1, 0, 0) * movement_speed * Time.deltaTime;
                    if (rb.position.x > nearestCorner)
                    {
                        rb.position = new Vector3(nearestCorner, rb.position.y, rb.position.z);
                    }
                }
                else
                {
                    rb.position += new Vector3(-1, 0, 0) * movement_speed * Time.deltaTime;
                    if (rb.position.x > nearestCorner)
                    {
                        rb.position = new Vector3(nearestCorner, rb.position.y, rb.position.z);
                    }
                }
            }
        }
    }

    float getNearestGrid(float position)
    {
        float lowerGuess = ((int)(position / gridSize)) * gridSize;
        float higherGuess = lowerGuess + gridSize;
        if(Mathf.Abs(position-lowerGuess) < Mathf.Abs(higherGuess - position))
        {
            return lowerGuess;
        } else
        {
            return higherGuess;
        }
    }

    Vector2 GetInput()
    {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(horizontal_input) > 0.0f)
        {
            vertical_input = 0.0f;
        }

        return new Vector2(horizontal_input, vertical_input);
    }

    void CheckActions()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Slash))
        {
            weaponHolder.UseWeapon(0);
        }
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Period))
        {
            weaponHolder.UseWeapon(1);
        }
    }
}
