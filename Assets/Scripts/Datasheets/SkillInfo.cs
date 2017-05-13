﻿using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SkillInfo
{
    public string skill;
    public int id = -1;
    public string charClass;
    public string skillDesc;
    public int srvStartFunc;
    public int srvDoFunc;
    [Datasheet.Sequence(length = 71)]
    public string[] unused;
    public string stsound;
    [Datasheet.Sequence(length = 10)]
    public string[] unused2;
    public string castOverlayId;
    public string clientOverlayA;
    public string clientOverlayB;
    public int clientStartFunc;
    public int clientDoFunc;
    public int clientPrqFunc1;
    public int clientPrqFunc2;
    public int clientPrqFunc3;
    public string clientMissile;
    public string clientMissileA;
    public string clientMissileB;
    public string clientMissileC;
    public string clientMissileD;
    [Datasheet.Sequence(length = 6)]
    public string[] clientCalcs;
    public bool warp;
    public bool immediate;
    public bool enhanceable;
    public int attackRank;
    public bool noAmmo;
    public string range;
    public int weapSel;
    public string itemTypeA1;
    public string itemTypeA2;
    public string itemTypeA3;
    public string eItemTypeA1;
    public string eItemTypeA2;
    public string itemTypeB1;
    public string itemTypeB2;
    public string itemTypeB3;
    public string eItemTypeB1;
    public string eItemTypeB2;
    public string anim;
    public string seqTrans;
    public string monAnim;
    [Datasheet.Sequence(length = 129)]
    public string[] unused3;

    [System.NonSerialized]
    public OverlayInfo castOverlay;

    public static List<SkillInfo> sheet = Datasheet.Load<SkillInfo>("data/global/excel/Skills.txt");
    static Dictionary<string, SkillInfo> map = new Dictionary<string, SkillInfo>();

    static SkillInfo()
    {
        foreach (var row in sheet)
        {
            if (row.id == -1)
                continue;

            row.castOverlay = OverlayInfo.Find(row.castOverlayId);
            map.Add(row.skill, row);
        }
    }

    public static SkillInfo Find(string id)
    {
        return map.GetValueOrDefault(id);
    }

    public void Do(Character character, Vector3 target)
    {
        if (srvDoFunc == 27)
        {
            // teleport
            character.InstantMove(target);
        }

        if (clientMissile != null)
        {
            Missile.Create(clientMissile, character.iso.pos, target);
        }
    }
}
