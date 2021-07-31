using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;

namespace SemoGames.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag(Tags.Ground))
            {
                GameEntity playerEntity = (GameEntity) gameObject.GetEntityLink().entity;
                playerEntity.isPlaySound = true;

                
                ContactPoint2D contactPoint = other.GetContact(0);
                GameEntity impactStarEntity = Contexts.sharedInstance.game.CreateEntity();
                impactStarEntity.isImpactStar = true;
                AssetLoaderUtils.LoadAssetAsync(GameConfigurations.AssetReferenceConfiguration.ImpactStarReference, impactStarEntity,
                    resultObject =>
                    {
                        GameObject impactStarObject = Instantiate(resultObject, contactPoint.point, Quaternion.identity);
                        impactStarObject.transform.Rotate(0, 0,Vector2.SignedAngle(Vector2.up, contactPoint.normal));
                        Animation impactAnimation = impactStarObject.GetComponentInChildren<Animation>();
                        impactStarObject.gameObject.Link(impactStarEntity);
                        impactStarEntity.AddAnimation(impactAnimation);
                        impactStarEntity.AddView(impactStarObject);
                    });
                
                GameEntity impactStarEntity2 = Contexts.sharedInstance.game.CreateEntity();
                impactStarEntity2.isImpactStar = true;
                AssetLoaderUtils.LoadAssetAsync(GameConfigurations.AssetReferenceConfiguration.ImpactStarReference, impactStarEntity2,
                    resultObject =>
                    {
                        GameObject impactStarObject = Instantiate(resultObject, contactPoint.point, Quaternion.identity);
                        impactStarObject.transform.Rotate(180 * contactPoint.normal.x, 180 * contactPoint.normal.y,Vector2.SignedAngle(Vector2.up, contactPoint.normal));
                        Animation impactAnimation = impactStarObject.GetComponentInChildren<Animation>();
                        impactStarObject.gameObject.Link(impactStarEntity2);
                        impactStarEntity2.AddAnimation(impactAnimation);
                        impactStarEntity2.AddView(impactStarObject);
                    });
            }
        }
    }
}