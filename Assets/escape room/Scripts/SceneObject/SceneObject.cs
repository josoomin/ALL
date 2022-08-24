using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace roomescape
{
public class SceneObject : MonoBehaviour
{
        public Camera _showCamera;
        public RectTransform _infoTextTrans;
        public Vector3 _infoTextOffset;
        public string _infoText = "";

        protected virtual void Start()
        {
            GameObject canvas = UiManager.I.gameObject;

            //_infoTextTrans = canvas.transform.Find("infoText").GetComponent<RectTransform>();

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
        //    // å���� ������ǥ
        //    Vector3 objPos = transform.position;

        //    // ������ǥ -> ��ũ�� ��ǥ
        //    Vector3 screenPos = UnityEngine.Camera.main.WorldToScreenPoint(objPos + _infoTextOffset);

        //    // UI Text(InfoText)�� ��ġ�� �� ��ũ�� ��ǥ�� �����
        //    _infoTextTrans.position = screenPos;
        //}

        protected virtual void OnMouseDown()
        {
            //마우스 클릭시, 만일 연출카메라가 있다면, 해당 카메라 켜주기
            if(_showCamera != null)
            {
                //연출 카메라와 백버튼을 활성화 시킨다.
                _showCamera.gameObject.SetActive(true);

                Collider col = GetComponent<Collider>();
                col.enabled = false;

                // 뷰가 바뀌었음을 알린다.(연출뷰로 간다.)
                UiManager.I.OnChangeView(false);
            }
        }

        public void OnClick_BackBtn()
        {
            //연출카메라가 켜있던 씬오브젝트는 원상복귀 시킨다.
            if (_showCamera != null)
            {
                if(_showCamera.gameObject.activeSelf == true)
                {
                    //연출 카메라 활성화
                    _showCamera.gameObject.SetActive(false);

                    Collider col = GetComponent<Collider>();
                    col.enabled = true;

                    //뷰가 바뀌었음을 알린다.(메인뷰로 돌아간다.)
                    UiManager.I.OnChangeView(true);
                }
            }
        }
    }
}