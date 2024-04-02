using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    private Vector2 rawInput;
    [SerializeField]
    private float moveSpeed = 5f;
    
    void Update()
    {
        Move();  
    }

    void Move()
    {
        Vector3 delta = rawInput;
        transform.position += delta * moveSpeed * Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
