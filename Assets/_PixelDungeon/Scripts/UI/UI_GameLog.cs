using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelDungeon
{
public class UI_GameLog : MonoBehaviour
    {
        public GameObject _logObjecTemplate;
        //public Text _text;
        public float _playTime = 1.5f;

        void Start()
        {
            //_text = transform.Find("verticalLayout/Log").GetComponent<Text>();
            _logObjecTemplate = transform.Find("verticalLayout/Log").gameObject;
            _logObjecTemplate.SetActive(false);

            //_text.enabled = false;
        }

        void Update()
        {
           
        }

        public void Play(string message)
        {
            StartCoroutine(_Play(message));
        }

        IEnumerator _Play(string message)
        {
            GameObject newLogObj = Instantiate(_logObjecTemplate);

            newLogObj.transform.parent = transform.Find("verticalLayout");
            newLogObj.SetActive(true);

            Text logTxt = newLogObj.GetComponent<Text>();

            logTxt.text = message;

            yield return new WaitForSeconds(_playTime);

            Destroy(newLogObj);
        }
    }
}