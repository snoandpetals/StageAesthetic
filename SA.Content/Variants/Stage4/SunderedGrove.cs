﻿using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions.Must;
using UnityEngine.Experimental.AI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.XR;
using Object = UnityEngine.Object;

namespace StageAesthetic.Variants.Stage4
{
    internal class SunderedGrove
    {
        public static void Vanilla()
        {
            VanillaFoliage();
        }

        public static void Jade(RampFog fog, ColorGrading cgrade)
        {
            fog.fogColorStart.value = new Color32(70, 90, 84, 0);
            fog.fogColorMid.value = new Color32(74, 99, 105, 100);
            fog.fogColorEnd.value = new Color32(77, 113, 85, 150);
            fog.skyboxStrength.value = 0f;
            var lightBase = GameObject.Find("HOLDER: Weather Set 1").transform;
            var sunTransform = lightBase.Find("Directional Light (SUN)");
            Light sunLight = sunTransform.gameObject.GetComponent<Light>();
            sunLight.color = new Color32(152, 255, 255, 255);
            sunLight.intensity = 2f;
            sunTransform.localEulerAngles = new Vector3(60, 15, -4);
            VanillaFoliage();
        }

        public static void Sunny(RampFog fog, ColorGrading cgrade)
        {
            fog.fogColorStart.value = new Color32(128, 121, 99, 13);
            fog.fogColorMid.value = new Color32(106, 141, 154, 60);
            fog.fogColorEnd.value = new Color32(104, 150, 199, 150);
            fog.fogZero.value = -0.058f;
            fog.fogPower.value = 1.2f;
            fog.fogIntensity.value = 0.937f;
            fog.skyboxStrength.value = 0.26f;
            var lightBase = GameObject.Find("HOLDER: Weather Set 1").transform;
            var sunTransform = lightBase.Find("Directional Light (SUN)");
            Light sunLight = sunTransform.gameObject.GetComponent<Light>();
            sunLight.color = new Color32(255, 225, 181, 255);
            sunLight.intensity = 1.8f;
            sunTransform.localEulerAngles = new Vector3(60, 15, -4);
            VanillaFoliage();
        }

        public static void Overcast(RampFog fog, ColorGrading cgrade)
        {
            var lightBase = GameObject.Find("HOLDER: Weather Set 1").transform;
            var sunTransform = lightBase.Find("Directional Light (SUN)");
            Light sunLight = sunTransform.gameObject.GetComponent<Light>();
            sunLight.color = new Color32(77, 188, 175, 255);
            sunLight.intensity = 1.5f;
            AddRain(RainType.Typhoon);
            fog.fogColorEnd.value = new Color(0.3272f, 0.3711f, 0.4057f, 0.95f);
            fog.fogColorMid.value = new Color(0.2864f, 0.2667f, 0.3216f, 0.55f);
            fog.fogColorStart.value = new Color(0.2471f, 0.2471f, 0.2471f, 0.05f);
            fog.fogPower.value = 2f;
            fog.fogZero.value = -0.02f;
            fog.fogOne.value = 0.025f;
            fog.skyboxStrength.value = 0f;
            fog.fogIntensity.value = 1f;

            // cgrade.colorFilter.value = new Color32(148, 206, 183, 255);
            //cgrade.colorFilter.overrideState = true;

            var rain = lightBase.Find("CameraRelative").gameObject;
            rain.SetActive(false);

            VanillaFoliage();
        }

