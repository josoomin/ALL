using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class GameManager : MonoBehaviour
    {

        void Start()
        {
            //게임 데이터 초기화
            GameData.I.Init();

            //유저 데이터 초기화
            UserData.I.Init();

            //플로어 매니저 초기화
            FloorManager.I.Init();

            // UI매니저 초기화
            UI_Manager.I.Init();
        }

        void Update()
        {

        }

        private void OnApplicationQuit()
        {
            string stopTime = DateTime.Now.ToString();
            PlayerPrefs.SetString("game_stop_time", stopTime);
        }
    }
}