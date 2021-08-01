﻿using System;
using Cinemachine.Utility;
using Entitas.Unity;
using SemoGames.Configurations;
using SemoGames.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SemoGames.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
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
            //float angle = Vector2.Angle(playerEntity.velocity.Value.normalized.Abs(), contactPoint.normal.normalized.Abs());
            
            playerEntity.audioSource.Value.volume = Math.Min(playerEntity.velocity.Value.magnitude, 10f) / 10f;
            //playerEntity.audioSource.Value.pitch = Random.Range(0.95f, 1.05f);
            playerEntity.isPlaySound = true;
        }

        private void HandleImpactStars(ContactPoint2D contactPoint, GameEntity playerEntity)
        {
            float angle = Vector2.Angle(playerEntity.velocity.Value.normalized.Abs(), contactPoint.normal.normalized.Abs());
                if (playerEntity.velocity.Value.magnitude >= 2f && angle <= 45f)
                {
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