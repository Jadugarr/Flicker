using System;
using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using TMPro;
using UnityEngine;
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

        private int _levelIndex;

        private List<GameObject> _spawnedCollectableObjects = new List<GameObject>(3);
        private List<Tween> _activeTweens;

        public int LevelIndex
        {
            get => _levelIndex;
            set
            {
                _levelIndex = value;
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

        private void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject spawned = Instantiate(_collectableTemplateObject, Vector3.zero, Quaternion.Euler(0, 0, 0),
                    transform);
                spawned.SetActive(true);
                spawned.transform.SetAsFirstSibling();
                _spawnedCollectableObjects.Add(spawned);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            EntityLink entityLink = gameObject.GetEntityLink();
            if (entityLink != null)
            {
                ((GameEntity) entityLink.entity).isSelected = true;
                CancelTweens();
                for (var index = 0; index < _spawnedCollectableObjects.Count; index++)
                {
                    GameObject collectable = _spawnedCollectableObjects[index];
                    Vector3 newPos = InstantiateInCircle(_spawnedCollectableObjects.Count, index);
                    DOTween.To(() => collectable.transform.position, value => collectable.transform.position = value,
                        newPos, 0.2f);
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            EntityLink entityLink = gameObject.GetEntityLink();
            if (entityLink != null)
            {
                ((GameEntity) entityLink.entity).isSelected = false;
                CancelTweens();
                for (var index = 0; index < _spawnedCollectableObjects.Count; index++)
                {
                    GameObject collectable = _spawnedCollectableObjects[index];
                    DOTween.To(() => collectable.transform.position, value => collectable.transform.position = value,
                        transform.position, 0.2f);
                }
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
            float radius = 1;
            float angle = ((index + 1) * Mathf.PI) / (howMany + 1) + Mathf.PI / 2;
            return transform.position +
                   (new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0)) * radius;
        }
    }
}