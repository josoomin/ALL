using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG3D
{
    public class Unit : MonoBehaviour
    {
        public float _maxHP = 100;
        public float _hp = 0;


        // 공격 효과음
        public AudioSource _sound_attack;

        //각종 붙어있는 콤포넌트들
        protected Animator m_Animater;
        BoxCollider _attackCol;
        
        void Start()
        {


            m_Animater = GetComponent<Animator>();

            if (this is Knight)
            {
                _attackCol = transform.Find("arm_R_weapon/Knight_handsword").GetComponent<BoxCollider>();

                if (_attackCol != null)
                {
                    // 시작할때 공격충돌체 꺼주기
                    _attackCol.enabled = false;
                }
            }

            if (this is Slime)
            {
                _attackCol = transform.Find("Body/AttackCol").GetComponent<BoxCollider>();

                if (_attackCol != null)
                {
                    // 시작할때 공격충돌체 꺼주기
                    _attackCol.enabled = false;
                }
            }

            //체력 초기화
            _hp = _maxHP;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Post-process Volume")
                return; // 포스트 프로세서 볼륨은 트리거 충돌체크 스킵

            if (other.gameObject.name.Contains("Terrain"))
                return; // 터레인과의 충돌 체크도 스킵한다.

            //string log = string.Format("this : {0}, other: {1}", this.gameObject.name, other);
            //Debug.Log(log);

            if (other.gameObject.tag == "AttackCol")
            {
                Debug.Log("슬라임이 " + other.gameObject.name + "과(와) 충돌");

                if (m_Animater != null)
                    m_Animater.SetTrigger("hit");

                _hp -= 10;

                if (_hp <= 0)
                {
                    m_Animater.SetTrigger("die");
                }
            }
        }

        protected void Attack()
        {
            if (m_Animater != null)
            {
                m_Animater.SetTrigger("attack");
            }

            //if (_sound_attack != null)
            //{
            //    _sound_attack.Play();
            //}
        }

        #region ANIMATION_EVENT

        public void SetAttackCol(int on) // 1 - on, 0 - off
        {
            if (_attackCol == null) // 공격 충돌체가 없다면 실행하지 않기
                return;

            if (on == 1)
            {
                _attackCol.enabled = true; // 공격 충돌체를 켠다
            }

            if (on == 0)
            {
                _attackCol.enabled = false; // 공격 충돌체를 꺼둔다
            }
        }

        public void AnimSound(string name)
        {
            if(name == "attack")
            {
                _sound_attack.Play();
            }
        }

        public void Die(int on)
        {
            Destroy(gameObject);
        }

        #endregion
    }
}