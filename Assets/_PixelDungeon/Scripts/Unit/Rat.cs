using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class Rat : Unit
    {
        public AudioSource _hitSnd;

        protected override void Start()
        {
            base.Start();

            _hitSnd = GetComponent<AudioSource>();
        }

        void Update()
        {
            
        }

        public void Attack()
        {
            // 어택 애니메이션 재생
            _anim.SetTrigger("Attack");
            
            // 어택 효과음 재생
            _hitSnd.Play();

            // TODO: 공격 파티클 이펙트 재생
        }
    }
}