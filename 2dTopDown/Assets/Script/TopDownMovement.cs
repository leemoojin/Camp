using System;
using UnityEngine;

// TopDownMovement는 캐릭터와 몬스터의 이동에 사용될 예정입니다.
public class TopDownMovement : MonoBehaviour
{
    //실제로 이동이 일어날 컴포넌트

    private TopDownController _controller;
    private Rigidbody2D _movementRigidbody;

    //오류 방지를 위한 기본값 입력 (이동 안할때는 제로)
    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {
        //Awake 는 주로 내 컴포넌트안에서 끝나는거
        //다른 컴포넌트의 값을 변경하는 것을 잘 하지 않는다

        //컨트롤러 캐싱
        //controller 와 TopDownController 가 같은 오브젝트안에 있다라는 가정 하에 가능
        //아니면 게임 오브젝트 파인드 사용 해야한다
        // 같은 게임오브젝트의 TopDownController, Rigidbody를 가져올 것 
        _controller = GetComponent<TopDownController>();
        _movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //OnMoveEvent 는 입력이있을때마다 실행된다
        // OnMoveEvent 에 Move를 호출하라고 등록함
        _controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        //Move는 Update 베이스로 돈다 프레임 기반

        // 이동방향만 정해두고 실제로 움직이지는 않음.
        // 움직이는 것은 물리 업데이트에서 진행(rigidbody가 물리니까)

        //Move함수는 onMoveEvent에 등록 되어있다 (Start 에서 더했다)
        _movementDirection = direction;

    }

    private void FixedUpdate()
    {
        //FixedUpdate 는 물리 업데이트
        //rigidbody 의 값을 변경하니까
        //실제 움직임을 처리
        ApplyMovement(_movementDirection);
        //movementDirection 는 Move라는 함수에 들어있다
        //움직임의 입력이 있을 때마다 onMoveEvent 호출되어 movementDirection가 갱신
    }


    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        _movementRigidbody.velocity = direction; 

    }
}
