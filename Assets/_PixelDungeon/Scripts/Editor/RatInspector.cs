using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PixelDungeon
{

    [CustomEditor(typeof(Rat))]
    public class GameManagerInpector : Editor
    {
        Rat _rat;

        public override void OnInspectorGUI()
        {
            if (_rat == null)
                _rat = target as Rat;

            if (GUILayout.Button("공격 테스트"))
            {
                _rat.Attack();

                //치트
                //플레이어의 체력을 깍아주기(테스트)
                Player.I.DoDamage(10);
            }

            base.OnInspectorGUI(); //원래의 변수들이 인스펙터에 보여짐
        }
    }
}