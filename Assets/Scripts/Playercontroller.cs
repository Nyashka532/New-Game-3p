using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Playercontroller : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;
    public int x;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        //Movement
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }

    }
    void FixedUpdate()
    {
        //Movement
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);
          
        //Fall & Jump
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        // Stop fall if on ground
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;

        }
    }

}
