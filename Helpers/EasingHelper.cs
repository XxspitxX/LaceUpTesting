using LaceUpTesting.Animations.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Helpers
{
    public static class EasingHelper
    {
        public static Easing? GetEasing(EasingType type) => type switch
        {
            EasingType.BounceIn => Easing.BounceIn,
            EasingType.BounceOut => Easing.BounceOut,
            EasingType.CubicIn => Easing.CubicIn,
            EasingType.CubicInOut => Easing.CubicInOut,
            EasingType.CubicOut => Easing.CubicOut,
            EasingType.Linear => Easing.Linear,
            EasingType.SinIn => Easing.SinIn,
            EasingType.SinInOut => Easing.SinInOut,
            EasingType.SinOut => Easing.SinOut,
            EasingType.SpringIn => Easing.SpringIn,
            EasingType.SpringOut => Easing.SpringOut,
            _ => null,
        };
    }
}
