using System;
using UnityEngine;

public class TopDownAimRotaion : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _armRenderer;
    [SerializeField] private Transform _armPivot;

    //에임에 따라서 캐릭터 이미지, 무기 이미지가 뒤집혀야한다
    [SerializeField] private SpriteRenderer _characterRenderer;

    //이벤트 등록을 위해 TopDownController 를 추가한다
    private TopDownController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownController>();
    }

    private void Start()
    {   
        //OnAim 함수를 등록
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        //오일러에 넣기 위해서는 라디안 값을 디그리 값으로 변환해주어야한다
        //Mathf.Atan2(direction.y, direction.x)
        //-> 캐릭터가 마우스를 바라보는 좌표로 각도를 구한다(라디안 값)
        float roZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //각도가 절대값으로 90도를 넘어가면 캐릭터 이미지를 x축으로 뒤집는다
        _characterRenderer.flipX = Math.Abs(roZ) > 90f;
        
        _armPivot.rotation = Quaternion.Euler(0, 0, roZ);
    }
}
