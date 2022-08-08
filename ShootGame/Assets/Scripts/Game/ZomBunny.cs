using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomBunny : Enemy
{
    protected override void Start()
    {
        base.Start();
        maxHp = 40;
        currentHp = maxHp;
        meshAgent.speed = 6f;
        attackValue = 4;
        coinValue = 8;
        attackRote = 2;
    }


}
