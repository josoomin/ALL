using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelDungeon
{
public class UI_ScreenBlock : MonoBehaviour
    {
        [SerializeField] float _duration1 = 0.2f;
        [SerializeField] float _duration2 = 0.5f;
        [SerializeField] float _duration3 = 0.2f;

        Image _backgrounding;
        Text _infoTxt;

        void Init()
        {
            _backgrounding = transform.Find("backgrounding").GetComponent<Image>();
            _infoTxt = transform.Find("InfoTxt").GetComponent<Text>();

            //Show();    
        }

        public void Play()
        {
            gameObject.SetActive(true);

            Init();

            StartCoroutine(_Show());
        }

        IEnumerator _Show()
        {
            //Debug.Log("���� ����");

            _infoTxt.gameObject.SetActive(false);

            float elapsed = 0.0f; //��� �ð�

            // ���İ� 0 -> 1 (���̵� ��)
            while(elapsed < _duration1)
            {
                //Debug.Log("���̵� ��");

                Color color = _backgrounding.color;
                color.a = Mathf.Lerp(0.0f, 1.0f, elapsed / _duration1);
                _backgrounding.color = color;

                elapsed += Time.deltaTime;

                yield return null;
            }
            elapsed = 0.0f;

            _infoTxt.gameObject.SetActive(true);
            //Debug.Log("�ؽ�Ʈ ���̱�.....");

            yield return new WaitForSeconds(_duration2);

            _infoTxt.gameObject.SetActive(false);
            //Debug.Log("�ؽ�Ʈ �����.....");

            // ���İ� 1 -> 0 (���̵� �ƿ�)
            while (elapsed < _duration3)
            {
                //Debug.Log("���̵� �ƿ�");

                Color color = _backgrounding.color;
                color.a = Mathf.Lerp(1.0f, 0.0f, elapsed / _duration3);
                _backgrounding.color = color;

                elapsed += Time.deltaTime;

                yield return null;
            }

            Debug.Log("���� ����");
        }

        public void Stop()
        {
            gameObject.SetActive(false);
        }
    }
}