using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatedPanel : MonoBehaviour, IAnimatedUIElement
{
    [SerializeField]
    private Animator _animator;


    public void Reveal()
    {
        this.ChangeAnimationState(AnimatedUIElementState.Appear);
    }

    public void Hide()
    {
        this.ChangeAnimationState(AnimatedUIElementState.Hide);
    }

    protected void ChangeAnimationState(AnimatedUIElementState newState)
    {
        AnimatedUIElementState[] states =
            (AnimatedUIElementState[])Enum.GetValues(typeof(AnimatedUIElementState));

        for (int i = 0; i < states.Length; i++)
        {
            if (states[i] == newState)
            {
                this._animator.SetTrigger(states[i].ToString());
            }
            else
            {
                this._animator.ResetTrigger(states[i].ToString());
            }
        }
    }
}
