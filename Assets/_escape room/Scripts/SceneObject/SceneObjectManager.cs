using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace roomescape
{
    public class SceneObjectManager : MonoBehaviour
    {
        public SceneObject[] _sceneObjectsList;

        void Start()
        {
            _sceneObjectsList = GetComponentsInChildren<SceneObject>();
        }

        void Update()
        {

        }

        public void OnClick_BackBtn()
        {
            //foreach(SceneObject obj in _sceneObjectsList)
            //{
            //    obj.OnClick_BackBtn();
            //}

            for (int i = 0; i < _sceneObjectsList.Length; i++)
            {
                SceneObject obj = _sceneObjectsList[i];
                obj.OnClick_BackBtn();
            }
        }
    }
}