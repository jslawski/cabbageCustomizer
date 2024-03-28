using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using CharacterCustomizer;

public class CharacterPreview : MonoBehaviour
{
    public static CharacterPreview instance;

    public CustomCharacter character;

    public Dictionary<AttributeType, AttributeType> attributeSideCache;

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

    private void Start()
    {
        this.Initialize();
    }

    private void Initialize()
    { 
        this.character.LoadCharacterFromJSON(CurrentPlayerData.data.attributeSettingsJSON);
    }

    public void UpdateSideCache(AttributeType keyAttribute, AttributeType valueAttribute)
    {
        this.attributeSideCache[keyAttribute] = valueAttribute;
    }

    public AttributeType TryGetCachedAttributeType(AttributeType attType)
    {
        AttributeType returnType = attType;

        if (this.attributeSideCache.ContainsKey(attType))
        {
            returnType = this.attributeSideCache[attType];
        }

        return returnType;
    }

    public CharacterAttribute GetCachedAttribute(AttributeType attType)
    {
        return this.character.GetAttribute(this.TryGetCachedAttributeType(attType));
    }

    public void ClearAllAttributes()
    {
        AttributeSettings.LoadData(AttributeSettings.DefaultSettings);
        this.character.GetAttribute(AttributeType.BaseCabbage).SetAssetName("02");
        this.character.UpdateAllAttributes();
    }
}