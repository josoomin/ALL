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
        [SerializeField] UI_GameOver _gameover;
        [SerializeField] UI_GameLog _gamelog;
        
        public UI_ScreenBlock screenBlock { get { return _screenBlock; } }
        public UI_TopBar topBar { get { return _topBar; } }
        public UI_GameOver Gameover { get { return _gameover; } }
        public UI_GameLog Gamelog { get { return _gamelog; } }

        private void Awake()
        {
            I = this;
        }

        private void Start()
        {
            _screenBlock = transform.Find("UI_ScreenBlock").GetComponent<UI_ScreenBlock>();
            _topBar = transform.Find("UI_Topbar").GetComponent<UI_TopBar>();
            _gameover = transform.Find("UI_GameOver").GetComponent<UI_GameOver>();
            _gamelog = transform.Find("UI_GameLog").GetComponent<UI_GameLog>();
        }
    }
}