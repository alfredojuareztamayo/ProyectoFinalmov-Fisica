using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Variables for the movement")]
    public float MoveH;
    public float MoveV;
    public float speed;
    public float angleRotation;
    Rigidbody rb;

    [Header("Vectores")]
    public Vector3 direction;
    public Vector3 movement;

    [Header("Animation")]
    Animator animator;
 
    void Start()
    {
        speed = 2f;
        angleRotation = 150f;
        rb = GetComponent<Rigidbody>();
       animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        MoveH = Input.GetAxis("Horizontal"); //Para que regrese un valor a 1 si se ueve en el axis horizontal
        MoveV = Input.GetAxis("Vertical"); //Regresa el valor de 1 si se mueve en el axis vertical
        MoveFPC();
        setAnimation();


    }

    public void MoveFPC()
    {
        if(MoveV != 0 || MoveH != 0)
        {
            direction = (transform.forward * MoveV) + ( transform.right * MoveH);
            direction.Normalize();

            movement = direction * speed;
            transform.Rotate((transform.up * MoveH) * angleRotation * Time.fixedDeltaTime);
        }
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    public void setAnimation()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            speed = 4f;
            animator.SetBool("isWalking", true);
        }
        else
        {
            speed = 2f;
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.W))
        {
            speed = 6f;
            animator.SetBool("isRunnig", true);
           

        }
        else
        {
            speed = 2f;
            animator.SetBool("isRunnig", false);

        }
        
    }
}
