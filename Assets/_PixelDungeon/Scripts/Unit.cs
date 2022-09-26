using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class Unit : MonoBehaviour
    {
        public int _hp;
        public int _maxHp;  //인스펙터에서 정해주기

        protected Animator _anim;

        protected virtual void Start()
        {
            _anim = GetComponent<Animator>();

            // 체력 초기화
            _hp = _maxHp;
        }

        void Update()
        {
            
        }

        public void DoDamage(int damage)
        {
            _hp -= damage;
            UI_Manager.I.Gamelog._text.text = damage.ToString() + "의 데미지를 받았습니다.";

            if( _hp <= 0)
            {
                //게임오버처리
                UI_Manager.I.Gameover.Show();
            }
        }
    }
}