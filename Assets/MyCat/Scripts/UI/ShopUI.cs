
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCat
{
    public class ShopUI : MonoBehaviour
    {
        public GameData _gameData;

        public GameObject _popup;

        public List<ShopItem> _itemList;

        public Transform _contentTrans;
        public GameObject _template_shopItem;

        // Start is called before the first frame update
        void Start()
        {
            _contentTrans = transform.Find("Scroll View").Find("Viewport").Find("Content");
            _template_shopItem = _contentTrans.GetComponentInChildren<ShopItem>(true).gameObject;
            _template_shopItem.SetActive(false);

            _itemList = new List<ShopItem>();

            List<GameData_ShopItem> shopDataList = _gameData._shop_item_data;

            for (int i = 0; i < shopDataList.Count; i++)
            {
                //Debug.Log("아이템 : " + i);
                GameObject obj = Instantiate(_template_shopItem);
                obj.transform.parent = _contentTrans;
                obj.SetActive(true);
                ShopItem item = obj.GetComponent<ShopItem>();

                GameData_ShopItem data = shopDataList[i];

                item.SetData(data); // 일일미션데이터를 각 항목(item)에 넣어준다
                _itemList.Add(item);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClose()
        {
            gameObject.SetActive(false);
        }

        public void OnClick_Popup()
        {
            // 팝업을 연다
            _popup.SetActive(true);
        }
    }
}