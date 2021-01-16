using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Constants
{
    public sealed class DayCycleConstant
    {
        // Tüm değerle Saniye bazında


       /*
        public static int DawnLong = 30;
        public static int DayLong = 90;
        public static int EveningLong = 30;
        public static int NightLong = 60; 
      */
        
        public static int DawnLong = 4;
        public static int DayLong = 7;
        public static int EveningLong = 4;
        public static int NightLong = 4;
          
        public static int DawnTime = DawnLong;
        public static int DayTime = DawnTime + DayLong;
        public static int EveningTime = DayTime + EveningLong;
        public static int NightTime = EveningTime + NightLong;
        public static int TotalTime = NightTime;
    }
    public sealed class DayCycleTimeColorConstant
    {
        public static Color DawnColor = new Color(80f / 255f, 80f / 255f, 80f / 255f);
        public static Color DayColor = new Color(207f / 255f, 207f / 255f, 207f / 255f);
        public static Color EveningColor = new Color(130f / 255f, 100 / 255f, 50f / 255f);
        public static Color NightColor = new Color(30f / 255f, 30f / 255f, 30f / 255f);
    }

    public enum TimeRange
    {
        Dawn = 1,
        Day = 2,
        Evening = 3,
        Night = 4,
        NewDay = 5
    }

    public static class Extensions
    {
        public static int GetTime(this TimeRange value)
        {
            switch(value)
            {
                case TimeRange.Dawn:
                    return 0;
                case TimeRange.Day:
                    return DayCycleConstant.DawnTime + 1;
                case TimeRange.Evening:
                    return DayCycleConstant.DayTime + 1;
                case TimeRange.Night:
                    return DayCycleConstant.EveningTime + 1;
                default:
                    return 0;
            }
        }
    }

    public class SeasonConstant
    {
        // Tüm değerler gün bazında

        public static int WinterLong = 6;
        public static int SummmerLong = 4;
        public static int FallLong = 4;
    }

}

