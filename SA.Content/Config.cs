﻿using System;
using System.Collections.Generic;
using System.Text;
using BepInEx.Configuration;
using BepInEx;
using RoR2;

namespace StageAesthetic
{
    public class Config : SwapVariants
    {
        public static void SetConfig()
        {
            AesConfig = new ConfigFile(Paths.ConfigPath + "\\StageAesthetic.cfg", true);
            VanillaPlains = AesConfig.Bind("Stages : Titanic Plains", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            NostalgiaPlains = AesConfig.Bind("Stages : Titanic Plains", "Enable Nostalgia Plains?", true, "Brings back the look from Pre-1.0");
            SunrisePlains = AesConfig.Bind("Stages : Titanic Plains", "Enable Sunrise Plains?", true, "");
            SunsetPlains = AesConfig.Bind("Stages : Titanic Plains", "Enable Sunset Plains?", true, "");
            RainyPlains = AesConfig.Bind("Stages : Titanic Plains", "Enable Rainy Plains?", true, "");
            NightPlains = AesConfig.Bind("Stages : Titanic Plains", "Enable Night Plains?", true, "");
            PlainsBridge = AesConfig.Bind<int>("Stages : Titanic Plains", "Bridge % Chance", 40, "How often the unused bridge in Titanic Plains should appear.");

            VanillaRoost = AesConfig.Bind("Stages : Distant Roost", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            NightRoost = AesConfig.Bind("Stages : Distant Roost", "Enable Night Roost?", true, "");
            SunnyRoost = AesConfig.Bind("Stages : Distant Roost", "Enable Sunny Roost?", true, "");
            FoggyRoost = AesConfig.Bind("Stages : Distant Roost", "Enable Storm Roost?", true, "");
            VoidRoost = AesConfig.Bind("Stages : Distant Roost", "Enable Void Roost?", true, "");
            RoostChanges = AesConfig.Bind("Stages : Distant Roost", "Add rain in alt version?", true, "");

            NightForest = AesConfig.Bind("Stages : Siphoned Forest", "Enable Night Forest?", true, "");
            ExtraSnowyForest = AesConfig.Bind("Stages : Siphoned Forest", "Enable Extra Snowy Forest?", true, "");
            CrimsonForest = AesConfig.Bind("Stages : Siphoned Forest", "Enable Crimson Forest?", true, "");
            VanillaForest = AesConfig.Bind("Stages : Siphoned Forest", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");

            VanillaAphelian = AesConfig.Bind("Stages :: Aphelian Sanctuary", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            NearRainAphelian = AesConfig.Bind("Stages :: Aphelian Sanctuary", "Enable Twilight Sanctuary?", true, "");
            SunsetterAphelian = AesConfig.Bind("Stages :: Aphelian Sanctuary", "Enable Sunrise Sanctuary?", true, "");
            NightAphelian = AesConfig.Bind("Stages :: Aphelian Sanctuary", "Enable Singularity Sanctuary?", true, "");

            VanillaWetland = AesConfig.Bind("Stages :: Wetland Aspect", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            SunsetWetland = AesConfig.Bind("Stages :: Wetland Aspect", "Enable Sunset Aspect?", true, "");
            SkyWetland = AesConfig.Bind("Stages :: Wetland Aspect", "Enable Sky Aspect?", true, "");
            EveningWetland = AesConfig.Bind("Stages :: Wetland Aspect", "Enable Dark Aspect?", true, "");
            VoidWetland = AesConfig.Bind("Stages :: Wetland Aspect", "Enable Void Aspect?", true, "");

            VanillaAqueduct = AesConfig.Bind("Stages :: Abandoned Aqueduct", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            NightAqueduct = AesConfig.Bind("Stages :: Abandoned Aqueduct", "Enable Dark Aqueduct?", true, "");
            RainyAqueduct = AesConfig.Bind("Stages :: Abandoned Aqueduct", "Enable Rainy Aqueduct?", true, "");
            MistyAqueduct = AesConfig.Bind("Stages :: Abandoned Aqueduct", "Enable Night Aqueduct?", true, "");
            AqueductChanges = AesConfig.Bind("Stages :: Abandoned Aqueduct", "Alter vanilla Abandoned Aqueduct?", true, "Makes the sun a slightly more intense yellow-orange, and changes its angle.");

            VanillaDelta = AesConfig.Bind("Stages ::: Rallypoint Delta", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            NightDelta = AesConfig.Bind("Stages ::: Rallypoint Delta", "Enable Night Delta?", true, "");
            FoggyDelta = AesConfig.Bind("Stages ::: Rallypoint Delta", "Enable Foggy Delta?", true, "");
            PurpleDelta = AesConfig.Bind("Stages ::: Rallypoint Delta", "Enable Emerald Delta?", true, "");

            VanillaAcres = AesConfig.Bind("Stages ::: Scorched Acres", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            SunsetAcres = AesConfig.Bind("Stages ::: Scorched Acres", "Enable Sunset Acres?", true, "");
            NightAcres = AesConfig.Bind("Stages ::: Scorched Acres", "Enable Night Acres?", true, "");
            BlueAcres = AesConfig.Bind("Stages ::: Scorched Acres", "Enable Emerald Acres?", true, "");
            AcresChanges = AesConfig.Bind("Stages ::: Scorched Acres", "Alter vanilla Scorched Acres?", true, "Greatly increases the sunlight intensity, and alters the light angle and sun position towards a different corner of the map.");

            VanillaSulfur = AesConfig.Bind("Stages ::: Sulfur Pools", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            CoralBlueSulfur = AesConfig.Bind("Stages ::: Sulfur Pools", "Enable Coral Blue Pools?", true, "");
            HellSulfur = AesConfig.Bind("Stages ::: Sulfur Pools", "Enable Hell Pools?", true, "");

            VanillaDepths = AesConfig.Bind("Stages :::: Abyssal Depths", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            DarkDepths = AesConfig.Bind("Stages :::: Abyssal Depths", "Enable Azure Depths?", true, "");
            BlueDepths = AesConfig.Bind("Stages :::: Abyssal Depths", "Enable Hive Cluster Depths?", true, "");
            SkyDepths = AesConfig.Bind("Stages :::: Abyssal Depths", "Enable Sky Meadow Depths?", true, "");
            DepthsChanges = AesConfig.Bind("Stages :::: Abyssal Depths", "Alter vanilla Abyssal Depths?", true, "Greatly increases the sunlight intensity, and alters the light angle.");

            VanillaGrove = AesConfig.Bind("Stages :::: Sundered Grove", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            GreenGrove = AesConfig.Bind("Stages :::: Sundered Grove", "Enable Olive Grove?", true, "");
            SunnyGrove = AesConfig.Bind("Stages :::: Sundered Grove", "Enable Sunny Grove?", true, "");
            HannibalGrove = AesConfig.Bind("Stages :::: Sundered Grove", "Enable Overcast Grove?", true, "");

            VanillaSiren = AesConfig.Bind("Stages :::: Sirens Call", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            NightSiren = AesConfig.Bind("Stages :::: Sirens Call", "Enable Night Call?", true, "");
            SunnySiren = AesConfig.Bind("Stages :::: Sirens Call", "Enable Sirens Sun?", true, "");
            MistySiren = AesConfig.Bind("Stages :::: Sirens Call", "Enable Sirens Storm?", true, "");

            VanillaMeadow = AesConfig.Bind("Stages ::::: Sky Meadow", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            NightMeadow = AesConfig.Bind("Stages ::::: Sky Meadow", "Enable Night Meadow?", true, "");
            StormyMeadow = AesConfig.Bind("Stages ::::: Sky Meadow", "Enable Stormy Meadow?", true, "");
            CrimsonMeadow = AesConfig.Bind("Stages ::::: Sky Meadow", "Enable Abyssal Meadow?", true, "");
            TitanicMeadow = AesConfig.Bind("Stages ::::: Sky Meadow", "Enable Titanic Meadow?", true, "");
            MeadowChanges = AesConfig.Bind("Stages ::::: Sky Meadow", "Alter vanilla Sky Meadow?", true, "Makes the sun a slightly more intense yellow-orange.");

            CommencementAlt = AesConfig.Bind("Stages :::::: Commencement", "Commencement alt?", true, "");

            VanillaLocus = AesConfig.Bind("Stages ::::::: Void Locus", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            BlueLocus = AesConfig.Bind("Stages ::::::: Void Locus", "Enable Blue Locus?", true, "");
            RedLocus = AesConfig.Bind("Stages ::::::: Void Locus", "Enable Pink Locus?", true, "");
            PurpleLocus = AesConfig.Bind("Stages ::::::: Void Locus", "Enable Green Locus?", true, "");

            VanillaPlanetarium = AesConfig.Bind("Stages :::::::: The Planetarium", "Enable Vanilla?", true, "Disabling removes vanilla from getting picked");
            // PurplePlanetarium = AesConfig.Bind("Stages :::::::: The Planetarium", "Enable Purple Planetarium?", true, "");
            // TwilightPlanetarium = AesConfig.Bind("Stages :::::::: The Planetarium", "Enable Twilight Planetarium?", true, "");

            TitleScene = AesConfig.Bind("Stages Title", "Alter title screen?", true, "Adds rain, patches of grass, particles and brings a Commando closer to focus.");
            WeatherEffects = AesConfig.Bind("Stages Weather", "Import weather effects?", true, "Hooks into SceneCamera to import rain and ember effects into stages that normally don't have them. Disabling this is recommended if performance is an issue or if playing Starstorm 2, as it overlaps with the latter's weather.");
        }

        public static void ApplyConfig(Run obj)
        {
            plainsList = new List<string>();
            roostList = new List<string>();
            wetlandList = new List<string>();
            aqueductList = new List<string>();
            deltaList = new List<string>();
            acresList = new List<string>();
            depthsList = new List<string>();
            sirenList = new List<string>();
            groveList = new List<string>();
            meadowList = new List<string>();
            forestList = new List<string>();
            aphelianList = new List<string>();
            sulfurList = new List<string>();
            locusList = new List<string>();
            planetariumList = new List<string>();

            if (VanillaPlains.Value) plainsList.Add("vanilla");
            if (SunrisePlains.Value) plainsList.Add("sunrise");
            if (SunsetPlains.Value) plainsList.Add("sunset");
            if (RainyPlains.Value) plainsList.Add("rain");
            if (NightPlains.Value) plainsList.Add("night");
            if (NostalgiaPlains.Value) plainsList.Add("nostalgia");
            if (plainsList.Count == 0)
            {
                AesLog.LogWarning("Titanic Plains list empty - adding vanilla...");
                plainsList.Add("vanilla");
            }

            if (VanillaRoost.Value) roostList.Add("vanilla");
            if (NightRoost.Value) roostList.Add("night");
            if (SunnyRoost.Value) roostList.Add("sunny");
            if (FoggyRoost.Value) roostList.Add("foggy");
            if (VoidRoost.Value) roostList.Add("void");
            if (roostList.Count == 0)
            {
                AesLog.LogWarning("Distant Roost list empty - adding vanilla...");
                roostList.Add("vanilla");
            }

            if (NightForest.Value) forestList.Add("night");
            if (ExtraSnowyForest.Value) forestList.Add("extrasnowy");
            if (CrimsonForest.Value) forestList.Add("crimson");
            if (VanillaForest.Value) forestList.Add("vanilla");
            if (forestList.Count == 0)
            {
                AesLog.LogWarning("Siphoned Forest list empty - adding vanilla...");
                forestList.Add("vanilla");
            }

            //

            if (VanillaWetland.Value) wetlandList.Add("vanilla");
            if (SunsetWetland.Value) wetlandList.Add("sunset");
            if (SkyWetland.Value) wetlandList.Add("sky");
            if (EveningWetland.Value) wetlandList.Add("dark");
            if (VoidWetland.Value) wetlandList.Add("void");
            if (wetlandList.Count == 0)
            {
                AesLog.LogWarning("Wetland Aspect list empty - adding vanilla...");
                wetlandList.Add("vanilla");
            }

            if (VanillaAqueduct.Value) aqueductList.Add("vanilla");
            if (NightAqueduct.Value) aqueductList.Add("night");
            if (RainyAqueduct.Value) aqueductList.Add("rain");
            if (MistyAqueduct.Value) aqueductList.Add("nightrain");
            if (aqueductList.Count == 0)
            {
                AesLog.LogWarning("Abandoned Aqueduct list empty - adding vanilla...");
                aqueductList.Add("vanilla");
            }

            if (NearRainAphelian.Value) aphelianList.Add("nearrain");
            if (SunsetterAphelian.Value) aphelianList.Add("sunrise");
            if (NightAphelian.Value) aphelianList.Add("night");
            if (VanillaAphelian.Value) aphelianList.Add("vanilla");
            if (aphelianList.Count == 0)
            {
                AesLog.LogWarning("Aphelian Sanctuary list empty - adding vanilla...");
                aphelianList.Add("vanilla");
            }

            //

            if (VanillaDelta.Value) deltaList.Add("vanilla");
            if (NightDelta.Value) deltaList.Add("night");
            if (FoggyDelta.Value) deltaList.Add("foggy");
            if (PurpleDelta.Value) deltaList.Add("green");
            if (deltaList.Count == 0)
            {
                AesLog.LogWarning("Rallypoint Delta list empty - adding vanilla...");
                deltaList.Add("vanilla");
            }

            if (VanillaAcres.Value) acresList.Add("vanilla");
            if (SunsetAcres.Value) acresList.Add("sunset");
            if (NightAcres.Value) acresList.Add("night");
            if (BlueAcres.Value) acresList.Add("nothing");
            if (acresList.Count == 0)
            {
                AesLog.LogWarning("Scorched Acres list empty - adding vanilla...");
                acresList.Add("vanilla");
            }

            if (VanillaSulfur.Value) sulfurList.Add("vanilla");
            if (CoralBlueSulfur.Value) sulfurList.Add("coralblue");
            if (HellSulfur.Value) sulfurList.Add("hell");
            if (sulfurList.Count == 0)
            {
                AesLog.LogWarning("Sulfur Pools list empty - adding vanilla...");
                sulfurList.Add("vanilla");
            }

            //

            if (VanillaDepths.Value) depthsList.Add("vanilla");
            if (DarkDepths.Value) depthsList.Add("gold");
            if (BlueDepths.Value) depthsList.Add("hive");
            if (SkyDepths.Value) depthsList.Add("sky");
            if (depthsList.Count == 0)
            {
                AesLog.LogWarning("Abyssal Depths list empty - adding vanilla...");
                depthsList.Add("vanilla");
            }

            if (VanillaGrove.Value) groveList.Add("vanilla");
            if (GreenGrove.Value) groveList.Add("green");
            if (SunnyGrove.Value) groveList.Add("sunny");
            if (HannibalGrove.Value) groveList.Add("storm");
            if (groveList.Count == 0)
            {
                AesLog.LogWarning("Sundered Grove list empty - adding vanilla...");
                groveList.Add("vanilla");
            }

            if (VanillaSiren.Value) sirenList.Add("vanilla");
            if (NightSiren.Value) sirenList.Add("night");
            if (SunnySiren.Value) sirenList.Add("sunny");
            if (MistySiren.Value) sirenList.Add("storm");
            if (sirenList.Count == 0)
            {
                AesLog.LogWarning("Siren's Call list empty - adding vanilla...");
                sirenList.Add("vanilla");
            }

            //

            if (VanillaMeadow.Value) meadowList.Add("vanilla");
            if (NightMeadow.Value) meadowList.Add("night");
            if (StormyMeadow.Value) meadowList.Add("storm");
            if (CrimsonMeadow.Value) meadowList.Add("abyss");
            if (TitanicMeadow.Value) meadowList.Add("titanic");
            if (meadowList.Count == 0)
            {
                AesLog.LogWarning("Sky Meadow list empty - adding vanilla...");
                meadowList.Add("vanilla");
            }

            //

            if (VanillaLocus.Value) locusList.Add("vanilla");
            if (BlueLocus.Value) locusList.Add("blue");
            if (RedLocus.Value) locusList.Add("pink");
            if (PurpleLocus.Value) locusList.Add("green");
            if (locusList.Count == 0)
            {
                AesLog.LogWarning("Void Locus list empty - adding vanilla...");
                locusList.Add("vanilla");
            }

            //

            if (VanillaPlanetarium.Value) planetariumList.Add("vanilla");
            // if (PurplePlanetarium.Value) planetariumList.Add("purple");
            // if (TwilightPlanetarium.Value) planetariumList.Add("twilight");
        }
    }
}