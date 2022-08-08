using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hellephant : Enemy
{
    protected override void Start()
    {
        base.Start();
        maxHp = 60;
        currentHp = maxHp;
        attackValue = 10;
        coinValue = 30;
        attackRote = 3;
        meshAgent.speed = 3f;
    }


}
