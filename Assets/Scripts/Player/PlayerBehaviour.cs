using System;
using System.Threading.Tasks;
using Cinemachine.Utility;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private Animation _animation;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag(Tags.Ground))
            {
                GameEntity playerEntity = (GameEntity) gameObject.GetEntityLink().entity;
                ContactPoint2D contactPoint = other.GetContact(0);

                HandleSound(contactPoint, playerEntity);
                HandleImpactStars(contactPoint, playerEntity);
            }
        }

        private void HandleSound(ContactPoint2D contactPoint, GameEntity playerEntity)
        {
            float velocityThreshold =
                GameConfigurations.GameConstantsConfiguration.ImpactSoundFullVolumeVelocityThreshold;
            playerEntity.audioSource.Value.volume = Math.Min(playerEntity.velocity.Value.magnitude, velocityThreshold) /
                                                    velocityThreshold;
            playerEntity.audioSource.Value.clip = GameConfigurations.SoundReferencesConfiguration.HitGroundSound;
            playerEntity.isPlaySound = true;
        }

        private async void HandleImpactStars(ContactPoint2D contactPoint, GameEntity playerEntity)
        {
            float angle = Vector2.Angle(playerEntity.velocity.Value.normalized.Abs(),
                contactPoint.normal.normalized.Abs());
            float angleThreshold = GameConfigurations.GameConstantsConfiguration.ImpatStarCollisionAngleThreshold;
            float velocityThreshold = GameConfigurations.GameConstantsConfiguration.ImpactStarEffectVelocityThreshold;
            if (playerEntity.velocity.Value.magnitude >= velocityThreshold && angle <= angleThreshold)
            {
                GameEntity impactStarEntity = Contexts.sharedInstance.game.CreateEntity();
                GameEntity impactStarEntity2 = Contexts.sharedInstance.game.CreateEntity();
                impactStarEntity2.isImpactStar = true;
                impactStarEntity.isImpactStar = true;
                Task<bool> impactStar1Task = AssetLoaderUtils.InstantiateAssetAsyncTask(GameConfigurations.AssetReferenceConfiguration.ImpactStarReference, impactStarEntity, contactPoint.point, Quaternion.identity);
                Task<bool> impactStar2Task = AssetLoaderUtils.InstantiateAssetAsyncTask(GameConfigurations.AssetReferenceConfiguration.ImpactStarReference, impactStarEntity2, contactPoint.point, Quaternion.identity);
                
                if (await impactStar1Task)
                {
                    GameObject impactStarObject = impactStarEntity.view.Value;
                    impactStarObject.transform.Rotate(0, 0, Vector2.SignedAngle(Vector2.up, contactPoint.normal));
                    Animation impactAnimation = impactStarObject.GetComponentInChildren<Animation>();
                    impactStarEntity.AddAnimation(impactAnimation);
                }

                if (await impactStar2Task)
                {
                    GameObject impactStarObject2 = impactStarEntity2.view.Value;
                    impactStarObject2.transform.Rotate(180 * contactPoint.normal.x, 180 * contactPoint.normal.y,
                        Vector2.SignedAngle(Vector2.up, contactPoint.normal));
                    Animation impactAnimation2 = impactStarObject2.GetComponentInChildren<Animation>();
                    impactStarEntity2.AddAnimation(impactAnimation2);
                }
            }
        }

        public void DissolveFinished()
        {
            _animation.Stop();
            GameEntity playerEntity = (GameEntity) gameObject.GetEntityLink().entity;
            playerEntity.isMoveToLastCheckpoint = true;
        }

        public void ReverseDissolveFinished()
        {
            _animation.Stop();
            GameEntity playerEntity = (GameEntity) gameObject.GetEntityLink().entity;
            playerEntity.isStopSimulation = false;
            playerEntity.isDead = false;
        }

        public void ActivateDissolve()
        {
            GameEntity playerEntity = (GameEntity) gameObject.GetEntityLink().entity;
            playerEntity.isDissolve = true;
        }

        public void DeactivateDissolve()
        {
            GameEntity playerEntity = (GameEntity) gameObject.GetEntityLink().entity;
            playerEntity.isDissolve = false;
        }
    }
}