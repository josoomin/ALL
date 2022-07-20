using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

namespace RPG3D
{
    [Serializable]
    public class PlayerStat
    {
        public int _STR;
        public int _MAG;
        public int _AGT;
        public int _ATK;
        public int _DEF;
    }

    public class Player : Unit
    {
        [SerializeField] float _jumpForce = 100.0f;
        ThirdPersonCharacter _chatecter;

        public uiManager _uiMgr;



        [Header("---------스 탯 ---------")]
        public PlayerStat _stat;


        public AnimationCurve _expCurve; //유니티에서 제공하는 곡선 그래프
        public int _maxLevel;
        public int _level;

        public long _maxExp;
        public long _exp;



        protected override void Start()
        {
            base.Start();

            _chatecter = GetComponent<ThirdPersonCharacter>();

            if (PlayerPrefs.HasKey("STAT_STRENGTH")) //이미 스탯 랜덤 결정을 한 적이 있음
            {
                _stat._STR = PlayerPrefs.GetInt("STAT_STRENGTH");
                _stat._MAG = PlayerPrefs.GetInt("STAT_MAGIC");
                _stat._AGT = PlayerPrefs.GetInt("STAT_AGILITY");
                _stat._ATK = PlayerPrefs.GetInt("STAT_ATTACK");
                _stat._DEF = PlayerPrefs.GetInt("STAT_DEFENSE");
            }
            else // 게임을 처음 실행하는 상태(스탯 주사위 굴림 필요)
            {
                _stat._STR = UnityEngine.Random.Range(5, 10);
                _stat._MAG = UnityEngine.Random.Range(5, 10);
                _stat._AGT = UnityEngine.Random.Range(5, 10);
                _stat._ATK = UnityEngine.Random.Range(5, 10);
                _stat._DEF = UnityEngine.Random.Range(5, 10);

                SaveStat();
            }
        }

        public void SaveStat()
        {
            PlayerPrefs.SetInt("STAT_STRENGTH", _stat._STR);
            PlayerPrefs.SetInt("STAT_MAGIC", _stat._MAG);
            PlayerPrefs.SetInt("STAT_AGILITY", _stat._AGT);
            PlayerPrefs.SetInt("STAT_ATTACK", _stat._ATK);
            PlayerPrefs.SetInt("STAT_DEFENSE", _stat._DEF);
        }


        protected override void ProcessHit(int Damage)
        {
            base.ProcessHit(Damage);

            // 추가코드
        }

        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1")) // Fire1 : 조이패드 파이어 버튼, 키보드 왼쪽콘트롤버튼, 마우스 왼쪽버튼
            {
                // 공격!!
                //m_Character.Attack();
                Attack();
            }
            _hpBar.fillAmount = _hp / _maxHP;

        }

    }
}