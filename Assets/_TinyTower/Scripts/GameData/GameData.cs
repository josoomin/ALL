using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TinyTower
{
    public class GameData : MonoBehaviour
    {
        public static GameData I;

        //��ǰ ������ ����
        public TextAsset _product_csv; // csv���� �� ��ü
        public List<GameData_Product> _Product_dataList;

        public void Awake()
        {
            I = this;
        }

        public void Init()
        {
            init_ProductData();
        }

        void init_ProductData()
        {
            string text = _product_csv.text;

            //strinReader: System,IO�� Ŭ����, ���Ϸκ��� ���ڿ� �а� ����
            using (StringReader reader = new StringReader(text))
            {
                string firstLine = reader.ReadLine(); // ù��° ���� �а�

                if (firstLine != null)
                {
                    string line = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //csv���̹Ƿ�. ',' seperator�� �����͵��� �и��ؼ� ����

                        string[] record = line.Split(',');

                        Debug.Assert(record.Length == 5);

                        GameData_Product temp = new GameData_Product();
                        temp.name = record[0];
                        temp.floor = record[1];
                        temp.cost = Convert.ToInt32(record[2]);
                        temp.time = Convert.ToSingle(record[3]);
                        temp.quantity = Convert.ToInt32(record[4]);

                        // List�� �ϳ��� ������� ���� Add �Լ� ����
                        _Product_dataList.Add(temp);
                    }
                }
            }
        }
    }
}