using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float altura_salto;
    [SerializeField]
    private float velocidad_movimiento;
    private Animator animator;
    private Rigidbody2D rb;
    private bool toco_piso;
    private bool isRunning;
    private float input;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        toco_piso = c.gameObject.tag.Equals("Piso");
        animator.SetBool("jump", false);
    }


    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && (toco_piso))
        {
            rb.velocity = new Vector2(rb.velocity.x, altura_salto);
            toco_piso = false;
            animator.SetBool("jump", true);
        }

        if (input == 0)
        {
            isRunning = false;
            animator.SetBool("run", isRunning);
            rb.velocity = Vector2.zero;
        }
        else
        {
            if (input > 0)
            {
                isRunning = true;
                rb.velocity = new Vector2(velocidad_movimiento, rb.velocity.y)*Time.deltaTime;
                rb.transform.localScale = new Vector2(2.581018f, 2.581018f); //solucionar sprite debido a la escala//
                animator.SetBool("run", isRunning);
            }
            else
            {
                isRunning = true;
                rb.velocity = new Vector2(-velocidad_movimiento, rb.velocity.y)*Time.deltaTime;
                rb.transform.localScale = new Vector2(-2.581018f, 2.581018f);
                animator.SetBool("run", true);
            }
        }
    }
}
