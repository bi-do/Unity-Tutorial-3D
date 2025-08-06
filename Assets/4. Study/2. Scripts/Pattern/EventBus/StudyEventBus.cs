using System;
using UnityEngine;

namespace Pattern
{
    public static class StudyEventBus
    {
        public static event Action on_init_act;
        public static event Action<int> on_score_act;

        public static void StartEvent()
        {
            on_init_act?.Invoke();
        }

        public static void ScoreChanged(int param_score)
        {
            on_score_act?.Invoke(param_score);
        }

    }

}