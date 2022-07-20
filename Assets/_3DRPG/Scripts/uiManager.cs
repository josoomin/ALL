using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RPG3D
{
    public class uiManager : MonoBehaviour
    {
        public TextMeshProUGUI _STR;
        public TextMeshProUGUI _MAG;
        public TextMeshProUGUI _AGT;
        public TextMeshProUGUI _ATK;
        public TextMeshProUGUI _DEF;

        GameObject ui_state;
        GameObject ui_option;
        public Player _player;
        void Start()
        {
            ui_state = transform.Find("statusUI").gameObject;
            ui_state.SetActive(false);
            ui_option = transform.Find("Option").gameObject;
            ui_option.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                //열려있으면 닫고
                if (ui_state.activeSelf == true)
                    ui_state.SetActive(false);

                //닫혀있으면 열고
                else if (ui_state.activeSelf == false)
                    ui_state.SetActive(true);
            }

            _STR.text = _player._stat._STR.ToString();
            _MAG.text = _player._stat._MAG.ToString();
            _AGT.text = _player._stat._AGT.ToString();
            _ATK.text = _player._stat._ATK.ToString();
            _DEF.text = _player._stat._DEF.ToString();
        }

        public void Stateclose()
        {
            ui_state.SetActive(false);
        }

        public void OptionOpen()
        {
            ui_option.SetActive(true);
        }

        public void Optionvclose()
        {
            ui_option.SetActive(false);
        }

        public void OnButtonStatePoint(GameObject buttonObj)
        {
            Debug.Log("-------------------Stat Points Button-------------------");
            string statName = buttonObj.transform.parent.gameObject.name;
            Debug.Log(statName);  // 스탯 종류
            Image img = buttonObj.GetComponent<Image>();
            string btnName = img.sprite.name;
            Debug.Log(btnName); // 버튼 종류(증가, 감소)

            switch(statName)
            {
                case "STR":
                    {
                        if (btnName.Contains("Plus"))
                            _player._stat._STR++;
                        else
                            _player._stat._STR--;
                    }
                    break;
                case "MAG":
                    {
                        if (btnName.Contains("Plus"))
                            _player._stat._MAG++;
                        else
                            _player._stat._MAG--;
                    }
                    break;
                case "AGT":
                    {
                        if (btnName.Contains("Plus"))
                            _player._stat._AGT++;
                        else
                            _player._stat._AGT--;
                    }
                    break;
                case "ATK":
                    {
                        if (btnName.Contains("Plus"))
                            _player._stat._ATK++;
                        else
                            _player._stat._ATK--;
                    }
                    break;
                case "DEF":
                    {
                        if (btnName.Contains("Plus"))
                            _player._stat._DEF++;
                        else
                            _player._stat._DEF--;
                    }
                    break;

            }

            if (_player != null)
                _player.SaveStat();
        }
    }
}
