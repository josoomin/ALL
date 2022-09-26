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
            // ���� �ִϸ��̼� ���
            _anim.SetTrigger("Attack");
            
            // ���� ȿ���� ���
            _hitSnd.Play();

            // TODO: ���� ��ƼŬ ����Ʈ ���
        }
    }
}