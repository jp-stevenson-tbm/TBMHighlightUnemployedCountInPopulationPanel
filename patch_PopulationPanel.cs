using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UIElements;
using HarmonyLib;
using Timberborn.PopulationUI;

namespace TBMHighlightUnemployedCountInPopulationPanel
{
    [HarmonyPatch(typeof(PopulationPanel), "PostLoad")]
    class patch_PopulationPanel
    {
        public static void Postfix(PopulationPanel __instance, VisualElement ____root)
        {
            if (____root == null)
            {
                Debug.LogError("failed to change order of UnemploymentCounters.");
                Debug.LogWarning($"  _root:{____root}");
                return;
            }

            VisualElement EmploymentCounters = ____root.Q("EmploymentCounters", null, null);
            VisualElement EmploymentCountersWrapper = ____root.Q("EmploymentCountersWrapper", null, null);
            VisualElement UnemployedCount = ____root.Q("UnemployedCount", null, null);

            // 雇用リストと無職カウンターの順序を入れ替える
            if (EmploymentCounters != null && EmploymentCountersWrapper != null)
            {
                EmploymentCounters.RemoveFromHierarchy();
                EmploymentCountersWrapper.Add(EmploymentCounters);
            }
            else
            {
                Debug.LogError("failed to change order of UnemploymentCounters.");
                Debug.LogWarning($"employmentCounters:{EmploymentCounters}");
                Debug.LogWarning($"employmentCountersWrapper:{EmploymentCountersWrapper}");
            }

            //無職カウンターを赤表示する。
            if (UnemployedCount != null)
            {
                foreach (VisualElement elm in UnemployedCount.parent.Children())
                {
                    elm.style.color = new StyleColor(Color.yellow);
                }
            }
            else
            {
                Debug.LogError("failed to change style of UnemployedCount.");
                Debug.LogWarning($"UnemployedCount:{UnemployedCount}");

            }
        }
    }
}
