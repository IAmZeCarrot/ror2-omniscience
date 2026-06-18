using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System.Linq;

namespace RoR2Omniscience
{
    public class TargetSelector : MonoBehaviour
    {
        private EntityDetector entityDetector;

        private void Start()
        {
            entityDetector = GetComponent<EntityDetector>();
        }

        public CharacterBody GetClosestEnemy(List<CharacterBody> enemies)
        {
            CharacterBody playerBody = entityDetector.GetPlayerBody();
            if (playerBody == null) return null;
            if (enemies.Count == 0) return null;

            Vector3 playerPos = playerBody.transform.position;

            // Filter for alive enemies
            var aliveEnemies = enemies.Where(e => e.healthComponent != null && e.healthComponent.alive).ToList();
            if (aliveEnemies.Count == 0) return null;

            // Find closest
            CharacterBody closest = aliveEnemies[0];
            float closestDist = Vector3.Distance(playerPos, closest.transform.position);

            foreach (var enemy in aliveEnemies)
            {
                float dist = Vector3.Distance(playerPos, enemy.transform.position);
                if (dist < closestDist)
                {
                    closest = enemy;
                    closestDist = dist;
                }
            }

            return closest;
        }

        public List<CharacterBody> SortByDistance(List<CharacterBody> entities)
        {
            CharacterBody playerBody = entityDetector.GetPlayerBody();
            if (playerBody == null) return entities;

            Vector3 playerPos = playerBody.transform.position;
            return entities.OrderBy(e => Vector3.Distance(playerPos, e.transform.position)).ToList();
        }
    }
}
