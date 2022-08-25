using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
public class GameManager : MonoBehaviour
{

    void Start()
    {

            //유저 데이터 초기화
            UserData.I.Init();

            // UI매니저 초기화
            UI_Manager.I.Init();
    }

    void Update()
    {
        
    }
}
}
