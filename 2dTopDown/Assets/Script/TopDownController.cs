using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    //벡터2를 인자로 받는 함수를 생성
    //Action 은 무조건 void 만 반환 아니면 Func 사용
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    //OnAttackEvent 는 전달 받는 값이 없다 눌렀다는 사실만 중요하다
    public event Action OnAttackEvent;

    //마지막 공격후 얼마나 지났는지 값을 담을 변수
    private float _timeSinceLastAttack = float.MaxValue;

    //마우스 왼족 버튼을 클릭하면 true
    protected bool IsAttacking { get; set; }

    private void Update()
    {   
        //공격 딜레이
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        // TODO :: MAGIC NUMBER 수정
        //값이 < 0.2f 일경우 0.2 초 지날때마다 공격
        if (_timeSinceLastAttack < 0.2f)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking)
        {
            //맨처은 클릭했을 때 화살이 발사하고
            //_timeSinceLastAttack 가 맥스벨류 였던 값이 0이 되고
            //0.2 가 넘을 때마다 발사한다 (공격 딜레이 역할)

            //조건의 시간초가 넘을때마다 공격이벤트를 호출하고
            //다시 0초로 되돌리고 시간을 더한다
            _timeSinceLastAttack = 0f;            
            CallAttackEvent();
        }
    }



    //무브 이벤트가 발생했을때 Invoke 하는 역할
    public void CallMoveEvent(Vector2 direction)
    {
        //?. 없으면 말고 있으면 실행
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        //?. 없으면 말고 있으면 실행
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

}
