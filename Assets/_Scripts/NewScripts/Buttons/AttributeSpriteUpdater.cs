using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeSpriteUpdater : MonoBehaviour
{
    [SerializeField]
    private Image _centerImage;
    [SerializeField]
    private Image _leftImage;
    [SerializeField]
    private Image _rightImage;

    public void UpdateAttributeSprite()
    {
        if (CurrentCustomizerData.instance.IsSingleAttribute() == true)
        { 
            
        }
    }
}
