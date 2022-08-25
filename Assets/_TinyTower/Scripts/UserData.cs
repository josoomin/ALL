using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class UserData : MonoBehaviour
    {
        const string KEY_GOLD = "user_data_gold";
        const string KEY_PERSON = "user_data_person";
        const int INITIAL_GOLD = 10000; // 초기 자금
        const int INITIAL_PERSON = 10; // 초기 인구

        [SerializeField] int _gold = 0;
        [SerializeField] int _person = 0;
        public int Gold //프로퍼티
        {
            get { return _gold; } // 읽기
        }
        
        public int Person //프로퍼티
        {
            get { return _person; } // 읽기
        }

        public static UserData I; // I는 싱글톤 인스턴스를 의미

        void Awake()
        {
            I = this;
        }

        public void Init()
        {
            // 앱을 처음 실행하는 것이라면, 자금을 주고 시작
            if (PlayerPrefs.HasKey(KEY_GOLD) == false)
            {
                PlayerPrefs.SetInt(KEY_GOLD, INITIAL_GOLD);
            }

            _gold = PlayerPrefs.GetInt(KEY_GOLD);

            if (PlayerPrefs.HasKey(KEY_PERSON) == false)
            {
                PlayerPrefs.SetInt(KEY_PERSON, INITIAL_PERSON);
            }

            _person = PlayerPrefs.GetInt(KEY_PERSON);
        }

        void Update()
        {

        }
    }
}