using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewspanblock : MonoBehaviour
{
    Rigidbody2D rb;
    public int upamount = 5;
    private void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.tag == "respawn")
        {
            Invoke("movetoabove" ,5f);
         
        }
    }
    void movetoabove()
    {
        transform.position += Vector3.up * upamount;
    }
}
