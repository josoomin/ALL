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
    }
}