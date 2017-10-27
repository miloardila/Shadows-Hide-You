using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float altura_salto;
    public float velocidad_movimiento;
    private Rigidbody2D rb;
    private bool toco_piso;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        toco_piso = c.gameObject.tag.Equals("Piso");
    }
 
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && (toco_piso))
		{
			rb.velocity = new Vector2 (rb.velocity.x, altura_salto);
            toco_piso = false;
		}
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocidad_movimiento, rb.velocity.y);
            rb.transform.localScale = new Vector2(2.581018f, 2.581018f); //solucionar sprite debido a la escala//
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocidad_movimiento,rb.velocity.y);
            rb.transform.localScale = new Vector2(-2.581018f, 2.581018f);
        }
    }
}
