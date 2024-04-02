using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteButtonModel : MonoBehaviour
{
    [HideInInspector]
    public Sprite leftSprite;
    [HideInInspector]
    public Sprite rightSprite;
    [HideInInspector]
    public Sprite centerSprite;
    [HideInInspector]
    public bool shouldShow = false;
    [HideInInspector]
    public bool isSelected = false;
}
