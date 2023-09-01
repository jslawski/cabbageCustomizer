using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SettingsPanel : MonoBehaviour
{
    public static SettingsPanel instance;

    public Dictionary<AttributeType, AttributeType> attributeSideCache;

    private SettingsWidget[] widgets;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        this.attributeSideCache = new Dictionary<AttributeType, AttributeType>();
        this.attributeSideCache[AttributeType.Eyebrows] = AttributeType.Eyebrows;
        this.attributeSideCache[AttributeType.Eyes] = AttributeType.Eyes;
    }

    public void Initialize()
    {
        this.widgets = GetComponentsInChildren<SettingsWidget>(true);
        this.SetupWidgets();
    }

    public void UpdateSideCache(AttributeType keyAttribute, AttributeType valueAttribute)
    {
        this.attributeSideCache[keyAttribute] = valueAttribute;
    }

    private AttributeType TryGetCacheEntry(AttributeType attType)
    {
        AttributeType returnType = AttributeType.None;

        if (this.attributeSideCache.ContainsKey(attType))
        {
            returnType = this.attributeSideCache[attType];
        }

        return returnType;
    }

    //Only called when a tab is clicked
    public void UpdateSettingsPanel(AttributeType attType)
    {
        this.SetupWidgets();
        this.RefreshWidgets(attType);
    }

    private void SetupWidgets()
    {
        foreach (SettingsWidget widget in this.widgets)
        {
            widget.SetupWidget();
        }
    }

    public void RefreshWidgets(AttributeType attType)
    {
        CabbageAttribute attObj;

        if (this.TryGetCacheEntry(attType) != AttributeType.None)
        {
            attObj = CharacterPreview.instance.GetAttribute(this.TryGetCacheEntry(attType));
        }
        else
        {
            attObj = CharacterPreview.instance.GetAttribute(attType);
        }
        
        foreach (SettingsWidget widget in this.widgets)
        {
            widget.RefreshWidget(attObj);
        }
    }
}
