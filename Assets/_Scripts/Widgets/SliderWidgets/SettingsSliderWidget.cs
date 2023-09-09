using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsSliderWidget : SettingsWidget
{
    [SerializeField]
    protected Slider settingSlider;
    [SerializeField]
    protected TextMeshProUGUI sliderLabel;
    [SerializeField]
    protected AttributeSettingType associatedSetting;
    [SerializeField]
    protected float minValue;
    [SerializeField]
    protected float maxValue;
    [SerializeField]
    protected AnimationCurve animationCurve;

    protected Coroutine updateSettingCoroutine = null;

    #region Base Implementation
    public override void SetupWidget()
    {
        string[] settingString = this.associatedSetting.ToString().Split("_");

        this.sliderLabel.text = settingString[0];

        if (settingString.Length > 1)
        {
            this.sliderLabel.text += " " + settingString[1];
        }

        this.settingSlider.minValue = this.minValue;
        this.settingSlider.maxValue = this.maxValue;
    }

    public override void RefreshWidget(CabbageAttribute attObj)
    {
        this.associatedAttribute = attObj;
    }
    #endregion

    #region Slider Controls
    //Called OnPointerDown
    public void GrabHandle()
    {                        
        this.settingSlider.handleRect.localScale = new Vector3(1.4f, 1.4f, 1.4f);

        if (this.updateSettingCoroutine != null)
        {
            StopCoroutine(this.updateSettingCoroutine);    
        }

        this.updateSettingCoroutine = StartCoroutine(this.UpdateAttributeSetting());        
    }

    //Called OnPointerUp
    public void ReleaseHandle()
    {
        if (this.updateSettingCoroutine != null)
        {
            StopCoroutine(this.updateSettingCoroutine);
            this.updateSettingCoroutine = null;
        }
        
        this.settingSlider.handleRect.localScale = Vector3.one;
    }

    //This coroutine is only active when it is started by GrabHandle()
    protected IEnumerator UpdateAttributeSetting()
    {
        while (true)
        {
            this.UpdateValue();
            yield return null;
        }
    }

    protected void SetMinMaxValues(float minValue, float maxValue)
    {
        this.settingSlider.minValue = minValue;
        this.settingSlider.maxValue = maxValue;
    }

    protected virtual void UpdateValue()
    {
        this.associatedAttribute.UpdateAttributeObject();
    }

    public virtual void ResetAttributeSetting()
    {        
        this.associatedAttribute.ResetAttributeSetting(this.associatedSetting);
    }
    #endregion

    #region Animation
    protected void AnimateSliderToValue(float target)
    {
        StartCoroutine(this.SliderAnimation(target));        
    }

    protected virtual IEnumerator SliderAnimation(float target)
    {
        float timeToAnimationCompletion = Random.Range(0.2f, 0.5f);
        float animationTimeChangeNextFrame = (1.0f / timeToAnimationCompletion) * Time.deltaTime;

        this.settingSlider.value = this.minValue;
        this.settingSlider.wholeNumbers = false;
        this.settingSlider.interactable = false;

        float targetDiff = target - this.minValue;

        for (float i = 0.0f; i <= 1.0f; i += animationTimeChangeNextFrame)
        {
            float animationValue = this.minValue + (this.animationCurve.Evaluate(i) * targetDiff);
            if (animationValue >= this.maxValue)
            {
                animationValue = this.maxValue;
            }

            if (this.animationCurve.Evaluate(i) > 1.0f)
            {
                this.AnimateHandle(this.animationCurve.Evaluate(i));
            }

            this.settingSlider.value = animationValue;

            yield return null;

            animationTimeChangeNextFrame = (1.0f / timeToAnimationCompletion) * Time.deltaTime;
        }

        this.settingSlider.value = target;
        this.settingSlider.handleRect.localScale = Vector3.one;

        this.settingSlider.interactable = true;

        if (this.associatedSetting == AttributeSettingType.Depth)
        {
            this.settingSlider.wholeNumbers = true;
        }
    }

    protected void AnimateHandle(float value)
    {
        float scaleDiff = (value - 1.0f) * 2.0f;

        float newScale = 1.0f + scaleDiff;

        this.settingSlider.handleRect.localScale = new Vector3(newScale, newScale, newScale);
    }    
    #endregion
}
