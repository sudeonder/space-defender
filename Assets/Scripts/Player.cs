using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    private Vector2 rawInput;
    [SerializeField]
    private float moveSpeed = 5f;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    [SerializeField]
    private float leftPadding;
    [SerializeField]
    private float rightPadding;
    [SerializeField]
    private float topPadding;
    [SerializeField]
    private float bottomPadding;
    private Shooter shooter;

    void Start()
    {
        InitBounds();
        shooter = GetComponent<Shooter>();
    }
    
    void Update()
    {
        Move();  
    }

    private void InitBounds()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + topPadding, maxBounds.y - bottomPadding);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFire = value.isPressed;
        }
    }
}
