using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterCustomizer;

public static class CurrentCustomizerData
{
    public static AttributeType currentAttributeType;
    public static AttributeSettingsData currentAttributeSettingsData;

    static public bool IsSingleAttribute()
    {
        return (CurrentCustomizerData.currentAttributeType != AttributeType.Eyebrows &&
            CurrentCustomizerData.currentAttributeType != AttributeType.EyebrowL &&
            CurrentCustomizerData.currentAttributeType != AttributeType.EyebrowR &&
            CurrentCustomizerData.currentAttributeType != AttributeType.Eyes &&
            CurrentCustomizerData.currentAttributeType != AttributeType.EyeL &&
            CurrentCustomizerData.currentAttributeType != AttributeType.EyeR);
    }
}
