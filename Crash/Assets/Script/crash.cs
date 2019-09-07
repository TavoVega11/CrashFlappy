using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    private bool estaMuerto;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float upForce = 200f;

    private RotateCrash rotateCrash;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotateCrash = GetComponent<RotateCrash>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (estaMuerto) return;
        
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up * upForce);
                anim.SetTrigger("Flap");
            SoundSystem.instance.PlayFlap();
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        estaMuerto = true;
        anim.SetTrigger("Die");
        rotateCrash.enabled = false;
        GameController.instance.crashDie();
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayHit();
    }
}
