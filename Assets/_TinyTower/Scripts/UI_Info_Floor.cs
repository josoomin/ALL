using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class UI_Info_Floor : MonoBehaviour
    {
        public Text _titleTxt; //매장 이름 정보

        public Contents _product1;
        public Contents _product2;
        public Contents _product3;

        public void ShowInfo(List<GameData_Product> productDataList)
        {
            gameObject.SetActive(true);

            _titleTxt.text = productDataList[0].floor;

            //1번 제품 정보
            _product1.ShowInfo(productDataList[0]);
            //2번 제품 정보
            _product2.ShowInfo(productDataList[1]);
            //3번 제품 정보
            _product3.ShowInfo(productDataList[2]);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}