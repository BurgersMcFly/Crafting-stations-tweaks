﻿// CraftingStationsTweaks, Valheim mod that removes the roof and fire requirements from crafting stations
// Copyright (C) 2022 BurgersMcFly
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using BepInEx;
using HarmonyLib;


namespace CraftingStationsTweaks
{
    [BepInPlugin(pluginGUID, pluginName, pluginVersion)]
    public class CraftingStationsTweaks : BaseUnityPlugin
    {
        const string pluginGUID = "CraftingStationsTweaks";
        const string pluginName = "Crafting Stations Tweaks";
        const string pluginVersion = "1.0.0";
        public static readonly Harmony harmony = new Harmony("CraftingStationsTweaks");

        void Awake()
        {
            harmony.PatchAll();

        }
    }


    [HarmonyPatch(typeof(CraftingStation), "Start")]
    public static class CraftingStationRemoveRestrictions
    {
        private static void Prefix(ref bool ___m_craftRequireRoof, ref bool ___m_craftRequireFire)
        {
            ___m_craftRequireRoof = false;
            ___m_craftRequireFire = false;
        }
    }
}

