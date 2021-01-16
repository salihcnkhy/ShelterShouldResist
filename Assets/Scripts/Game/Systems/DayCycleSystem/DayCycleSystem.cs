
namespace Game.Systems.DayCycle
{
    using Game.Constants;
    using Game.Extensions;
    using Game.Generic.Base;
    using Game.Generic.SKObserver;
    using Game.Interface.Systems;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Game.Systems.EventSystem;
    using Game.Model.Systems;

    public class DayCycleSystem : BaseSubSystem
    {


        public DayCycleSystem(MainSystemShared Shared) : base(Shared)
        {
            Shared.MonoBehaviourReferance.StartCoroutine(DayCounter());
        }

        IEnumerator DayCounter()
        {
            while(true)
            {
                yield return new WaitForSeconds(1);
                    Shared.EventSystem.CurrentTime.Increase(1);
                    TimeRange currentTimeRange = Shared.EventSystem.CurrentTime.Get().GetRange();
                    switch (currentTimeRange)
                    {
                        case TimeRange.Dawn:
                            break;
                        case TimeRange.Day:
                            break;
                        case TimeRange.Evening:
                            break;
                        case TimeRange.Night:
                            break;
                        case TimeRange.NewDay:
                            Debug.Log("Passing new day");
                            Shared.EventSystem.CurrentTime.Set(0);
                            Shared.EventSystem.CurrentDay.Increase(1);
                            Shared.EventSystem.DaysToNextWave.Decrease(1);
                            break;
                    }
                    if (Shared.EventSystem.CurrentTimeRange.Get() != currentTimeRange)
                        Shared.EventSystem.CurrentTimeRange.Set(currentTimeRange);
                }
            }
        }

    }


