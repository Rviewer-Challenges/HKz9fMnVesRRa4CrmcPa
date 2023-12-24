using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardStat : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private EventTrigger eventTrigger;
    [SerializeField] private RectTransform cover;

    private float _heightClose=0f;
    private float _heightOpen = 100f;
    [SerializeField] private float speedRotation;
    public int SetID
    {
        set => id = value;
    }

    private void Start()
    {
        _heightOpen = cover.sizeDelta.x;
    }

    public void CheckCouple()
    {
        
        
        eventTrigger.enabled = false;

        StartCoroutine(TurnUp());
        
        /*if (ManagerBoard.SharedInstance.CoupleSelected < 0)
        {
            gameObject.GetComponent<Image>().color=Color.green;
        }*/
       


    }

    
    
    IEnumerator TurnUp()
    {
        yield return CoroutineTurnUp();
        ManagerBoard.SharedInstance.CompareId(id,gameObject);

    }

    private IEnumerator CoroutineTurnUp()
    {
        while (cover.sizeDelta.y > _heightClose)
        {
            cover.sizeDelta -= new Vector2(0,speedRotation) ;
            yield return new WaitForFixedUpdate();

        }
        
        cover.sizeDelta = new Vector2(cover.sizeDelta.x,_heightClose) ;

        
        
        yield return null;
    }


    public IEnumerator TurnDown()
    {
        yield return CoroutineTurnDown();
        eventTrigger.enabled = true;
    }

    private IEnumerator CoroutineTurnDown()
    {
        
        while (cover.sizeDelta.y < _heightOpen)
        {
            cover.sizeDelta += new Vector2(0,speedRotation) ;
            yield return new WaitForFixedUpdate();

        }
        
        cover.sizeDelta = new Vector2(cover.sizeDelta.x,_heightOpen) ;

        
        
        yield return null;
    }
    
}
