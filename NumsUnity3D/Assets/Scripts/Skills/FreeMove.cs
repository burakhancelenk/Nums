using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fundamentals;

public class FreeMove : Skill{

    public FreeMove()
    {
        skillPoint = 10;
        skillTime = 5.0f;
        Status = STATUS.notUsed;
    }
    public FreeMove(byte sPoint,float sTime)
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
