using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class timere : MonoBehaviour
{
    public bool isRewinding = false;

    public float recordTime = 6f;

    List<pointintimeee> pointsintime;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {         pointsintime = new List<pointintimeee>();
      
        rb = GetComponent<Rigidbody2D>(); Vector3 Velocity = rb.velocity;
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            startRewinde();
        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();
                
    }
    private void FixedUpdate()
    {
        if (isRewinding)
            Rewinde();
        else
            Record();
    }
    void Rewinde()
    {
        if (pointsintime.Count > 0)
        {
           
            pointintimeee pointintime = pointsintime[0];
    
            rb.MovePosition(pointintime.position);
            rb.MoveRotation(pointintime.rotation.eulerAngles.z);
            pointsintime.RemoveAt(0);

        }
        else
        {
            StopRewind();
        }
        
    }
    void Record()
    {
        if(pointsintime.Count> Mathf.Round(recordTime/ Time.fixedDeltaTime))
        {
            pointsintime.RemoveAt(pointsintime.Count - 1);
        } 
        pointsintime.Insert(0, new pointintimeee(transform.position, transform.rotation));
    }
    public  void startRewinde()
    {
        rb.velocity = new Vector3(0, 0, 0);
        //rb.simulated = false;
        isRewinding = true;
        //rb.isKinematic = true;
        rb.gravityScale = 0;
    }
    public void StopRewind()
    {
        //rb.simulated = true;
        isRewinding = false;
        //rb.isKinematic = false;
        rb.gravityScale = 1;
    }
}
