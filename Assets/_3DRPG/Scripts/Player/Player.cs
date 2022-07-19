using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

namespace RPG3D
{
    [Serializable]
    public class PlayerStat
    {
        public int _strength;
        public int _magic;
        public int _agility;
        public int _attack;
        public int _defense;
    }

    public class Player : Unit
    {
        public TextMeshProUGUI _STR;
        public TextMeshProUGUI _MP;
        public TextMeshProUGUI _SPD;
        public TextMeshProUGUI _ATK;
        public TextMeshProUGUI _DEF;

        [SerializeField] float _jumpForce = 100.0f;
        ThirdPersonCharacter _chatecter;

        [Header("---------스 탯 ---------")]
        public PlayerStat _stat;


        protected override void Start()
        {
            base.Start();

            _chatecter = GetComponent<ThirdPersonCharacter>();

            if(PlayerPrefs.HasKey("STAT_STRENGTH")) //이미 스탯 랜덤 결정을 한 적이 있음
            {
                _stat._strength = PlayerPrefs.GetInt("STAT_STRENGTH");
                _stat._magic =    PlayerPrefs.GetInt("STAT_MAGIC");
                _stat._agility =  PlayerPrefs.GetInt("STAT_AGILITY");
                _stat._attack =   PlayerPrefs.GetInt("STAT_ATTACK");
                _stat._defense =  PlayerPrefs.GetInt("STAT_DEFENSE");
            }
            else // 게임을 처음 실행하는 상태(스탯 주사위 굴림 필요)
            {
                _stat._strength = UnityEngine.Random.Range(5, 10);
                _stat._magic =    UnityEngine.Random.Range(5, 10);
                _stat._agility =  UnityEngine.Random.Range(5, 10);
                _stat._attack =   UnityEngine.Random.Range(5, 10);
                _stat._defense =  UnityEngine.Random.Range(5, 10);

                PlayerPrefs.SetInt("STAT_STRENGTH", _stat._strength);
                PlayerPrefs.SetInt("STAT_MAGIC",    _stat._magic);
                PlayerPrefs.SetInt("STAT_AGILITY",  _stat._agility);
                PlayerPrefs.SetInt("STAT_ATTACK",   _stat._attack);
                PlayerPrefs.SetInt("STAT_DEFENSE",  _stat._defense);
            }
        }

        void Update()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1")) // Fire1 : 조이패드 파이어 버튼, 키보드 왼쪽콘트롤버튼, 마우스 왼쪽버튼
            {
                // 공격!!
                //m_Character.Attack();
                Attack();
            }

            _STR.text = _stat._strength.ToString();
            _MP.text = _stat._magic.ToString();
            _SPD.text = _stat._agility.ToString();
            _ATK.text = _stat._attack.ToString();
            _DEF.text = _stat._defense.ToString();
        }
    }
}
