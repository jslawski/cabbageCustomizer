using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSliderController : MonoBehaviour
{
    public enum PositionAxis { XAxis, YAxis, ZAxis };

    public PositionAxis axis;

    private bool _setupComplete = false;
    
    void Start()
    {
        
    }

    public void UpdateAttributePosition()
    { 
        if (this._setupComplete == false)
        { 
            return;
        }
    }
}
