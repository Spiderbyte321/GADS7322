using System;
using Managers;
using UnityEngine;

public abstract class IElementalObject :MonoBehaviour
{
    [Header("Base Components")]
    [SerializeField] protected EElement objectElement;
    [SerializeField] protected bool startActive;

    private void OnEnable()
    {
        GameManager.OnElementSwitch += ReactToElement;
    }

    private void OnDisable()
    {
        GameManager.OnElementSwitch -= ReactToElement;
    }


    protected virtual void ReactToElement(EElement ATypeToCheck)
    {
        
        if(CheckType(ATypeToCheck))
        {
            throw new NotImplementedException("Implement correct element reaction");
        }
        else
        { 
            throw new NotImplementedException("Implement Incorrect element reaction");
        }
    }
    
    
    
    
    protected virtual bool CheckType(EElement AType)
    {
        if (objectElement == AType)
        {
            return true; 
        }
           

        return false;
    }
    
    protected virtual void OnValidate()
    {
        
    }


}
