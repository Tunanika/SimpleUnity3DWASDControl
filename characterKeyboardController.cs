using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterKeyboardController : MonoBehaviour
{

    private Boolean jumpBln=true;
    public float jmpHeight=5f, walkSpeed=0.05f;



    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        //Walk
        if (Input.GetKey(KeyCode.W))
        {
            UnityEngine.Debug.Log("DEBUG: " + "W");
            walkW();
        }
        if (Input.GetKey(KeyCode.A))
        {
            UnityEngine.Debug.Log("DEBUG: " + "A");
            walkA();
        }
        if (Input.GetKey(KeyCode.S))
        {
            UnityEngine.Debug.Log("DEBUG: " + "S");
            walkS();
        }
        if (Input.GetKey(KeyCode.D))
        {
            UnityEngine.Debug.Log("DEBUG: " + "D");
            walkD();
        }
    }

    private void jump()
    {
        if (jumpBln)
        {
            jumpBln = false;
            transform.position += new Vector3(0 ,1*jmpHeight, 0);
            UnityEngine.Debug.Log("DEBUG: " + "Jump");
            StartCoroutine(jumpTimer());
        }
        else
        {
            UnityEngine.Debug.Log("DEBUG: " + "Unable to jump");
        }
    }

    private void walkW()
    {
        transform.position += new Vector3(0,0,1*walkSpeed);
    }
    private void walkA()
    {
        transform.position += new Vector3(-1*walkSpeed, 0, 0);
    }
    private void walkS()
    {
        transform.position += new Vector3(0, 0,-1 * walkSpeed);
    }
    private void walkD()
    {
        transform.position += new Vector3(1*walkSpeed, 0,0);
    }

    //Timers
    private IEnumerator jumpTimer()
    {
        yield return new WaitForSeconds(1);
        jumpBln = true;
    }
}
