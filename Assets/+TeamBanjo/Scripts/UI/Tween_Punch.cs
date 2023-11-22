using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TeamBanjo.Tween
{
    public class Tween_Punch : MonoBehaviour
    {
        [SerializeField] private Vector3 punch = Vector3.up;
        [SerializeField] private float duration = 2.0f;
        [SerializeField] private int vibrato = 10;
        [SerializeField, Range(0, 1)] private float elasticity = 1;
        [SerializeField] private bool snapping = true;

        public void OnTweenPunch()
        {
            // Ensure that the object is in the original position before tweening it.
            // Otherwise the object might shift if tween is spammed.
            transform.DOComplete();

            transform.DOPunchPosition(punch, duration, vibrato, elasticity, snapping);
        }
    }
}
