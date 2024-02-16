using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public class CustomizerState
{    
    protected AttributeType attributeType_;

    public virtual void Enter(AttributeType newType)
    {
        this.attributeType_ = newType;
    }

    public virtual void Exit()
    {
        
    }

    public virtual void UpdateState()
    {

    }
}
