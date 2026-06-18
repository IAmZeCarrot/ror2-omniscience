using UnityEngine;
using RoR2;
using System.Collections.Generic;

namespace RoR2Omniscience
{
    public class OverlayRenderer : MonoBehaviour
    {
        private GUIStyle labelStyle;
        private GUIStyle highlightStyle;

        private void Start()
        {
            InitializeStyles();
        }

        private void InitializeStyles()
        {
            labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                alignment = TextAnchor.MiddleLeft
            };

            highlightStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 13,
                alignment = TextAnchor.MiddleLeft,
                fontStyle = FontStyle.Bold
            };
        }

        public void RenderDebugInfo(List<CharacterBody> allEntities, CharacterBody selectedTarget)
        {
            // Render debug text
            GUI.Label(new Rect(10, 10, 300, 30), $"Entities: {allEntities.Count}", labelStyle);
            GUI.Label(new Rect(10, 35, 300, 30), $"Selected: {(selectedTarget != null ? selectedTarget.name : "None")}", labelStyle);
            GUI.Label(new Rect(10, 60, 300, 30), $"FPS: {(int)(1f / Time.deltaTime)}", labelStyle);

            // Render entity list
            int yOffset = 100;
            foreach (var entity in allEntities)
            {
                if (entity == null) continue;

                Color color = GetEntityColor(entity, selectedTarget);
                string text = GetEntityLabel(entity);

                DrawColoredText(new Rect(10, yOffset, 300, 20), text, color);
                yOffset += 25;

                if (yOffset > Screen.height - 50) break;
            }
        }

        private Color GetEntityColor(CharacterBody entity, CharacterBody selectedTarget)
        {
            if (entity == selectedTarget) return Color.red;
            if (entity.isPlayerControlled) return Color.green;
            if (entity.teamComponent.teamIndex == TeamIndex.Player) return Color.cyan;
            return Color.white;
        }

        private string GetEntityLabel(CharacterBody entity)
        {
            float health = entity.healthComponent != null ? entity.healthComponent.health : 0;
            float maxHealth = entity.healthComponent != null ? entity.healthComponent.fullHealth : 1;
            float distance = Vector3.Distance(entity.transform.position, Camera.main.transform.position);

            return $"{entity.name} | HP: {health:F0}/{maxHealth:F0} | Dist: {distance:F1}m";
        }

        private void DrawColoredText(Rect position, string text, Color color)
        {
            GUI.color = color;
            GUI.Label(position, text, labelStyle);
            GUI.color = Color.white;
        }
    }
}
