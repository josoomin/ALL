using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace roomescape
{
    public class UI_InvenItem : MonoBehaviour
    {
        public Text _itemNameTxt; 


        void Start()
        {
            _itemNameTxt = transform.Find("itemNameTxt").GetComponent<Text>();
        }

        void Update()
        {

        }

        // 획득된 아이템 정보를 받아서
        // 그 정보대로, 이름, 아이콘, 수량 표시
        public void SetInfo(string itemName)
        {
            _itemNameTxt.text = itemName;
        }
    }
}