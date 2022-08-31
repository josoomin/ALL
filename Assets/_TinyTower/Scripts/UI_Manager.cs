using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class UI_Manager : MonoBehaviour
    {
        Text _goldTxt;
        Text _personTxt;

        public static UI_Manager I; // I는 싱글톤 인스턴스를 의미

        void Awake()
        {
            I = this;
        }

        public void Init()
        {
            _goldTxt = transform.Find("UI_Topbar/gold/goldTxt").GetComponent<Text>();
            _personTxt = transform.Find("UI_Topbar/population/personcount").GetComponent<Text>();

            // 골드 UI부터 리프레시
            Refresh_Gold_UI();

            // 사람 UI 리프레시
            Refresh_Person_UI();
        }

        public void Refresh_Gold_UI()
        {
            _goldTxt.text = UserData.I.Gold.ToString();
        }

        public void Refresh_Person_UI()
        {
            _personTxt.text = UserData.I.Person.ToString();
        }

        void Update()
        {

        }
    }
}