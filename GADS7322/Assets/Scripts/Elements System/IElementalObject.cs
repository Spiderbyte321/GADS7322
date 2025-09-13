using System;
using Managers;
using UnityEngine;

public abstract class IElementalObject :MonoBehaviour
{

    [SerializeField] protected EElement objectElement;
    [SerializeField] protected GameObject ObjectToHide;

    private void OnEnable()
    {
        GameManager.OnElementSwitch += ReactToElement;
    }

    private void OnDisable()
    {
        GameManager.OnElementSwitch -= ReactToElement;
    }


    public virtual void ReactToElement(EElement ATypeToCheck)
    {
        
        if(CheckType(ATypeToCheck))
        { 
          ObjectToHide.SetActive(true);  
        }
        else
        { 
            ObjectToHide.SetActive(false);
        }
    }
    
    
    
    
    private bool CheckType(EElement AType)
    {
        if (objectElement == AType)
        {
            return true; 
        }
           

        return false;
    }


}
