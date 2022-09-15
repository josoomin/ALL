using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TinyTower
{
    public class Contents : MonoBehaviour
    {
        public Text _nameTxt;
        public Text _costTxt;
        public Text _timeTxt;
        public Text _qtyTxt;
        public Image _icon;

        public GameData_Product _data;
        private int _state = 0; // 0 - 판매대기, 1 - 주문 중, 2 - 판매
        public bool _test = false;
        public Text _oderingTxt;
        public Image _progressBar;
        public Button _sellingStartBtn;
        public Image _blocking;

        public static Contents I; // I는 싱글톤 인스턴스를 의미

        void Awake()
        {
            I = this;
        }

        public void Init() // 초기화
        {
            _oderingTxt.gameObject.SetActive(false);

            _progressBar.transform.parent.gameObject.SetActive(false);

            _sellingStartBtn.onClick.AddListener(OnClick_StartSelling);

            // 코루틴을 통해서 상품의 상태(단계) 및 수입 발생 제어
            if (_test == true)
                UI_Manager.I.StartCoroutine(_State_WaitForSelling());
        }

        public void OnClick_StartSelling()
        {
            _state = 1;
        }

        IEnumerator _State_WaitForSelling() // 판매 대기 상태
        {
            _state = 0;

            while (true)
            {
                Debug.Log("판매대기 : " + Time.time);

                if (_state != 0)
                    break;

                yield return null;
            }
            StartCoroutine(_State_Odering());
        }

        IEnumerator _State_Odering() // 주문 중 상태
        {
            _oderingTxt.gameObject.SetActive(true);
            _progressBar.transform.parent.gameObject.SetActive(true);

            float totalTime = _data.time;
            float currentTime = _data.time;

            while (true)
            {
                _progressBar.fillAmount = currentTime / totalTime;

                if (_progressBar.fillAmount < 0.5f)
                {
                    _progressBar.color = Color.red;
                }

                currentTime -= Time.deltaTime; // 프레임 시간만큼 시간을 계속 감소시켜주기

                if (currentTime <= 0.0f)
                {
                    break;
                }

                Debug.Log("주문 중: " + Time.time);

                if (_state != 1)
                    break;

                yield return null;
            }
            _oderingTxt.gameObject.SetActive(false);

            StartCoroutine(_State_Selling());
        }

        IEnumerator _State_Selling() // 판매 상태
        {
            _sellingStartBtn.gameObject.SetActive(false);
            _blocking.gameObject.SetActive(false);
            _progressBar.transform.parent.gameObject.SetActive(false);
            yield return null;
        }

        public void ShowInfo(GameData_Product data)
        {
            _data = data;

            _nameTxt.text = data.name;
            _costTxt.text = data.cost.ToString();
            _timeTxt.text = data.time.ToString();
            _qtyTxt.text = data.quantity.ToString();
            _icon.sprite = data.spriting;
        }
    }
}