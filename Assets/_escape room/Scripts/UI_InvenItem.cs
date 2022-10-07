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
        public void SetInfo(string itemName)
        {
            _itemNameTxt.text = itemName;
        }
    }
}