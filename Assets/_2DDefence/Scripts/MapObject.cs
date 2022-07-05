using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Defance
{
    public enum Team
    {
        NONE,

        BLUE,
        RED,
    }

    public class MapObject : MonoBehaviour
    {
        public GameDirector _gameDir;

        public Team _team;

        public RectTransform _hpBarTrans;
        public Vector3 _hpBarOffset;
        public int _maxHp = 100;
        public int _hp = 0;

        public GameObject _hitEffTemplate; // �ǰ� ����Ʈ ����

        protected virtual void Start()
        {
            //���� ���� �ʱ�ȭ
            _gameDir = transform.parent.parent.GetComponent<GameDirector>();

            // ü�� �ʱ�ȭ
            _hp = _maxHp;

            RefreshHpBar();
            if (transform.parent != null) //�θ� �ִ� ��쿡��
            {
                //�� �ʱ�ȭ
                if (transform.parent.gameObject.name == "Red")
                {
                    _team = Team.RED;
                }
                else if (transform.parent.gameObject.name == "Blue")
                {
                    _team = Team.BLUE;
                }
            }
        }

        protected void RefreshHpBar() // ü�¹� ����
        {
            if (_hpBarTrans != null)
            {
                // fill �̹��� ������Ʈ ã��
                Image fill_img = _hpBarTrans.Find("fill").GetComponent<Image>();

                // �ִ� ü�� ��� ���� ü�� ������ fillAmout�� �־���
                fill_img.fillAmount = (float)_hp / (float)_maxHp;
            }
        }

        public virtual void DoDamage(int damage)
        {
            _hp = _hp - damage;

            _hp = Math.Max(_hp, 0); // _hp�� �ּҰ��� 0���� ����

            RefreshHpBar();

            // �ǰ� ��ƼŬ ����Ʈ ���
            if (_hitEffTemplate != null)
            {
                PlayHitEffect();
            }
        }

        void PlayHitEffect()
        {
            GameObject hitEffObj = Instantiate(_hitEffTemplate);
            hitEffObj.SetActive(true);
            hitEffObj.transform.position = transform.position; // ����Ʈ ��� ��ġ ����
                                                               //ParticleSystem ps = hitEffObj.GetComponent<ParticleSystem>();
                                                               //ps.Play();

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "AttackCol")
            {
                Arrow arrow = collision.gameObject.GetComponent<Arrow>();

                if (arrow != null) // ȭ���� ���
                {
                    if (arrow._team == _team)
                    {
                        return;
                    }

                    Destroy(arrow.gameObject);
                }
                else //ȭ���� �ƴ� ��� (��: �� �����浹ü)
                {
                    Unit attacker = collision.transform.parent.GetComponent<Unit>();
                    if (attacker != null)
                    {
                        if (attacker._team == _team)
                        {
                            return;
                        }
                    }
                }

                DoDamage(10);
            }
        }

        protected void Disappear()
        {
            if (_team == Team.RED)
            {
                //_gameDir._red_list //�迭���� ����
                List<GameObject> redList = new List<GameObject>(_gameDir._red_list);
                redList.Remove(gameObject); //����� �� �ڽ��� ���ְ�

                _gameDir._red_list = redList.ToArray();
            }
            else if (_team == Team.BLUE)
            {
                //_gameDir._blue_list // �迭���� ����
                List<GameObject> blueList = new List<GameObject>(_gameDir._blue_list);
                blueList.Remove(gameObject); //����� �� �ڽ��� ���ְ�

                _gameDir._blue_list = blueList.ToArray();
            }

            Destroy(gameObject);

            if (_hpBarTrans != null)
            {
                Destroy(_hpBarTrans.gameObject);
            }
        }
    }
}