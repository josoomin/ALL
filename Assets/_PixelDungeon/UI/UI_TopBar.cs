using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelDungeon
{
public class UI_TopBar : MonoBehaviour
    {
        [SerializeField] Text _StairTxt;

        void Start()
        {
            _StairTxt = transform.Find("floorTxt").GetComponent<Text>();

            Refresh();
        }

        //public void RefreshFloor(int floor)
        //{
        //    _StairTxt.text = floor.ToString();
        //}

        public void Refresh()
        {
            //현재 층 리프레시
            int floor = Player.I.Floor;
            _StairTxt.text = floor.ToString();

            // TODO: 소지금, 체력, 열쇠갯수 등등 리프레시
        }
    }
}