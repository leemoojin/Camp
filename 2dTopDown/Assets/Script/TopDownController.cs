using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    //����2�� ���ڷ� �޴� �Լ��� ����
    //Action �� ������ void �� ��ȯ �ƴϸ� Func ���
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    //OnAttackEvent �� ���� �޴� ���� ���� �����ٴ� ��Ǹ� �߿��ϴ�
    public event Action OnAttackEvent;

    //������ ������ �󸶳� �������� ���� ���� ����
    private float _timeSinceLastAttack = float.MaxValue;

    //���콺 ���� ��ư�� Ŭ���ϸ� true
    protected bool IsAttacking { get; set; }

    private void Update()
    {   
        //���� ������
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        // TODO :: MAGIC NUMBER ����
        //���� < 0.2f �ϰ�� 0.2 �� ���������� ����
        if (_timeSinceLastAttack < 0.2f)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking)
        {
            //��ó�� Ŭ������ �� ȭ���� �߻��ϰ�
            //_timeSinceLastAttack �� �ƽ����� ���� ���� 0�� �ǰ�
            //0.2 �� ���� ������ �߻��Ѵ� (���� ������ ����)

            //������ �ð��ʰ� ���������� �����̺�Ʈ�� ȣ���ϰ�
            //�ٽ� 0�ʷ� �ǵ����� �ð��� ���Ѵ�
            _timeSinceLastAttack = 0f;            
            CallAttackEvent();
        }
    }



    //���� �̺�Ʈ�� �߻������� Invoke �ϴ� ����
    public void CallMoveEvent(Vector2 direction)
    {
        //?. ������ ���� ������ ����
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        //?. ������ ���� ������ ����
        OnLookEvent?.Invoke(direction);
    }
    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

}
