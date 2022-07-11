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

                //���� �浹ü�� �����Ҷ� ���д�.
                _attackCol.enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //rigidbody�� �ǵ���� ������ �̵�

            // 1.rigidbody.ADDForce �Լ�ȣ ��(���ӵ�)�� �־ �̵� - ���ӵ� � 
            // _rigid.AddForce(new Vector2(10, 0));

            // 2.rigidbody.velocity ����(x�ุ)�� ���� �ǵ帮�� ��� - ��ӵ� �

            bool isAttacking = _anim.GetBool("attack");

            if (isAttacking == true)
            {
                Vector2 vel = _rigid.velocity;
                vel.x = 0.0f;     //���� ���� ���� x�� �ӷ� 0
                _rigid.velocity = vel;
            }

            else
            {
                Vector2 vel = _rigid.velocity;

                vel.x = _speed;//x�� �ӵ��� ����

                if (_renderer.flipX == true)
                    vel.x = -1.0f * _speed;

                _rigid.velocity = vel;
            }

            //���� _enemyObj�� null �̸�, ���� ���� ã�´�!
            _enemyObj = FindEnemy();


            if (_enemyObj != null)
            {
                //�Ÿ� üũ �Լ� ȣ��
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

            //���� ã�� ���� ����

            //�� ����Ʈ(�迭)���� ���� �R��° ���� ã��
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

        void UpdateHpBarPos()  //ü�¹ٰ� �׻� ������ ���� �ٴϵ��� ��ġ ������Ʈ
        {
            // �� ������ ��ġ�� �����ͼ� (���� ������)
            Vector3 unitPos = transform.position;

            //���� ��ǥ�� ��ũ����ǥ(UI ��ǥ)�� ��ȯ
            Vector3 screenPos = Camera.main.WorldToScreenPoint(unitPos + _hpBarOffset);

            //��ȯ�� ��ũ����ǥ�� ü�¹��� rectTransform�� ����
            if (_hpBarTrans != null)
            {
                _hpBarTrans.position = screenPos;
            }
        }

        public void SetAttackCol(int on) // 1 - on, 0 - off
        {
            if (_attackCol == null)  //���� �浹ü�� ���ٸ� �������� �ʱ�
                return;

            if (on == 1)
            {
                _attackCol.enabled = true;  //���� �浹ü�� �Ҵ�
            }
            if (on == 0)
            {
                _attackCol.enabled = false; //���� �浹ü�� ����
            }
        }

        public override void DoDamage(int damage)
        {
            base.DoDamage(damage);

            if (_hp > 0.0f)
            {
                //��Ʈ �ִϸ��̼� ���
                _anim.SetTrigger("hit");
            }
            else
            {
                //���� �ִϸ��̼� ���
                _anim.SetBool("die", true);

                Invoke("Disappear", 1.5f);
            }
        }


        void CheckDistance() // �Ÿ��� üũ�ϴ� �Լ�
        {
            // ���� �� ĳ���Ͱ��� �Ÿ��� ����ؼ�, ������ ���ݹ��� �ȿ� ������ ����

            float pos1 = transform.position.x; // ���� ��ġ
            float pos2 = _enemyObj.transform.position.x; // ���� ��ġ

            float distance = Mathf.Abs(pos1 - pos2); // �� ĳ���� ���� �Ÿ� (�� x��ǥ ������ �Ÿ�)

            if (distance < _attackRange /* && _hp > 0 */) // ���ݹ��� �ȿ� ������
            {
                //����
                _anim.SetBool("attack", true);

                //������ ó��
                //Unit enemyUnit = _enemyObj.GetComponent<Unit>();
                //enemyUnit.DoDamage(10);
            }
            else  //���� ������ ����ų� ������
            {
                // �ٽ�, idle �� ��ȯ
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