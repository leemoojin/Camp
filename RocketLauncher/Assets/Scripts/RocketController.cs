using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    //private EnergySystem _energySystem;
    //private RocketMovement _rocketMovement;

    //private bool _isMoving;
    //private Vector2 _movementDirection;

    public event Action<Vector2> OnMoveEvent;

    
    private void Awake()
    {
        //_energySystem = GetComponent<EnergySystem>();
        //_rocketMovement = GetComponent<RocketMovement>();
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    // TODO : OnMove 구현
    private void OnMove(InputValue direction)
    {
    
    }


    // TODO : OnBoost 구현
    // private void OnBoost...
    //private void OnBoost(InputValue value)
    //{
    //    _rocketMovement.ApplyBoost(value.isPressed);
    //}
}