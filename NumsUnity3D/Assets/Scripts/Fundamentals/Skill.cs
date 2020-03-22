using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamentals
{
    public abstract class Skill
    {
        public enum STATUS : byte {notUsed,Using,Used };
        public STATUS Status;
        public float skillTime;
        

        protected int skillPoint;

        public Skill()
        {
            Status = STATUS.notUsed;
            skillTime = 0;
            skillPoint = 0;
        }
        public Skill(float time,int sPoint)
        {
            Status = STATUS.notUsed;
            skillTime = time;
            skillPoint = sPoint;
        }

        public abstract void Execute(ref string cost) ;

    }

}
