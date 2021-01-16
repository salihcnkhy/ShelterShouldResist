using Game.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Extensions
{
    public static class Extensions
    {
        public static bool IsBetween<T>(this T value, T low, T high) where T : IComparable<T>
        {
            return value.CompareTo(low) >= 0 && value.CompareTo(high) <= 0;
        }

        public static TimeRange GetRange(this int value)
        {
            if (value < DayCycleConstant.DawnTime)
                return TimeRange.Dawn;
            else if (value.IsBetween(DayCycleConstant.DawnTime, DayCycleConstant.DayTime))
                return TimeRange.Day;
            else if (value.IsBetween(DayCycleConstant.DayTime, DayCycleConstant.EveningTime))
                return TimeRange.Evening;
            else if (value.IsBetween(DayCycleConstant.EveningTime, DayCycleConstant.NightTime))
                return TimeRange.Night;
            else
                return TimeRange.NewDay;
        }
    }

}
