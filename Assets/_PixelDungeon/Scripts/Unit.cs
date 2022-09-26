using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class Unit : MonoBehaviour
    {
        public int _hp;
        public int _maxHp;  //�ν����Ϳ��� �����ֱ�

        protected Animator _anim;

        protected virtual void Start()
        {
            _anim = GetComponent<Animator>();

            // ü�� �ʱ�ȭ
            _hp = _maxHp;
        }

        void Update()
        {
            
        }

        public void DoDamage(int damage)
        {
            _hp -= damage;
            UI_Manager.I.Gamelog._text.text = damage.ToString() + "�� �������� �޾ҽ��ϴ�.";

            if( _hp <= 0)
            {
                //���ӿ���ó��
                UI_Manager.I.Gameover.Show();
            }
        }
    }
}