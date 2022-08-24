using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roomescape
{
    // Inventory ��ü�� ������ ����Ʈ�� Ȯ���ؼ�
    // �״�� �κ��丮 UIȭ�鿡 �ѷ��ش�.

    public class UI_Inventory : MonoBehaviour
    {
        public List<UI_InvenItem> _itemList;

        public GameObject _itemTemplate;

        void Start()
        {
            _itemTemplate = transform.Find("UI_Inventory/Viewport/Content/Item(0)").gameObject;

            _itemTemplate.SetActive(false);

            UI_InvenItem[] array = GetComponentsInChildren<UI_InvenItem>();

            //List�� ������(�迭)�� ������� ���� AddRange �Լ� ����
            // (�� ���� ������� ���� Add�Լ�)
            _itemList.AddRange(array);

            //Inventory ��ü�� _itemList�� Ȯ���ؼ�, �� �������
            //UI_invenitem�� �������ش�.
            for(int i = 0; i < Inventory.I._itemList.Count; i++)
            {
                string itemName = Inventory.I._itemList[i];
                 
                Add(itemName);
            }
        }

        public void Add(string itemName)
        {
            GameObject cloneObj = Instantiate(_itemTemplate);
            cloneObj.transform.parent = _itemTemplate.transform.parent;
            cloneObj.SetActive(true);

            UI_InvenItem invenitem = cloneObj.GetComponent<UI_InvenItem>();
            invenitem.SetInfo(itemName);
        }

        void Update()
        {

        }
    }
}
