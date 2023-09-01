using UnityEngine;

[System.Serializable]
public class AllAttributeSettingsData
{
    public AttributeSettingsData baseCabbage;
    public AttributeSettingsData headpiece;
    public DoubleAttributeSettingsData eyebrows;
    public DoubleAttributeSettingsData eyes;
    public AttributeSettingsData nose;
    public AttributeSettingsData mouth;
    public AttributeSettingsData acc1;
    public AttributeSettingsData acc2;
    public AttributeSettingsData acc3;

    public AllAttributeSettingsData()
    {
        this.baseCabbage = new AttributeSettingsData();
        this.headpiece = new AttributeSettingsData();
        this.eyebrows = new DoubleAttributeSettingsData();
        this.eyes = new DoubleAttributeSettingsData();
        this.nose = new AttributeSettingsData();
        this.mouth = new AttributeSettingsData();
        this.acc1 = new AttributeSettingsData();
        this.acc2 = new AttributeSettingsData();
        this.acc3 = new AttributeSettingsData();
    }

    public AllAttributeSettingsData(AllAttributeSettingsData dataToCopy)
    {
        this.baseCabbage = new AttributeSettingsData(dataToCopy.baseCabbage);
        this.headpiece = new AttributeSettingsData(dataToCopy.headpiece);
        this.eyebrows = new DoubleAttributeSettingsData(dataToCopy.eyebrows);
        this.eyes = new DoubleAttributeSettingsData(dataToCopy.eyes);
        this.nose = new AttributeSettingsData(dataToCopy.nose);
        this.mouth = new AttributeSettingsData(dataToCopy.mouth);
        this.acc1 = new AttributeSettingsData(dataToCopy.acc1);
        this.acc2 = new AttributeSettingsData(dataToCopy.acc2);
        this.acc3 = new AttributeSettingsData(dataToCopy.acc3);
    }

    public AttributeSettingsData GetAttributeSettingsData(AttributeType attType)
    {
        switch (attType)
        {
            case AttributeType.BaseCabbage:
                return this.baseCabbage;
            case AttributeType.Headpiece:
                return this.headpiece;
            case AttributeType.EyebrowL:
                return this.eyebrows.left;
            case AttributeType.EyebrowR:
                return this.eyebrows.right;
            case AttributeType.EyeL:
                return this.eyes.left;
            case AttributeType.EyeR:
                return this.eyes.right;
            case AttributeType.Nose:
                return this.nose;
            case AttributeType.Mouth:
                return this.mouth;
            case AttributeType.Acc1:
                return this.acc1;
            case AttributeType.Acc2:
                return this.acc2;
            case AttributeType.Acc3:
                return this.acc3;
            default:
                Debug.LogError("Unknown AttributeType: " + attType);
                return null;
        }
    }
}
