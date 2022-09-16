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

            if (_anim.GetBool("eating") == false) //먹는 동작(애니메이션)하고 있는 중이 아니라면....
            {
                Move(h, v);
            }
        }

        void Move(float h, float v)
        {
            Vector2 dir = new Vector2(h, v); //방향 벡터

            // 이동 거리 = 방향벡터 * 스피드

            //이동
            transform.Translate(dir * _speed * Time.deltaTime);
        }
    }
}