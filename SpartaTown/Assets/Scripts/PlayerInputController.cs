using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    //lookMouse
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        
    }

    //Input
    public void OnMove(InputValue value)
    {
        //Debug.Log($"PlayerInputController, OnMove value: {value}");
        Vector2 moveInput = value.Get<Vector2>().normalized;
        //Debug.Log($"PlayerInputController, OnMove moveInput: {moveInput}");

        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value) 
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = worldPos - ((Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

}
