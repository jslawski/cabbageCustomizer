using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SliderSetting { Horizontal_Position, Spacing, Vertical_Position, Scale, Rotation, Angle, Depth }

public class SettingsSliderWidget : SettingsWidget
{
    [SerializeField]
    private Slider settingSlider;
    [SerializeField]
    private TextMeshProUGUI sliderLabel;
    [SerializeField]
    private SliderSetting associatedSetting;
    [SerializeField]
    private float minValue;
    [SerializeField]
    private float maxValue;

    [SerializeField]
    private AnimationCurve animationCurve;

    private CabbageAttribute associatedAttribute;

    private bool isAnimating = false;

    public void GrowHandle()
    {
        this.settingSlider.handleRect.localScale = new Vector3(1.4f, 1.4f, 1.4f);
    }

    public void ResetHandleSize()
    {
        this.settingSlider.handleRect.localScale = Vector3.one;
    }

    public override void SetupWidget(AttributeType newType)
    {
        //Do this.settingsSlider.OnPointerDown() and OnPointerUp() setup stuff here to "bulge" the handle when it's grabbed.
        string[] settingString = this.associatedSetting.ToString().Split("_");

        this.sliderLabel.text = settingString[0];

        if (settingString.Length > 1)
        {
            this.sliderLabel.text += " " + settingString[1];
        }

        this.settingSlider.minValue = this.minValue;
        this.settingSlider.maxValue = this.maxValue;

        this.associatedAttribute = CharacterPreview.instance.GetAttributeFromType(newType);

        if (newType == AttributeType.Base)
        {
            this.gameObject.SetActive(false);
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
        }

        switch (this.associatedSetting)
        {
            case SliderSetting.Horizontal_Position:
                this.AnimateSliderToValue(this.associatedAttribute.GetPosition().x);
                break;
            case SliderSetting.Vertical_Position:
                this.AnimateSliderToValue(this.associatedAttribute.GetPosition().y);
                break;
            case SliderSetting.Scale:
                this.AnimateSliderToValue(this.associatedAttribute.GetScale().x);
                break;
            case SliderSetting.Rotation:
                this.AnimateSliderToValue(-this.GetInitialRotation());
                break;
            case SliderSetting.Depth:
                this.AnimateSliderToValue(this.associatedAttribute.GetDepth());
                break;
            default:
                Debug.LogError("Unknown Setting: " + this.associatedSetting);
                break;
        }
    }

    private void AnimateSliderToValue(float target)
    {
        StartCoroutine(this.SliderAnimation(target));        
    }

    private IEnumerator SliderAnimation(float target)
    {
        float timeToAnimationCompletion = Random.Range(0.2f, 0.5f);
        float animationTimeChangeNextFrame = (1.0f / timeToAnimationCompletion) * Time.deltaTime;

        this.isAnimating = true;

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

        this.isAnimating = false;
        this.settingSlider.interactable = true;

        if (this.associatedSetting == SliderSetting.Depth)
        {
            this.settingSlider.wholeNumbers = true;
        }
    }

    private void AnimateHandle(float value)
    {
        float scaleDiff = (value - 1.0f) * 2.0f;

        float newScale = 1.0f + scaleDiff;

        this.settingSlider.handleRect.localScale = new Vector3(newScale, newScale, newScale);
    }

    private float GetInitialRotation()
    {
        float adjustedRotationValue = this.associatedAttribute.GetRotation().eulerAngles.z;

        Debug.LogError("Initial Rotation: " + adjustedRotationValue);

        if (adjustedRotationValue > 180)
        {
            adjustedRotationValue -= 360;
        }

        Debug.LogError("Adjusted Rotation: " + adjustedRotationValue);

        return adjustedRotationValue;
    }

    public void UpdateValue()
    {
        if (this.associatedAttribute == null || this.isAnimating == true)
        {
            return;
        }

        switch (this.associatedSetting)
        {
            case SliderSetting.Horizontal_Position:
                this.associatedAttribute.UpdateHorizontalPosition(this.settingSlider.value);
                break;
            case SliderSetting.Vertical_Position:
                this.associatedAttribute.UpdateVerticalPosition(this.settingSlider.value);
                break;
            case SliderSetting.Scale:
                this.associatedAttribute.UpdateScale(this.settingSlider.value);
                break;
            case SliderSetting.Rotation:
                //Do this so you can map right to clockwise and left to counterclockwise
                float adjustedSliderValue = -this.settingSlider.value;
                this.associatedAttribute.UpdateRotation(adjustedSliderValue);
                break;
            case SliderSetting.Depth:
                this.associatedAttribute.UpdateDepth((int)this.settingSlider.value);
                break;
            default:
                Debug.LogError("Unknown Setting: " + this.associatedSetting);
                break;
        }
    } 
}
