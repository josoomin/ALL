using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GameData_MissionDaily
{
    public int id;
    public string name;
    public int clearCount;
    public int gem_reward;
    public string reward_icon;
    public string desc;

    public Sprite reward_icon_sp;
}
