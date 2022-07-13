using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG3D
{
    public class uiManager : MonoBehaviour
    {
        GameObject ui_state;
        GameObject ui_option;
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
                //if (ui_state.activeSelf == true)
                //    ui_state.SetActive(false);

                //닫혀있으면 열고
                if (ui_state.activeSelf == false)
                    ui_state.SetActive(true);
            } 
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
    }
}
