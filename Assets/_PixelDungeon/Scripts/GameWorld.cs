using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelDungeon
{
public class GameWorld : MonoBehaviour
    {

        public static GameWorld I; //�̱��� �ν��Ͻ�

        void Awake()
        {
            I = this;
        }
    }
}