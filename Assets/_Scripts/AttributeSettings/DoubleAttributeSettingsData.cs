using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DoubleAttributeSettingsData
{
    public AttributeSettingsData left;
    public AttributeSettingsData right;

    public DoubleAttributeSettingsData()
    {
        this.left = new AttributeSettingsData();
        this.right = new AttributeSettingsData();
    }

    public DoubleAttributeSettingsData(DoubleAttributeSettingsData dataToCopy)
    {
        this.left = new AttributeSettingsData(dataToCopy.left);
        this.right = new AttributeSettingsData(dataToCopy.right);
    }
}
