using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
    private Rigidbody2D rb;
    private Vector2 _movementInput;
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate(){
        rb.velocity = _movementInput * _speed;
    }
    
    private void OnMove(InputValue inputValue){
        _movementInput = inputValue.Get<Vector2>();
    }
}
