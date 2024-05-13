using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController _controller;
    private Rigidbody2D _movementRb;

    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {        
        _controller = GetComponent<TopDownController>();
        _movementRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    //방향성
    private void Move(Vector2 vector)
    {
        _movementDirection = vector;
    }

    //물리 업데이트
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }
   
    private void ApplyMovement(Vector2 direction)
    {   
        //이동거리 증가
        direction = direction * 5;
        _movementRb.velocity = direction;
        //Debug.Log($"TopDownMovement, _movementRb.velocity {_movementRb.velocity}");
    }
}
