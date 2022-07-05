using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyCat
{
    public class ShopItem : MonoBehaviour
    {
        public Text _nameTxt;
        public Text _priceTxt;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public void SetData(GameData_ShopItem data)
        {
            _nameTxt.text = data.name;
            _priceTxt.text = string.Format("{0:#,0}", data.price);
        }
    }
}