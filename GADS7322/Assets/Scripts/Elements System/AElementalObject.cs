using System;
using Managers;
using UnityEngine;

public abstract class AElementalObject :MonoBehaviour
{
    [Header("Base Components")]
    [SerializeField] protected EElement objectElement;
    
    [Header("EditorComponent")]
    [SerializeField] protected bool startActive;

    protected virtual void OnEnable()
    {
        GameManager.OnElementSwitch += ReactToElement;
    }

    protected virtual void OnDisable()
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
        return objectElement == AType;
    }
    


}
