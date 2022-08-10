using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public int jumpAmount;
    public bool Grounded=true;
    bool canDash = true;
    bool isDashing;
    float DashingPower = 30f;
    float DashingTime = 0.3f;
    float DashingCooldown = 1f;


    void Start()
    {
        Grounded = true;
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        
        if(Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            //allow the player to jump once until theyre gronuded again

                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                Grounded = false;
          
           
        }
        //make the player crouch/slide down
        if (Input.GetKeyDown(KeyCode.D) && canDash)
        {
            StartCoroutine(DashingDown());
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag ("Ground"))
        {
            Grounded = true;
        }
    }
    IEnumerator DashingDown()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(0f, -transform.localScale.y * DashingPower);
        yield return new WaitForSeconds(DashingTime);
        isDashing = false;
        yield return new WaitForSeconds(DashingCooldown);
        canDash = true;
    }


    public void JumpImplementation()
    {
        if(Grounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            Grounded = false;
        }
       
    }

    public void DashDownImplementation()
    {
        if(canDash)
        {
            StartCoroutine(DashingDown());
        }
       
    }

}
