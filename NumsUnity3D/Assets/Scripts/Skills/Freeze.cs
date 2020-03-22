using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fundamentals;

public class Freeze : Skill
{

    public Freeze()
    {
        skillPoint = 0;
        skillTime = 30.0f;
        Status = STATUS.notUsed;
    }
    public Freeze(byte sPoint, float sTime)
    {
        skillPoint = sPoint;
        skillTime = sTime;
        Status = STATUS.notUsed;
    }

    public override void Execute(ref string point)
    {
       
        Status = STATUS.Using;
        point = (int.Parse(point.Trim()) - skillPoint).ToString();
        

    }



}