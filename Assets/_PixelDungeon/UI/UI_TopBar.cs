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
            //���� �� ��������
            int floor = Player.I.Floor;
            _StairTxt.text = floor.ToString();

            // TODO: ������, ü��, ���谹�� ��� ��������
        }
    }
}