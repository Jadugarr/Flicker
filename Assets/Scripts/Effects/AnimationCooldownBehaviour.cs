using UnityEngine;

namespace SemoGames.Effects
{
    public class AnimationCooldownBehaviour : MonoBehaviour
    {
        [SerializeField] private float cooldown;
        [SerializeField] private Animation tutorialAnimation;

        private float currentCooldownTime = 0f;
        private bool isInCooldown = false;
        
        private void Update()
        {
            if (isInCooldown)
            {
                currentCooldownTime += Time.deltaTime;
                if (currentCooldownTime >= cooldown)
                {
                    isInCooldown = false;
                    tutorialAnimation.Play();
                }
            }
        }

        public void AnimationFinished()
        {
            isInCooldown = true;
            currentCooldownTime = 0f;
        }
    }
}