using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipButton : MonoBehaviour
{
    public void ToggleFlipX()
    {
        CabbageAttribute currentAttribute = CharacterPreview.instance.GetAttributeFromType(CharacterPreview.instance.currentAttribute);
        currentAttribute.UpdateXFlip(!currentAttribute.GetXFlip());
    }
}
