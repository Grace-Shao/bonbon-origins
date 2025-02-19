using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DelaySkillHealAnimation : DelaySkillPercentAnimation
{
    protected override IEnumerator CreateCoroutine(AnimationHandler handler, AIActionValue[] avs, Actor[] target, PercentTrigger trigger) {
        yield return new WaitForSeconds(trigger.TriggerTime);
        for (int i = 0; i < avs.Length; ++i) {
            handler.TriggerHeal((int)(avs[i].immediateDamage * trigger.Multiplier), target[i]);
        }
    }
#if UNITY_EDITOR
    protected override void InnerGUI() {
        description = "healing";
        base.InnerGUI();
    }
#endif
}
