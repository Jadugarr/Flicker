﻿using System;
using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using SemoGames.Collectables;
using SemoGames.Configurations;
using SemoGames.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

namespace SemoGames.LevelSelection
{
    public class LevelSelectionItemBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
        IPointerClickHandler
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private TMP_Text _levelIndexText;

        [SerializeField] private Color _beatenLevelColor;

        [SerializeField] private Color _notBeatenLevelColor;

        [SerializeField] private GameObject _collectableTemplateObject;

        [SerializeField] private TMP_Text _fastestTimeTextfield;

        private int _levelIndex;

        private List<GameObject> _spawnedCollectableObjects = new List<GameObject>();
        private List<Tween> _activeTweens;

        public int LevelIndex
        {
            get => _levelIndex;
            set
            {
                _levelIndex = value;
                SpawnCollectableObjects();
                ShowFastestTime();
                _levelIndexText.text = _levelIndex.ToString();

                IGroup<SaveDataEntity> savedLevelEntities =
                    Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.Level,
                        SaveDataMatcher.LevelIndex));

                foreach (SaveDataEntity saveDataEntity in savedLevelEntities.GetEntities())
                {
                    if (saveDataEntity.levelIndex.Value == _levelIndex)
                    {
                        _spriteRenderer.color = _beatenLevelColor;
                        return;
                    }
                }

                _spriteRenderer.color = _notBeatenLevelColor;
            }
        }

        private void ShowFastestTime()
        {
            IGroup<SaveDataEntity> _saveDataGroup =
                Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.AllOf(SaveDataMatcher.LevelIndex,
                    SaveDataMatcher.GameTime));

            foreach (SaveDataEntity saveDataEntity in _saveDataGroup.GetEntities())
            {
                if (saveDataEntity.levelIndex.Value == _levelIndex)
                {
                    _fastestTimeTextfield.gameObject.SetActive(true);
                    _fastestTimeTextfield.text = FormattingUtils.FormatDuration(saveDataEntity.gameTime.Value);
                    return;
                }
            }

            _fastestTimeTextfield.gameObject.SetActive(false);
        }

        private void SpawnCollectableObjects()
        {
            IGroup<GameEntity> collectableInfoGroup =
                Contexts.sharedInstance.game.GetGroup(GameMatcher.AllOf(GameMatcher.CollectableInfo,
                    GameMatcher.CollectableId, GameMatcher.LevelIndex));
            IGroup<SaveDataEntity> savedCollectablesGroup =
                Contexts.sharedInstance.saveData.GetGroup(SaveDataMatcher.Collectable);

            foreach (GameEntity collectableInfoEntity in collectableInfoGroup.GetEntities())
            {
                if (collectableInfoEntity.levelIndex.Value == _levelIndex)
                {
                    GameObject spawned = Instantiate(_collectableTemplateObject, Vector3.zero,
                        Quaternion.Euler(0, 0, 0),
                        transform);
                    spawned.SetActive(true);
                    spawned.transform.SetAsFirstSibling();
                    _spawnedCollectableObjects.Add(spawned);

                    bool isFound = false;
                    foreach (SaveDataEntity saveDataEntity in savedCollectablesGroup.GetEntities())
                    {
                        if (saveDataEntity.collectableId.Value == collectableInfoEntity.collectableId.Value)
                        {
                            isFound = true;
                            spawned.GetComponentInChildren<SpriteRenderer>().material
                                .SetFloat(ShaderUtils.IsOutlineActive, 0);
                            break;
                        }
                    }

                    if (!isFound)
                    {
                        spawned.GetComponentInChildren<SpriteRenderer>().material
                            .SetFloat(ShaderUtils.IsOutlineActive, 1);
                    }
                }
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            EntityLink entityLink = gameObject.GetEntityLink();
            if (entityLink != null)
            {
                ((GameEntity)entityLink.entity).isSelected = true;
                CancelTweens();
                for (var index = 0; index < _spawnedCollectableObjects.Count; index++)
                {
                    GameObject collectable = _spawnedCollectableObjects[index];
                    Vector3 newPos = InstantiateInCircle(_spawnedCollectableObjects.Count, index);
                    DOTween.To(() => collectable.transform.position, value => collectable.transform.position = value,
                        newPos, 0.2f);
                }

                var position = transform.position;
                DOTween.To(() => _fastestTimeTextfield.gameObject.transform.position,
                    value => _fastestTimeTextfield.gameObject.transform.position = value, new Vector3(position.x, position.y - 0.6f, position.z),
                    0.2f);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            EntityLink entityLink = gameObject.GetEntityLink();
            if (entityLink != null)
            {
                ((GameEntity)entityLink.entity).isSelected = false;
                CancelTweens();
                for (var index = 0; index < _spawnedCollectableObjects.Count; index++)
                {
                    GameObject collectable = _spawnedCollectableObjects[index];
                    DOTween.To(() => collectable.transform.position, value => collectable.transform.position = value,
                        transform.position, 0.2f);
                }
                
                DOTween.To(() => _fastestTimeTextfield.gameObject.transform.position,
                    value => _fastestTimeTextfield.gameObject.transform.position = value, transform.position,
                    0.2f);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Contexts.sharedInstance.game.CreateEntity().AddLevelSelected(_levelIndex);
        }

        private void CancelTweens()
        {
            if (_activeTweens != null && _activeTweens.Count > 0)
            {
                foreach (Tween activeTween in _activeTweens)
                {
                    activeTween.Kill();
                }

                _activeTweens.Clear();
                _activeTweens = null;
            }
        }

        private Vector3 InstantiateInCircle(int howMany, int index)
        {
            float radius = 1.2f;
            float angle = ((index + 1) * Mathf.PI) / (howMany + 1) + Mathf.PI / 2;
            return transform.position +
                   (new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0)) * radius;
        }
    }
}