        public static void Abandoned(RampFog fog, PostProcessProfile ppProfile)
        {
            AddSand(SandType.Moderate);
            var terrainMat = Main.groveAbandonedTerrainMat;
            var terrainMat2 = Main.groveAbandonedTerrainMat2;
            var detailMat = Main.groveAbandonedDetailMat;
            var water = Main.groveAbandonedWaterMat;
            var shroomMat = Main.groveAbandonedDetailMat2;

            RampFog rampFog = ppProfile.GetSetting<RampFog>();

            fog.fogColorStart.value = new Color(0.49f, 0.363f, 0.374f, 0f);
            fog.fogColorMid.value = new Color(0.58f, 0.486f, 0.331f, 0.25f);
            fog.fogColorEnd.value = new Color(0.77f, 0.839f, 0.482f, 0.5f);
            fog.fogZero.value = rampFog.fogZero.value;
            fog.fogIntensity.value = rampFog.fogIntensity.value;
            fog.fogPower.value = rampFog.fogPower.value;
            fog.fogOne.value = rampFog.fogOne.value;
            fog.skyboxStrength.value = 0.02f;

            var c = GameObject.Find("Cloud Floor").transform;
            if (terrainMat && terrainMat2 && detailMat && water && shroomMat)
            {
                c.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = water;
                var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                var seshList = Object.FindObjectsOfType(typeof(SkinnedMeshRenderer)) as SkinnedMeshRenderer[];
                foreach (SkinnedMeshRenderer smr in seshList)
                {
                    var meshBase = smr.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.ToLower().Contains("halcyon"))
                        {
                            Debug.Log("erm... what the halcyonite");
                            continue;
                        }
                        if (meshBase.name.Contains("BounceStem"))
                        {
                            switch (smr.sharedMaterial)
                            {
                                case null:
                                    try { smr.sharedMaterial = water; } catch (Exception e) { SwapVariants.SALogger.LogWarning(e.Message + "\n" + e.StackTrace); };
                                    break;

                                default:
                                    smr.sharedMaterial = water;
                                    break;
                            }
                        }
                    }
                }
                foreach (MeshRenderer mr in meshList)
                {
                    var meshBase = mr.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.ToLower().Contains("halcyon"))
                        {
                            Debug.Log("erm... what the halcyonite");
                            continue;
                        }
                        if (meshBase.name.Contains("Terrain") || meshBase.name.Contains("Gianticus") || meshBase.name.Contains("Tree Big Bottom") || meshBase.name.Contains("Tree D") || meshBase.name.Contains("Wall") || meshBase.name.Contains("RJRoot") || meshBase.name.Contains("RJShroomShelf"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = terrainMat;
                            }
                        }
                        if (meshBase.name.Contains("RJTriangle") || meshBase.name.Contains("BbRuinArch") || meshBase.name.Contains("RJShroomBig"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = terrainMat2;
                            }
                        }
                        if (meshBase.name.Contains("Rock") || meshBase.name.Contains("Boulder") || meshBase.name.Contains("Pebble") || meshBase.name.Contains("Root Bridge") || meshBase.name.Contains("Vine Tree"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = detailMat;
                            }
                        }

                        if (meshBase.name.Contains("Moss Cover") || meshBase.name.Contains("RJShroomShelf") || meshBase.name.Contains("RJShroomBig") || meshBase.name.Contains("RJShroomSmall") || meshBase.name.Contains("RJMossPatch"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = shroomMat;
                            }
                        }

