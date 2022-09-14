using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class Contents : MonoBehaviour
    {
        public Text _nameTxt;
        public Text _costTxt;
        public Text _timeTxt;
        public Text _qtyTxt;
        public Image _icon;

public void ShowInfo(GameData_Product data)
        {
            _nameTxt.text = data.name;
            _costTxt.text = data.cost.ToString();
            _timeTxt.text = data.time.ToString();
            _qtyTxt.text = data.quantity.ToString();
            _icon.sprite = data.spriting;
        }
    }
}