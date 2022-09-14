using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class UI_Info_Floor : MonoBehaviour
    {
        public Text _titleTxt; //���� �̸� ����

        public Contents _product1;
        public Contents _product2;
        public Contents _product3;

        public void ShowInfo(List<GameData_Product> productDataList)
        {
            gameObject.SetActive(true);

            _titleTxt.text = productDataList[0].floor;

            //1�� ��ǰ ����
            _product1.ShowInfo(productDataList[0]);
            //2�� ��ǰ ����
            _product2.ShowInfo(productDataList[1]);
            //3�� ��ǰ ����
            _product3.ShowInfo(productDataList[2]);

            StartCoroutine(_Play());
        }

        IEnumerator _Play() //�˾�â�� ���� �� ���� 
        {
            //�������� 0.5���� 1�� Ŀ���� ����

            Vector3 startScale = new Vector3(0.5f, 0.5f, 0.5f);
            Vector3 targetScale = new Vector3(1.0f, 1.0f, 1.0f);

            transform.localScale = startScale;

            float speed = 10.0f;

            while(true)
            {
                transform.localScale = Vector3.MoveTowards(startScale, targetScale, Time.deltaTime * speed);

                startScale = transform.localScale;

                yield return null;
            }
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}