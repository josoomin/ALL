using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class UI_GameOver : MonoBehaviour
    {

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        public void Show()
        {
            UI_Manager.I.Gamelog._text.text ="ĳ���Ͱ� ����߽��ϴ�.";
            gameObject.SetActive(true);
        }
    }
}