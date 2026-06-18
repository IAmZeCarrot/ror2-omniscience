using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using HarmonyLib;

namespace RoR2Omniscience
{
    [BepInPlugin(GUID, ModName, Version)]
    public class OmnisciencePlugin : BaseUnityPlugin
    {
        public const string GUID = "com.IAmZeCarrot.RoR2Omniscience";
        public const string ModName = "RoR2 Omniscience";
        public const string Version = "1.0.0";

        public static ManualLogSource Log { get; private set; }
        public static OmniscienceManager Manager { get; private set; }

        private void Awake()
        {
            Log = Logger;
            Log.LogInfo($"Loading {ModName} v{Version}");

            // Create manager GameObject
            GameObject managerObj = new GameObject("OmniscienceManager");
            DontDestroyOnLoad(managerObj);
            Manager = managerObj.AddComponent<OmniscienceManager>();

            // Apply Harmony patches
            Harmony harmony = new Harmony(GUID);
            harmony.PatchAll();

            Log.LogInfo($"{ModName} loaded successfully!");
        }
    }
}
