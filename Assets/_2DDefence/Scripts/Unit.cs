using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float _speed = 0.5f;
    public float _attackRange = 1.75f;

    public GameObject _enemyObj;

    Rigidbody2D _rigid;
    SpriteRenderer _renderer;
    Animator _anim;
    Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody를 건드려서 앞으로 이동

        // 1.rigidbody.ADDForce 함수호 힘(가속도)을 주어서 이동 - 가속도 운동 
        // _rigid.AddForce(new Vector2(10, 0));

        // 2.rigidbody.velocity 변수(x축만)를 직접 건드리는 방법 - 등속도 운동
        Vector2 vel = _rigid.velocity;
        vel.x = _speed;//x축 속도만 강제

        if (_renderer.flipX == true)
            vel.x = -1.0f * _speed;

        _rigid.velocity = vel;

        if (_enemyObj != null)
        {
            //거리 체크 함수 호출
            CheckDistance();
        }
    }

    void CheckDistance() // 거리를 체크하는 함수
    {
        // 나와 적 캐릭터간의 거리를 계산해서, 설정된 공격범위 안에 들어오면 공격

        float pos1 = transform.position.x; // 나의 위치
        float pos2 = _enemyObj.transform.position.x; // 적의 위치

        float distance = Mathf.Abs(pos1 - pos2); // 두 캐릭터 간의 거리 (두 x좌표 사이의 거리)

        if (distance < _attackRange) // 공격범위 안에 들어오면
        {
            //공격
            _anim.SetBool("attack", true);
        }
        else
        {
            // 다시, idle 로 전환
            _anim.SetBool("attack", false);
        }
    }
}
