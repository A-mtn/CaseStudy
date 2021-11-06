using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    protected Joystick joystick;
    private Rigidbody rb;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {

        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = joystick.Horizontal;
        float Vertical = joystick.Vertical;
        Vector3 moveDir = new Vector3(Horizontal, 0, Vertical);

        rb.AddForce(moveDir * speed);
        
        
    }
}
