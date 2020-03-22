using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fundamentals;

public class PowerButton1 : MonoBehaviour, IPointerUpHandler
{
    public static Freeze power;
    public Text pointText;
    public SoundFX SoundManager ;
    private string tempPoint;
    private float timing=0;

    void Start()
    {
        power = new Freeze();
        SoundManager = GameObject.Find("SoundFX").GetComponent<SoundFX>() ;
    }

    
    void Update()
    {
        if (power.Status == Skill.STATUS.Using && timing <= power.skillTime)
        {
            timing += Time.deltaTime;
        }
        else if (timing > power.skillTime)
        {
            power.Status = Skill.STATUS.Used;
            timing = 0;
        }
    }
    public void OnPointerUp(PointerEventData data)
    {
        if (power.Status == Skill.STATUS.notUsed)
        {
            if (GameManager.TutorialMode)
            {
                TutorialManager.freezeSkill = true ;
                GetComponent<Button>().enabled = false ;
            }
            SoundManager.Play("ButtonClick");
            tempPoint = pointText.text;
            power.Execute(ref tempPoint);
            pointText.text = tempPoint;
        }
    }
   
}
