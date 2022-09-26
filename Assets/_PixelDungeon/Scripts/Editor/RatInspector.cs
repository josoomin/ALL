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

            if (GUILayout.Button("���� �׽�Ʈ"))
            {
                _rat.Attack();

                //ġƮ
                //�÷��̾��� ü���� ����ֱ�(�׽�Ʈ)
                Player.I.DoDamage(10);
            }

            base.OnInspectorGUI(); //������ �������� �ν����Ϳ� ������
        }
    }
}