using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Entitas;
using UnityEngine;

namespace SemoGames.LevelSelection
{
    public class MoveLevelSelectionPlayerSystem : ReactiveSystem<GameEntity>, IInitializeSystem, ITearDownSystem
    {
        private IGroup<GameEntity> _levelSelectionPlayerGroup;
        private IGroup<GameEntity> _levelSelectionItemGroup;
        private IGroup<GameEntity> _selectedLevelItemGroup;
        
        private float _currentT = 0f;
        private Vector3 _p0;
        private Vector3 _p1;
        private Vector3 _p2;
        private Vector3 _p3;
        private GameEntity _playerEntity;
        private TweenerCore<float, float, FloatOptions> _currentTween;
        
        public MoveLevelSelectionPlayerSystem(IContext<GameEntity> context) : base(context)
        {
            _levelSelectionPlayerGroup = context.GetGroup(GameMatcher.LevelSelectionPlayer);
            _levelSelectionItemGroup = context.GetGroup(GameMatcher.LevelSelectionItemBehaviour);
            _selectedLevelItemGroup =
                context.GetGroup(GameMatcher.AllOf(GameMatcher.LevelSelectionItemBehaviour, GameMatcher.Selected));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(new TriggerOnEvent<GameEntity>(GameMatcher.Selected, GroupEvent.Added),
                new TriggerOnEvent<GameEntity>(GameMatcher.LevelSelectionPlayer, GroupEvent.Added),
                new TriggerOnEvent<GameEntity>(GameMatcher.LevelSelectionItemBehaviour, GroupEvent.Added));
        }

        protected override bool Filter(GameEntity entity)
        {
            return _levelSelectionItemGroup.count > 0 && _levelSelectionPlayerGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            AdjustPlayerPosition();
        }

        public void Initialize()
        {
            if (Filter(null))
            {
                AdjustPlayerPosition();
            }
        }

        private void AdjustPlayerPosition()
        {
            Vector3 firstLevelItemPosition = _levelSelectionItemGroup.GetEntities()[0].position.Value;
            _playerEntity = _levelSelectionPlayerGroup.GetSingleEntity();
            Vector3 newPosition = new Vector3(firstLevelItemPosition.x,
                firstLevelItemPosition.y + 1f, firstLevelItemPosition.z);
            
            foreach (GameEntity levelItemEntity in _selectedLevelItemGroup.GetEntities())
            {
                newPosition.x = levelItemEntity.position.Value.x;
                newPosition.y = levelItemEntity.position.Value.y + 1;
                newPosition.z = levelItemEntity.position.Value.z;
            }

            _currentT = 0f;
            CreateNewTween(_playerEntity.position.Value, newPosition);
        }

        private void CreateNewTween(Vector3 startPoint, Vector3 endPoint)
        {
            _p0 = startPoint;
            _p1 = new Vector3(_p0.x, _p0.y + 3f, _p0.z);
            _p3 = endPoint;
            _p2 = new Vector3(_p3.x, _p3.y + 3f, _p3.z);

            if (_currentTween != null)
            {
                _currentTween.Kill();
            }
            
            _currentTween = DOTween.To(() => _currentT, value =>
            {
                _currentT = value;
                TweenHelper(value);
            }, 1f, 2f);
        }

        private void TweenHelper(float tParam)
        {
            Vector3 objectPosition = Mathf.Pow(1 - tParam, 3) * _p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * _p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * _p2 + Mathf.Pow(tParam, 3) * _p3;
            _playerEntity.view.Value.transform.position = objectPosition;
        }

        public void TearDown()
        {
            if (_currentTween != null)
            {
                _currentTween.Kill();
            }
        }
    }
}