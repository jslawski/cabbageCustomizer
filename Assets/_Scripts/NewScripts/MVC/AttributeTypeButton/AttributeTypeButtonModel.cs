using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;
using UnityEngine.UI;

public class AttributeTypeButtonModel : MonoBehaviour
{    
    public Sprite defaultSprite;

    public AttributeType attributeType;
    
    [HideInInspector]
    public bool shouldShow = false;
    [HideInInspector]    
    public bool isSelected = false;
    [HideInInspector]
    public Sprite leftSprite;
    [HideInInspector]
    public Sprite rightSprite;
    [HideInInspector]
    public Sprite centerSprite;
}
