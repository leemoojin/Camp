using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera _camera;

    private void Awake()
    {   
        //mainCamera 태그가 있는 카메라를 가져온다 
        _camera = Camera.main;
    }

    
    public void OnMove(InputValue value)
    {
        Debug.Log("OnMove" + value.ToString());

        //wasd 입력했을때 값이 value 로 온다
        //normalized 로 이동 거리를 정규화 한다
        Vector2 moveInput = value.Get<Vector2>().normalized;

        Debug.Log("OnMove moveInput" + moveInput);
        Debug.Log("OnMove position" + (Vector2)transform.position);

        CallMoveEvent(moveInput);
        //실제 움직이는 처리는 여기서 하는게 아니라 PlayerMovement 에서 한다
    }

    public void OnLook(InputValue value)
    {
        Debug.Log("OnLook" + value.ToString());

        //마우스 위치로 방향을 정할 때는 먼저 정규화하면 안된다
        Vector2 newAim = value.Get<Vector2>();
        //캐릭터의 방향에 따라 마우스 왼쪽 오른쪽 기준이 달라진다
        //마우스 위치는 화면 좌표계에 있기때문에 화면 좌표계로 변경해준다
        //카메라를 기준으로 마우스가 존재하는 스크린 좌표계에서 월드 좌표계로 변경해라
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        //여기서 정규화 해준다, 포지션 값을 왜 빼는지?
        newAim = (worldPos - (Vector2)transform.position).normalized;
        CallLookEvent(newAim);

        ////정규화를 했는데 실수로 변환이 필요한 이유를 모르겠음
        //if (newAim.magnitude >= .9f)
        //// Vector 값을 실수로 변환
        //{
        //    CallLookEvent(newAim);
        //}
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
        IsAttacking = value.isPressed;

    }

}
