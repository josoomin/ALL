using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class UI_Manager : MonoBehaviour
    {
        public static UI_Manager I;

        //[SerializeField] GameObject _screenBlockObj;
        [SerializeField] UI_ScreenBlock _screenBlock;
        [SerializeField] UI_TopBar _topBar;
        
        public UI_ScreenBlock screenBlock { get { return _screenBlock; } }
        public UI_TopBar topBar { get { return _topBar; } }

        private void Awake()
        {
            I = this;
        }

        private void Start()
        {
            _screenBlock = transform.Find("UI_ScreenBlock").GetComponent<UI_ScreenBlock>();
            _topBar = transform.Find("UI_Topbar").GetComponent<UI_TopBar>();
        }
    }
}