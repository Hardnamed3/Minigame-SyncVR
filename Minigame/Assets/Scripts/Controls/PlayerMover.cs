using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private InputHandler _input;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float SprintSpeed;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TwotoThreeVector = new Vector3(_input.InputVector2.x, 0, _input.InputVector2.y);

        //turn based on input
        if (Time.timeScale> 0f)//not when paused
        {
            transform.rotation = Quaternion.LookRotation(TwotoThreeVector);
        }
        

        //movement
        MoveTowardTarget(TwotoThreeVector);

    }

    private void MoveTowardTarget(Vector3 twotoThreeVector)
    {
        float speed = MoveSpeed * Time.deltaTime;
        

        if (_input.sprint)
        {
            if (transform.hasChanged)
            {
                GetComponent<Animator>().SetBool("IsSprinting", true);
                GetComponent<Animator>().SetBool("IsMoving", false);
                transform.hasChanged = false;
            }
            else
            {
                GetComponent<Animator>().SetBool("IsSprinting", false);
                GetComponent<Animator>().SetBool("IsMoving", false);
            }
            transform.Translate(twotoThreeVector * speed * SprintSpeed, Space.World);
        }
        else
        {
            if (transform.hasChanged)
            {
                GetComponent<Animator>().SetBool("IsSprinting", false);
                GetComponent<Animator>().SetBool("IsMoving", true);
                transform.hasChanged = false;
            }
            else
            {
                GetComponent<Animator>().SetBool("IsSprinting", false);
                GetComponent<Animator>().SetBool("IsMoving", false);
            }
            transform.Translate(twotoThreeVector * speed, Space.World);
        }
        
    }
}
