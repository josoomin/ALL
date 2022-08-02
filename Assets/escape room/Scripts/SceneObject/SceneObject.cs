using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace roomescape
{
public class SceneObject : MonoBehaviour
{
        public RectTransform _infoTextTrans;
        public Vector3 _infoTextOffset;
        public string _infoText = "";

        void Start()
        {
            _infoTextTrans.gameObject.SetActive(false);
        }

        void Update()
        {
            // UpdateInfoTextPos();
        }

        private void OnMouseEnter()
        {
            Debug.Log(gameObject.name + "OnMouseEnter");

            _infoTextTrans.gameObject.SetActive(true);
            Text text = _infoTextTrans.GetComponent<Text>();
            text.text = _infoText;
        }

        private void OnMouseExit()
        {
            Debug.Log(gameObject.name + "OnMouseExit");

            _infoTextTrans.gameObject.SetActive(false);
        }

        //void UpdateInfoTextPos()
        //{
        //    // 책장의 월드좌표
        //    Vector3 objPos = transform.position;

        //    // 월드좌표 -> 스크린 좌표
        //    Vector3 screenPos = UnityEngine.Camera.main.WorldToScreenPoint(objPos + _infoTextOffset);

        //    // UI Text(InfoText)의 위치를 이 스크린 좌표로 덮어쓰기
        //    _infoTextTrans.position = screenPos;
        //}
    }
}