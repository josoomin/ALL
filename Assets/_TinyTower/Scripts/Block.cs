using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Block : MonoBehaviour
    {
        const float HEIGHT = 5.0f; //블록의 높이 : 5m

        [SerializeField] GameObject[] _templates; // 매장 템플릿 배열

        void OnMouseDown()
        {
            
            UserData.I.UseGold(Common.COST_SHOP, UseGoldCb);
        }

        void UseGoldCb(bool result)
        {
            if(result == true) //성공
            {
                // 공사 가능한 층(블록) 터치!!
                //Debug.Log("블록 터치:" + Input.mousePosition.ToString());

                int choice = Random.Range(0, _templates.Length);

                GameObject template = _templates[choice];

                GameObject obj = Instantiate(template);
                obj.SetActive(true);

                // 1. 현재 층 알아오기
                //int floor = (int)(transform.position.y / HEIGHT) + 1;

                //생성된 매장 오브젝트가 이 현재 층이 되도록 위치 설정
                // y위치 = (n층 - 1) * 층 높이(5m)
                //float yPos = (floor - 1) * HEIGHT;

                //Vector3 pos = obj.transform.position;
                //obj.transform.position = new Vector3(pos.x, yPos, pos.z);
                obj.transform.position = transform.position;

                // 이 블록은 이제 한 층 위로 올려주기
                Vector3 blockPos = transform.position;
                transform.position = new Vector3(blockPos.x, blockPos.y + HEIGHT, blockPos.z);

            }
            else
            {
                // TODO
                //돈이 부족합니다 등의 팝업 안내창 띄우기
            }
        }
    }
}