using UnityEngine;
using CharacterCustomizer;

public class AttributeTypeButtonModel : MonoBehaviour
{    
    public Sprite defaultSprite;

    public AttributeType attributeType;
    
    [HideInInspector]
    public bool shouldShow = false;
    [HideInInspector]    
    public bool isSelected = false;
    [HideInInspector]
    public bool isEquipped = false;
    [HideInInspector]
    public Sprite leftSprite;
    [HideInInspector]
    public Sprite rightSprite;
    [HideInInspector]
    public Sprite centerSprite;
}
