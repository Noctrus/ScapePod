using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D _rig;
    public float walk;
    public float jump;
    public bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_rig.velocity.magnitude);
   
        if (Input.GetKey(KeyCode.LeftArrow) )
        {
          _rig.AddForce(-transform.right * 5);
        }

        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rig.AddForce(transform.right * 5);   
        }

        if (_rig.velocity.magnitude > 3f)
        {
            _rig.velocity = Vector3.ClampMagnitude(_rig.velocity, 3f);
        }






        if (Input.GetKeyDown(KeyCode.Space) && onGround) {
           
            _rig.AddForce(transform.up * jump);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }
}
