using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using HarmonyLib;
using BepInEx;

namespace TBMHighlightUnemployedCountInPopulationPanel
{
    [BepInPlugin("jp.stevenson.timberbnmod.highlight_unemployedcount_in_PopulationPanel", "highlight unemployedcount in PopulationPanel", "0.1")]
    public class Class1 : BaseUnityPlugin
    {
        public void Awake()
        {
            new Harmony("jp.stevenson.timberbnmod.highlight_unemployedcount_in_PopulationPanel").PatchAll();
            Debug.Log("highlight unemployedcount in PopulationPanel : Loaded.");

        }
    }
}
