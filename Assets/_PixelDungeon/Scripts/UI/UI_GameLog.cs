using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelDungeon
{
public class UI_GameLog : MonoBehaviour
    {
        public Text _text;

        void Start()
        {
            _text = transform.Find("BackGround/Log").GetComponent<Text>();
        }

        void Update()
        {
            
        }
    }
}