﻿using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace StageAesthetic.Variants.Stage3
{
    internal class RallypointDelta
    {
        public static void VanillaChanges()
        {
            DisableRallypointSnow();
            AddSnow(SnowType.Moderate);
        }

        public static void Overcast(RampFog fog, PostProcessVolume volume)
        {
            fog.fogColorStart.value = new Color32(47, 52, 62, 50);
            fog.fogColorMid.value = new Color32(72, 80, 98, 165);
            fog.fogColorEnd.value = new Color32(90, 101, 119, 255);
            fog.skyboxStrength.value = 0.15f;
            fog.fogZero.value = -0.05f;
            fog.fogOne.value = 0.4f;

            var sun = GameObject.Find("Directional Light (SUN)");
            var sunLight = Object.Instantiate(GameObject.Find("Directional Light (SUN)")).GetComponent<Light>();
            sun.SetActive(false);
            sun.name = "Shitty Not Working Sun";
            sunLight.color = new Color32(177, 205, 232, 255);
            sunLight.intensity = 0.5f;
            GameObject.Find("HOLDER: Skybox").transform.Find("Water").localPosition = new Vector3(-1260, -66, 0);
            sunLight.color = new Color32(155, 174, 200, 255);
            sunLight.intensity = 1.3f;
            sunLight.name = "Directional Light (SUN)";

            AddRain(RainType.Monsoon);
            DisableRallypointSnow();
            AddSnow(SnowType.Light, 250f);

            var wind = GameObject.Find("WindZone");
            wind.transform.eulerAngles = new Vector3(30, 20, 0);
            var windZone = wind.GetComponent<WindZone>();
            windZone.windMain = 1;
            windZone.windTurbulence = 1;
            windZone.windPulseFrequency = 0.5f;
            windZone.windPulseMagnitude = 5f;
            windZone.mode = WindZoneMode.Directional;
            windZone.radius = 100;

            var bloom = volume.profile.GetSetting<Bloom>();
            bloom.intensity.value = 0.7f;
            bloom.threshold.value = 0.39f;
            bloom.softKnee.value = 0.7f;
        }

        public static void Night(RampFog fog, ColorGrading cgrade)
        {
            var sun = GameObject.Find("Directional Light (SUN)");
            sun.name = "Shitty Not Working Sun";
            sun.SetActive(false);
            Skybox.NightSky(false, false, 0.4f);

            var lightCurve = new AnimationCurve(new Keyframe(1f, 1f), new Keyframe(1f, 1f));

            var lightList = Object.FindObjectsOfType(typeof(Light)) as Light[];
            foreach (Light light in lightList)
            {
                var lightBase = light.gameObject;
                if (lightBase != null && !lightBase.name.Contains("Light (SUN)"))
                {
                    light.type = LightType.Point;
                    light.shape = LightShape.Cone;
                    light.color = new Color32(233, 233, 190, 255);
                    if (lightBase.GetComponent<FlickerLight>() != null)
                    {
                        lightBase.GetComponent<FlickerLight>().enabled = false;
                    }
                    if (lightBase.GetComponent<LightIntensityCurve>() != null)
                    {
                        var curve = lightBase.GetComponent<LightIntensityCurve>();
                        curve.maxIntensity = 5f;
                        curve.curve = lightCurve;
                        curve.enabled = false;
                    }
                    light.intensity = 5f;
                    light.range = 65f;
                }
            }
            DisableRallypointSnow();
            AddSnow(SnowType.Gigachad, 250f);
            NightMaterials();
        }

        public static void Sunset(RampFog fog, PostProcessVolume volume)
        {
            Skybox.SunsetSky();
            fog.fogColorStart.value = new Color32(66, 66, 66, 50);
            fog.fogColorMid.value = new Color32(62, 18, 28, 150);
            fog.fogColorEnd.value = new Color32(160, 74, 61, 255);
            fog.skyboxStrength.value = 0.1f;
            fog.fogOne.value = 0.12f;
            fog.fogIntensity.overrideState = true;
            fog.fogIntensity.value = 1f;
            fog.fogPower.value = 0.8f;

            var sun = GameObject.Find("Directional Light (SUN)");
            sun.SetActive(false);
            sun.name = "Shitty Not Working Sun";
            AddSnow(SnowType.Light, 250f);

            var bloom = volume.profile.GetSetting<Bloom>();
            bloom.active = false;
            SunsetMaterials();
        }

        public static void Titanic(RampFog fog, ColorGrading cgrade, PostProcessVolume volume)
        {
            fog.fogColorStart.value = new Color32(116, 153, 173, 4);
            fog.fogColorMid.value = new Color32(88, 130, 153, 40);
            fog.fogColorEnd.value = new Color32(77, 127, 152, 255);
            fog.skyboxStrength.value = 0f;
            // cgrade.colorFilter.value = new Color32(178, 255, 230, 255);
            // cgrade.colorFilter.overrideState = true;
            var sun = GameObject.Find("Directional Light (SUN)");
            var sunLight = Object.Instantiate(GameObject.Find("Directional Light (SUN)")).GetComponent<Light>();
            sun.SetActive(false);
            sun.name = "Shitty Not Working Sun";
            sunLight.name = "Directional Light (SUN)";
            sunLight.color = new Color32(255, 212, 153, 255);
            sunLight.intensity = 1.4f;
            sunLight.shadowStrength = 0.7f;
            var lightList = Object.FindObjectsOfType(typeof(Light)) as Light[];
            foreach (Light light in lightList)
            {
                var lightBase = light.gameObject;
                if (lightBase != null && !lightBase.name.Contains("Light (SUN)"))
                {
                    light.color = new Color32(255, 185, 0, 255);
                    light.intensity = 0.08f;
                    light.range = 4f;
                }
            }
            GameObject.Find("CAMERA PARTICLES: SnowParticles").SetActive(false);
            GameObject.Find("STATIC PARTICLES: Cave Entrance System").SetActive(false);
            // GameObject.Find("HOLDER: ShippingCenter").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("HOLDER: Stalactite").SetActive(false);
            GameObject.Find("HOLDER: Stalagmites").SetActive(false);

            var bloom = volume.profile.GetSetting<Bloom>();
            bloom.intensity.value = 0f;

            var yellow = new Color32(255, 185, 0, 255);

            var lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.color == yellow)
                {
                    if (light.GetComponent<FlickerLight>())
                    {
                        light.GetComponent<FlickerLight>().enabled = false;
                    }
                    light.range = 100f;
                    light.intensity = 3f;
                }
            }

            TitanicMaterials();
        }

        public static void TitanicMaterials()
        {
            var terrainMat = Main.rpdTitanicTerrainMat;
            var detailMat = Main.rpdTitanicDetailMat;
            var detailMat2 = Main.rpdTitanicDetailMat2;
            var water = Main.rpdTitanicWaterMat;

            if (terrainMat && detailMat && detailMat2 && water)
            {
                GameObject.Find("HOLDER: Skybox").transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = water;
                var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer mr in meshList)
                {
                    var meshBase = mr.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("Terrain") || meshBase.name.Contains("Snow") || meshBase.name.Contains("FW_FloatingIsland"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = terrainMat;
                            }
                        }
                        if (meshBase.name.Contains("Glacier") || meshBase.name.Contains("Stalagmite") || meshBase.name.Contains("Boulder") || meshBase.name.Contains("CavePillar") || meshBase.name.Contains("FW_Pillar"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = detailMat;
                            }
                        }
                        if (meshBase.name.Contains("GroundMesh") || meshBase.name.Contains("GroundStairs") || meshBase.name.Contains("VerticalPillar") || meshBase.name.Contains("Human") || meshBase.name.Contains("Barrier") || meshBase.name.Contains("FW_Ground") || meshBase.name.Contains("FW_WaterContainer") || meshBase.name.Contains("FW_Canister") || meshBase.name.Contains("ShippingContainer") || (meshBase.name.Contains("Pillar") && meshBase.transform.parent.name.Contains("VerticalPillarParent")) || meshBase.name.Contains("ArtifactFormulaHolderMesh") || meshBase.name.Contains("FW_Crate"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = detailMat2;
                            }
                        }
                        if (meshBase.name.Contains("HumanChainLink") || meshBase.name.Contains("Stalactite"))
                        {
                            meshBase.SetActive(false);
                        }
                        // too early to change shrine/enemy skins/detail
                    }
                }
            }
        }

        public static void DisableRallypointSnow()
        {
            if (!Config.Config.WeatherEffects.Value)
            {
                return;
            }
            var snowParticles = GameObject.Find("CAMERA PARTICLES: SnowParticles").gameObject;
            snowParticles.SetActive(false);
        }

        public static void SunsetMaterials()
        {
            var waterMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/sulfurpools/matSPWaterYellow.mat").WaitForCompletion();

            SwapVariants.SALogger.LogInfo("Initializing material, if this is null then guhhh... " + waterMat);

            if (waterMat)
            {
                GameObject.Find("HOLDER: Skybox").transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = waterMat;
            }
        }

        public static void NightMaterials()
        {
            var terrainMat = Addressables.LoadAssetAsync<Material>("RoR2/Base/arena/matArenaTerrainVerySnowy.mat").WaitForCompletion();
            var waterMat = Addressables.LoadAssetAsync<Material>("RoR2/Base/goldshores/matGSWater.mat").WaitForCompletion();
            var iceMat = Object.Instantiate(Addressables.LoadAssetAsync<Material>("RoR2/DLC1/snowyforest/matSFIce.mat").WaitForCompletion());
            iceMat.color = new Color32(242, 237, 254, 216);

            SwapVariants.SALogger.LogInfo("Initializing material, if this is null then guhhh... " + terrainMat);
            SwapVariants.SALogger.LogInfo("Initializing material, if this is null then guhhh... " + waterMat);
            SwapVariants.SALogger.LogInfo("Initializing material, if this is null then guhhh... " + iceMat);

            var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
            var water = GameObject.Find("HOLDER: Skybox").transform.GetChild(0);
            var ice = Object.Instantiate(water);
            ice.transform.position = new Vector3(-1260, -115, 0);
            if (terrainMat && waterMat && iceMat)
            {
                ice.GetComponent<MeshRenderer>().sharedMaterial = iceMat;
                water.GetComponent<MeshRenderer>().sharedMaterial = waterMat;
                foreach (MeshRenderer mr in meshList)
                {
                    var meshBase = mr.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.ToLower().Contains("halcyon")  || meshBase.name.ToLower().Contains("beacon"))
                        {
                            Debug.Log("erm... what the halcyonite");
                            continue;
                        }
                        if (meshBase.name.Contains("Terrain") || meshBase.name.Contains("Snow"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = terrainMat;
                            }
                        }
                        if (meshBase.name.Contains("Stalagmite") && meshBase.GetComponent<Light>() == null)
                        {
                            meshBase.AddComponent<Light>();
                        }
                    }
                }
            }
        }
    }
}