using System;
using Entitas;

namespace SemoGames.GameTransition
{
    public class TransitionSequence : IDisposable
    {
        public event Action SequenceCompleted;
        
        private int _currentComponentIndex;
        private int _currentSequenceIndex;
        private TransitionComponentData[] _transitionComponents;
        private IEntity _transitionEntity;

        public TransitionSequence(TransitionComponentData[] transitionComponents, IEntity transitionEntity)
        {
            _transitionComponents = transitionComponents;
            _transitionEntity = transitionEntity;
            
            _transitionEntity.OnComponentRemoved += OnComponentRemoved;
            
            ProcessNextInSequence();
        }

        public void Dispose()
        {
            _transitionEntity.OnComponentRemoved -= OnComponentRemoved;
        }

        private void ProcessNextInSequence()
        {
            if (_transitionComponents.Length > _currentSequenceIndex)
            {
                TransitionComponentData nextComponent = _transitionComponents[_currentSequenceIndex];
                _currentComponentIndex = nextComponent.Index;
                _currentSequenceIndex++;
                _transitionEntity.AddComponent(nextComponent.Index, nextComponent.TransitionComponent);
            }
            else
            {
                EndSequence();
            }
        }

        private void EndSequence()
        {
            SequenceCompleted?.Invoke();
            Dispose();
        }

        private void OnComponentRemoved(IEntity entity, int index, IComponent component)
        {
            if (index == _currentComponentIndex)
            {
                ProcessNextInSequence();
            }
        }
    }
}