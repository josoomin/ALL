using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Block : MonoBehaviour
    {
        const float HEIGHT = 5.0f; //블록의 높이 : 5m

        public GameObject _floorMgrObj;

        [SerializeField] GameObject[] _templates; // 매장 템플릿 배열

        void OnMouseDown()
        {
            UserData.I.UseGold(Common.COST_SHOP, UseGoldCb);
        }

        void UseGoldCb(bool result)
        {
            if (result == true) //성공
            {
                // 공사 가능한 층(블록) 터치!!
                //Debug.Log("블록 터치:" + Input.mousePosition.ToString());

                int choice = Random.Range(0, _templates.Length);

                GameObject template = _templates[choice];

                FloorManager.I.Create(template, transform.position);

                // 이 블록은 이제 한 층 위로 올려주기
                Vector3 blockPos = transform.position;
                transform.position = new Vector3(blockPos.x, blockPos.y + HEIGHT, blockPos.z);

            }
            else
            {
                // TODO
                //돈이 부족합니다 등의 팝업 안내창 띄우기if( GUILayout.Button ("show dialog 3") ) {
                PlatformDialog.SetButtonLabel("OK");
                PlatformDialog.Show(
                    "알림",
                    "골드가 부족합니다.",
                    PlatformDialog.Type.SubmitOnly,
                    () =>
                    {
                        Debug.Log("OK");
                    },
                    null
                );
            }
        }
    }
}