                        if (meshBase.name.Contains("RJTwistedTreeBig"))
                        {
                            if (mr.sharedMaterial)
                            {
                                mr.sharedMaterial = terrainMat;
                            }
                        }
                    }
                }
            }

            var lightList = Object.FindObjectsOfType(typeof(Light)) as Light[];
            foreach (Light l in lightList)
            {
                var meshBase = l.gameObject;
                if (meshBase != null)
                {
                    if (meshBase.name.ToLower().Contains("halcyon"))
                    {
                        Debug.Log("erm... what the halcyonite");
                        continue;
                    }
                    l.color = new Color32(255, 131, 117, 255);
                    l.range = 15;
                    l.intensity = 1f;
                }
            }
            /*
            c.GetChild(0).localScale = new Vector3(2000, 2000, 2000);
            c.GetChild(0).localPosition = new Vector3(0, 0, 0);
            c.GetChild(1).gameObject.SetActive(false);
            c.GetChild(2).gameObject.SetActive(false);
            c.GetChild(3).gameObject.SetActive(false);
            c.GetChild(4).gameObject.SetActive(false);
            GameObject.Find("GROUP: DistantTreeFoliage").SetActive(false);
            */
            SandyFoliage();
        }

        public static void VanillaFoliage()
        {
            var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
            foreach (MeshRenderer mr in meshList)
            {
                var meshBase = mr.gameObject;
                if (meshBase != null)
                {
                    if (meshBase.name.Contains("RJShroomFoliage_") || meshBase.name.Contains("RJTreeBigFoliage_"))
                    {
                        mr.sharedMaterial.color = new Color32(255, 255, 255, 255);
                    }
                    if (meshBase.name.Contains("RJMossFoliage_"))
                    {
                        mr.sharedMaterial.color = new Color32(122, 215, 221, 255);
                    }
                    if (meshBase.name.Contains("RJTowerTreeFoliage_"))
                    {
                        var color = new Color32(171, 171, 171, 255);
                        var sharedMaterials = mr.sharedMaterials;
                        for (int i = 0; i < sharedMaterials.Length; i++)
                        {
                            sharedMaterials[i].color = color;
                        }
                        mr.sharedMaterials = sharedMaterials;
                    }
                    if (meshBase.name.Contains("RJHangingMoss_"))
                    {
                        mr.sharedMaterial.color = new Color32(105, 130, 110, 255);
                    }
                    if (meshBase.name.Contains("spmFern1_"))
                    {
                        mr.sharedMaterial.color = new Color32(255, 255, 255, 255);
                    }
                    if (meshBase.name.Contains("spmRJgrass1_"))
                    {
                        mr.sharedMaterial.color = new Color32(190, 164, 179, 255);
                    }
                    if (meshBase.name.Contains("spmRJgrass2_"))
                    {
                        mr.sharedMaterial.color = new Color32(207, 207, 207, 255);
                    }
                }
            }
        }

        public static void SandyFoliage()
        {
            var meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
            foreach (MeshRenderer mr in meshList)
            {
                var meshBase = mr.gameObject;
                if (meshBase != null)
                {
                    if (meshBase.name.ToLower().Contains("halcyon"))
                    {
                        Debug.Log("erm... what the halcyonite");
                        continue;
                    }
                    if (meshBase.name.Contains("RJShroomFoliage_") || meshBase.name.Contains("RJTreeBigFoliage_"))
                    {
                        mr.sharedMaterial.color = new Color32(0, 0, 0, 255);
                    }
                    if (meshBase.name.Contains("RJMossFoliage_"))
                    {
                        mr.sharedMaterial.color = new Color32(255, 149, 0, 255);
                    }
                    if (meshBase.name.Contains("RJTowerTreeFoliage_"))
                    {
                        var color = new Color32(255, 149, 0, 255);
                        var sharedMaterials = mr.sharedMaterials;
                        for (int i = 0; i < sharedMaterials.Length; i++)
                        {
                            sharedMaterials[i].color = color;
                        }
                        mr.sharedMaterials = sharedMaterials;
                    }
                    if (meshBase.name.Contains("RJHangingMoss_"))
                    {
                        mr.sharedMaterial.color = new Color32(0, 0, 0, 102);
                    }
                    if (meshBase.name.Contains("spmFern1_"))
                    {
                        mr.sharedMaterial.color = new Color32(255, 101, 58, 86);
                    }
                    if (meshBase.name.Contains("spmRJgrass1_"))
                    {
                        mr.sharedMaterial.color = new Color32(255, 37, 0, 255);
                    }
                    if (meshBase.name.Contains("spmRJgrass2_"))
                    {
                        mr.sharedMaterial.color = new Color32(0, 0, 0, 0);
                    }
                }
            }
        }
    }
}