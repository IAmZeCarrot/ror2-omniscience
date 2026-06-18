using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System.Linq;

namespace RoR2Omniscience
{
    public class OmniscienceManager : MonoBehaviour
    {
        // Subsystems
        private EntityDetector entityDetector;
        private OverlayRenderer overlayRenderer;
        private TargetSelector targetSelector;
        private AimAssistSystem aimAssist;
        private MenuSystem menuSystem;

        // State
        private bool overlayEnabled = true;
        private bool targetingEnabled = true;
        private bool aimAssistEnabled = false;
        private CharacterBody selectedTarget = null;

        private void Start()
        {
            OmnisciencePlugin.Log.LogInfo("OmniscienceManager starting...");

            // Initialize subsystems
            entityDetector = gameObject.AddComponent<EntityDetector>();
            overlayRenderer = gameObject.AddComponent<OverlayRenderer>();
            targetSelector = gameObject.AddComponent<TargetSelector>();
            aimAssist = gameObject.AddComponent<AimAssistSystem>();
            menuSystem = gameObject.AddComponent<MenuSystem>();

            OmnisciencePlugin.Log.LogInfo("All subsystems initialized");
        }

        private void Update()
        {
            // Poll for input
            HandleInput();

            // Update entity list
            List<CharacterBody> allEntities = entityDetector.GetAllEntities();
            List<CharacterBody> enemies = entityDetector.GetEnemies();
            List<CharacterBody> allies = entityDetector.GetAllies();

            // Select closest target if enabled
            if (targetingEnabled)
            {
                selectedTarget = targetSelector.GetClosestEnemy(enemies);
            }

            // Render overlay
            if (overlayEnabled)
            {
                overlayRenderer.RenderDebugInfo(allEntities, selectedTarget);
            }

            // Apply aim assist
            if (aimAssistEnabled && selectedTarget != null)
            {
                aimAssist.AdjustAim(selectedTarget);
            }
        }

        private void HandleInput()
        {
            // F1: Toggle overlay
            if (Input.GetKeyDown(KeyCode.F1))
            {
                overlayEnabled = !overlayEnabled;
                OmnisciencePlugin.Log.LogInfo($"Overlay toggled: {overlayEnabled}");
            }

            // F2: Toggle targeting
            if (Input.GetKeyDown(KeyCode.F2))
            {
                targetingEnabled = !targetingEnabled;
                OmnisciencePlugin.Log.LogInfo($"Targeting toggled: {targetingEnabled}");
            }

            // F3: Toggle aim assist
            if (Input.GetKeyDown(KeyCode.F3))
            {
                aimAssistEnabled = !aimAssistEnabled;
                OmnisciencePlugin.Log.LogInfo($"Aim assist toggled: {aimAssistEnabled}");
            }
        }
    }
}
