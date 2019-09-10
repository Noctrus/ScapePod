using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public Rigidbody2D _rig;
    public float walk;
    public float jump;
    public bool onGround;

    public Animator _anim;

    public float angle;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Debug.Log(_rig.velocity);

        float input = Input.GetAxis("Horizontal"); 
        speed= input * walk;
        
        if (input < -0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
         
        }
        else if (input > 0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Mathf.Abs(speed) > 0.0001f)
        {
            _anim.SetBool("walk", true);
        }
        else {
            _anim.SetBool("walk", false);
        }
    
         
        

        if (onGround)
        {
            _rig.velocity = new Vector3(speed, _rig.velocity.y, 0);
        }
        else {
            _rig.velocity = new Vector3(speed, _rig.velocity.y, 0);
        }

    

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _rig.AddForce(new Vector3(0, jump, 0));
            onGround = false;

        }
    }   
}
