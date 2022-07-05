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

        public GameObject _hitEffTemplate; // 피격 이펙트 원본

        protected virtual void Start()
        {
            //게임 디렉터 초기화
            _gameDir = transform.parent.parent.GetComponent<GameDirector>();

            // 체력 초기화
            _hp = _maxHp;

            RefreshHpBar();
            if (transform.parent != null) //부모가 있는 경우에만
            {
                //팀 초기화
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

        protected void RefreshHpBar() // 체력바 갱신
        {
            if (_hpBarTrans != null)
            {
                // fill 이미지 콤포넌트 찾기
                Image fill_img = _hpBarTrans.Find("fill").GetComponent<Image>();

                // 최대 체력 대비 현재 체력 비율을 fillAmout에 넣어줌
                fill_img.fillAmount = (float)_hp / (float)_maxHp;
            }
        }

        public virtual void DoDamage(int damage)
        {
            _hp = _hp - damage;

            _hp = Math.Max(_hp, 0); // _hp의 최소값을 0으로 제한

            RefreshHpBar();

            // 피격 파티클 이펙트 재생
            if (_hitEffTemplate != null)
            {
                PlayHitEffect();
            }
        }

        void PlayHitEffect()
        {
            GameObject hitEffObj = Instantiate(_hitEffTemplate);
            hitEffObj.SetActive(true);
            hitEffObj.transform.position = transform.position; // 이펙트 재생 위치 설정
                                                               //ParticleSystem ps = hitEffObj.GetComponent<ParticleSystem>();
                                                               //ps.Play();

        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "AttackCol")
            {
                Arrow arrow = collision.gameObject.GetComponent<Arrow>();

                if (arrow != null) // 화살인 경우
                {
                    if (arrow._team == _team)
                    {
                        return;
                    }

                    Destroy(arrow.gameObject);
                }
                else //화살이 아닌 경우 (예: 검 공격충돌체)
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
                //_gameDir._red_list //배열에서 삭제
                List<GameObject> redList = new List<GameObject>(_gameDir._red_list);
                redList.Remove(gameObject); //사망한 나 자신을 빼주고

                _gameDir._red_list = redList.ToArray();
            }
            else if (_team == Team.BLUE)
            {
                //_gameDir._blue_list // 배열에서 삭제
                List<GameObject> blueList = new List<GameObject>(_gameDir._blue_list);
                blueList.Remove(gameObject); //사망한 나 자신을 빼주고

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