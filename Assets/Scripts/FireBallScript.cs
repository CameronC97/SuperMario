using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{

    private int fireballSpeed;
    private int xDirection;
    private int xDirection2;
    private int yDirection;
    private float count;

  
    // Start is called before the first frame update
    void Start()
    {
        fireballSpeed = 10;
        count = 0;
        checkMarioDirection();
        xDirection2 = xDirection;
        yDirection = -1;

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDirection, 0) * fireballSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        checkMarioDirection();
        

        count += Time.deltaTime;

        if (count >= 1f) {
            Destroy(gameObject);
        }



        if (transform.position.y < -5) {
            Destroy(gameObject);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xDirection2, 0));
      

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xDirection2,0) * fireballSpeed;

        if (hit.distance < 0.3f )
        {
            FlipFireball();
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Range Enemy") {
            Destroy(col.gameObject);
            Destroy(gameObject);

        }
    }


    void FlipFireball()
    {
        if (xDirection2 > 0)
        {
            xDirection2 = -1;
        }
        else
        {
            xDirection2 = 1;
        }

    }


    void checkMarioDirection()
    {
        if (PlayerController.rightFace)
        {
            xDirection = -1;
        }

        if (!PlayerController.rightFace) {
            xDirection = 1;
        }
    }
}
