using UnityEngine;
using RoR2;
using System.Collections.Generic;
using System.Linq;

namespace RoR2Omniscience
{
    public class EntityDetector : MonoBehaviour
    {
        public List<CharacterBody> GetAllEntities()
        {
            return new List<CharacterBody>(CharacterBody.readOnlyInstancesList);
        }

        public List<CharacterBody> GetEnemies()
        {
            CharacterBody playerBody = GetPlayerBody();
            if (playerBody == null) return new List<CharacterBody>();

            TeamIndex playerTeam = playerBody.teamComponent.teamIndex;
            var enemies = CharacterBody.readOnlyInstancesList
                .Where(cb => cb.teamComponent != null && cb.teamComponent.teamIndex != playerTeam && cb.healthComponent != null)
                .ToList();

            return enemies;
        }

        public List<CharacterBody> GetAllies()
        {
            CharacterBody playerBody = GetPlayerBody();
            if (playerBody == null) return new List<CharacterBody>();

            TeamIndex playerTeam = playerBody.teamComponent.teamIndex;
            var allies = CharacterBody.readOnlyInstancesList
                .Where(cb => cb.teamComponent != null && cb.teamComponent.teamIndex == playerTeam && cb != playerBody && cb.healthComponent != null)
                .ToList();

            return allies;
        }

        public CharacterBody GetPlayerBody()
        {
            var players = CharacterBody.readOnlyInstancesList
                .Where(cb => cb.isPlayerControlled)
                .FirstOrDefault();
            return players;
        }

        public bool IsEntityVisible(CharacterBody entity)
        {
            if (entity == null || entity.healthComponent == null) return false;
            if (!entity.healthComponent.alive) return false;
            return true;
        }
    }
}
