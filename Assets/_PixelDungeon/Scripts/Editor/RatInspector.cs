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
                int damage = 10;

                Player.I.DoDamage(10);

                string formatStr = string.Format("{0}(��)�� {1}���� {2}�������� �������ϴ�",_rat.gameObject.name, Player.I.gameObject.name,damage);

                UI_Manager.I.Gamelog.Play(formatStr);
            }

            base.OnInspectorGUI(); //������ �������� �ν����Ϳ� ������
        }
    }
}