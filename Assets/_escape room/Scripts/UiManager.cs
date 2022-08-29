using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace roomescape
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager I;

        GameObject _backBtnObj;
        GameObject _leftBtnObj;
        GameObject _rightBtnObj;

        public UI_Inventory _ui_iven;

        GraphicRaycaster _raycaster;

        void Awake()
        {
            I = this;
        }

        void Start()
        {
            _raycaster = GetComponent<GraphicRaycaster>();

            _backBtnObj = transform.Find("Back Button").gameObject;
            _leftBtnObj = transform.Find("Left Button").gameObject;
            _rightBtnObj = transform.Find("Right Button").gameObject;

            _ui_iven = transform.Find("UI_Inventory").GetComponent<UI_Inventory>();

            bool mainView = true;
            OnChangeView(mainView);
        }
        
        public bool IsUITouched() // UI요소가 터치되었는지 알려주는 함수
        {
            PointerEventData data = new PointerEventData(EventSystem.current);
            data.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            bool uiTouched = false;
            _raycaster.Raycast(data, results);
            foreach (RaycastResult r in results)
            {

                Debug.Log("ui 객체: " + r.gameObject.name);

                uiTouched = true;

            }

            return uiTouched;
        }

       

        public void OnChangeView(bool isMainView) //true: ���� �� ����, false: Ȯ��� ����
        {
            _backBtnObj.SetActive(!isMainView);
            _leftBtnObj.SetActive(isMainView);
            _rightBtnObj.SetActive(isMainView);
        }


        void Update()
        {
            IsUITouched();
        }
    }
}
