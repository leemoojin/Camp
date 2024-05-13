using System;
using UnityEngine;

//실제로 슈팅이 일어나는 부분을 정의
public class TopDownShooting : MonoBehaviour
{
    private TopDownController _controller;

    //projectile 은 투사체를 의미
    //어디서 총알이 생성될지 지정 - BulletSpawnPoint 오브젝트 위치
    [SerializeField] private Transform _projectileSpawnPosition;
    //기본자세로 서있을 때 플레이어의 오른쪽에 무기가 위치한다
    private Vector2 _aimDirection = Vector2.right;

    public GameObject TestPrefab;

    private void Awake()
    {
        _controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        // OnLookEvent에 이제 두개가 등록되는 것(하나는 지난 시간에 등록했었죠? TopDownAimRotation.OnAim(Vec2)
        // 한 개의 델리게이트에 여러 개의 함수가 등록되어있는 것을 multicast delegate라고 함.
        // Action이나 Func도 델리게이트의 일종
        _controller.OnLookEvent += OnAim;
    }

    //OnLookEvent 가 Vector2 값을 전달 받는 함수라서 매개변수가 있다.
    private void OnAim(Vector2 direction)
    {
        //마우스 위치를 이미 변환해둔 값이 있다 (PlayerInputController)
        //마우스 움직일때마다 _aimDirection 값이 변경된다
        _aimDirection = direction;
    }


    //공격 메서드
    private void OnShoot()
    {
        //투사체 생성
        CreateProjectile();
    }

    //공격을 위한 투사체 생성 메서드
    private void CreateProjectile()
    {
        //프리펩을 이용, Quaternion.identity : 회전값이 없다
        // TODO :: 날라가지 않기때문에 날라가게 만들 것임
        //화살이 실제로 날라가게 구현 / 오브젝트 풀을 통한 구조 개선
        Instantiate(TestPrefab, _projectileSpawnPosition.position, Quaternion.identity);
    }
}
