using UnityEngine;
using RoR2;

namespace RoR2Omniscience
{
    public class AimAssistSystem : MonoBehaviour
    {
        [SerializeField]
        private float smoothingSpeed = 5f;

        [SerializeField]
        private float snapDistance = 0.1f;

        public void AdjustAim(CharacterBody target)
        {
            if (target == null) return;

            CharacterBody playerBody = GetComponent<OmniscienceManager>() != null ? 
                GetComponent<EntityDetector>().GetPlayerBody() : null;
            
            if (playerBody == null) return;

            InputBankTest inputBank = playerBody.inputBank;
            if (inputBank == null) return;

            // Get direction to target
            Vector3 targetPos = target.corePosition;
            Vector3 playerPos = playerBody.corePosition;
            Vector3 directionToTarget = (targetPos - playerPos).normalized;

            // Smooth interpolation of aim
            Vector3 currentAim = inputBank.aimDirection;
            Vector3 newAim = Vector3.Lerp(currentAim, directionToTarget, Time.deltaTime * smoothingSpeed);

            // Apply adjusted aim
            inputBank.aimDirection = newAim.normalized;
        }
    }
}
