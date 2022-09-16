using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class Player : MonoBehaviour
    {
        [SerializeField]float _speed = 1.0f;
        Animator _anim;

        void Start()
        {
            _anim = GetComponent<Animator>();
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (h == 0 && v == 0)
            {
                _anim.SetBool("Run", false);
            }
            else
            {
                _anim.SetBool("Run", true);
            }

            if (_anim.GetBool("eating") == false) //�Դ� ����(�ִϸ��̼�)�ϰ� �ִ� ���� �ƴ϶��....
            {
                Move(h, v);
            }
        }

        void Move(float h, float v)
        {
            Vector2 dir = new Vector2(h, v); //���� ����

            // �̵� �Ÿ� = ���⺤�� * ���ǵ�

            //�̵�
            transform.Translate(dir * _speed * Time.deltaTime);
        }
    }
}