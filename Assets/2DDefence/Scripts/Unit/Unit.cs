using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Defance
{
    public class Unit : MapObject
    {
        public float _speed = 0.5f;
        public float _attackRange = 1.75f;

        public GameObject _enemyObj;

        Rigidbody2D _rigid;
        SpriteRenderer _renderer;
        Animator _anim;
        Transform _transform;
        BoxCollider2D _attackCol;

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();

            _rigid = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _anim = GetComponent<Animator>();

            Transform childTrans = transform.Find("AttackCol");
            if (childTrans != null)
            {
                _attackCol = childTrans.GetComponent<BoxCollider2D>();

                //공격 충돌체는 시작할때 꺼둔다.
                _attackCol.enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //rigidbody를 건드려서 앞으로 이동

            // 1.rigidbody.ADDForce 함수호 힘(가속도)을 주어서 이동 - 가속도 운동 
            // _rigid.AddForce(new Vector2(10, 0));

            // 2.rigidbody.velocity 변수(x축만)를 직접 건드리는 방법 - 등속도 운동

            bool isAttacking = _anim.GetBool("attack");

            if (isAttacking == true)
            {
                Vector2 vel = _rigid.velocity;
                vel.x = 0.0f;     //공격 중일 때는 x축 속력 0
                _rigid.velocity = vel;
            }

            else
            {
                Vector2 vel = _rigid.velocity;

                vel.x = _speed;//x축 속도만 강제

                if (_renderer.flipX == true)
                    vel.x = -1.0f * _speed;

                _rigid.velocity = vel;
            }

            //만일 _enemyObj가 null 이면, 다음 적을 찾는다!
            _enemyObj = FindEnemy();


            if (_enemyObj != null)
            {
                //거리 체크 함수 호출
                CheckDistance();
            }
            else
            {
                _anim.SetBool("attack", false);
            }
            UpdateHpBarPos();
        }

        GameObject FindEnemy()
        {
            GameObject enemyObj = null;

            //적을 찾는 로직 구현

            //적 리스트(배열)에서 가장 첮번째 것을 찾기
            /*if (_enemyList != null && _enemyList.Length > 0)
            {
                enemyObj = _enemyList[0];
            }*/

            if (_team == Team.BLUE)
            {
                if (_gameDir._red_list.Length > 0)
                {
                    enemyObj = _gameDir._red_list[0];
                }
            }
            else if (_team == Team.RED)
            {
                if (_gameDir._blue_list.Length > 0)
                {
                    enemyObj = _gameDir._blue_list[0];
                }
            }
            return enemyObj;
        }

        void UpdateHpBarPos()  //체력바가 항상 유닛을 따라 다니도록 위치 업데이트
        {
            // 이 유닛의 위치를 가져와서 (월드 포지션)
            Vector3 unitPos = transform.position;

            //월드 좌표를 스크린좌표(UI 좌표)로 변환
            Vector3 screenPos = Camera.main.WorldToScreenPoint(unitPos + _hpBarOffset);

            //변환된 스크린좌표를 체력바의 rectTransform에 적용
            if (_hpBarTrans != null)
            {
                _hpBarTrans.position = screenPos;
            }
        }

        public void SetAttackCol(int on) // 1 - on, 0 - off
        {
            if (_attackCol == null)  //공격 충돌체가 없다면 실행하지 않기
                return;

            if (on == 1)
            {
                _attackCol.enabled = true;  //공격 충돌체를 켠다
            }
            if (on == 0)
            {
                _attackCol.enabled = false; //공격 충돌체를 끈다
            }
        }

        public override void DoDamage(int damage)
        {
            base.DoDamage(damage);

            if (_hp > 0.0f)
            {
                //히트 애니메이션 재생
                _anim.SetTrigger("hit");
            }
            else
            {
                //다이 애니메이션 재생
                _anim.SetBool("die", true);

                Invoke("Disappear", 1.5f);
            }
        }


        void CheckDistance() // 거리를 체크하는 함수
        {
            // 나와 적 캐릭터간의 거리를 계산해서, 설정된 공격범위 안에 들어오면 공격

            float pos1 = transform.position.x; // 나의 위치
            float pos2 = _enemyObj.transform.position.x; // 적의 위치

            float distance = Mathf.Abs(pos1 - pos2); // 두 캐릭터 간의 거리 (두 x좌표 사이의 거리)

            if (distance < _attackRange /* && _hp > 0 */) // 공격범위 안에 들어오면
            {
                //공격
                _anim.SetBool("attack", true);

                //데미지 처리
                //Unit enemyUnit = _enemyObj.GetComponent<Unit>();
                //enemyUnit.DoDamage(10);
            }
            else  //공격 범위를 벗어나거나 죽으면
            {
                // 다시, idle 로 전환
                _anim.SetBool("attack", false);
            }
        }

        public void OnAttack()
        {
            Attack();
        }

        protected virtual void Attack()
        {

        }
    }
}