using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{

    public enum FloorType
    {
        RESIDENTIAL, //주거
        FOOD_STORE,  //음식점
        SERVICE,     //서비스 스토어
        CULTURE,     //문화시설
        CREATIVE,    //예술, 창작
        RETAIL,      //각종 판매점
        BUSYNESS     //사무실, 사업장
    }

    public class Floor : MonoBehaviour
    {
        public FloorType _type;

        private float _timeleft = 1.0f;
        private float _nextTime = 0.0f;

        public GameObject _Information;

        public void Init()
        {
            _Information.SetActive(false);
        }

        public void Update()
        {
            CollectGold();
        }

        public void CollectGold()
        {
            // 테스트 코드: 1초마다 1골드 수입 증가하는 루틴
            if (Time.time > _nextTime)
            {
                _nextTime = Time.time + _timeleft;
                UserData.I.AddGold(1);
            }
        }

        public void ShowInfo()
        {
            //이 상점의 정보를 표시
            if(Input.GetMouseButton(0))
            {
                Invoke("Open", 2.0f);
            }
        }

        public void Open()
        {
            _Information.SetActive(true);
        }

        public void Close()
        {
            _Information.SetActive(false);
        }

        void OnMouseDown()
        {
            ShowInfo();
        }
    }
}