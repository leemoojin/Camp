using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;

    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {   
        //Random.Range(시작숫자, 끝숫자(포함안됨))
        //랜덤으로 0이나 1이 나오는데 0일때는 -1, 1일 때는 1이 할당된다
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rigidbody.velocity = new Vector2(x* speed, y* speed);
    }

    public void Reset()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Launch();
    }
}
