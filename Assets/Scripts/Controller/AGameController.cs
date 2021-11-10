using Entitas;
using Entitas.Unity;
using SemoGames.Extensions;
using UnityEngine;

namespace SemoGames.Controller
{
    public abstract class AGameController : MonoBehaviour
    {
        protected Systems updateSystems;
        protected Systems fixedUpdateSystems;
        protected Systems lateUpdateSystems;

        private GameEntity controllerEntity;

        public abstract GameControllerType GetGameControllerType();

        private void Awake()
        {
            updateSystems = new Feature("UpdateSystems");
            fixedUpdateSystems = new Feature("FixedUpdateSystems");
            lateUpdateSystems = new Feature("LateUpdateSystems");

            AfterAwake();
        }

        protected virtual void AfterAwake()
        {
            // for override
        }

        // Use this for initialization
        private void Start()
        {
            BeforeStart();
            EntityLink link = gameObject.GetEntityLink();
            IContext context = GetContext();
            if (link != null)
            {
                controllerEntity = (GameEntity)link.entity;
                controllerEntity.AddController(this);
            }
            else
            {
                controllerEntity = Contexts.sharedInstance.game.CreateEntity();
                controllerEntity.AddController(this);
                controllerEntity.AddView(gameObject);
                gameObject.Link(controllerEntity);
            }
            CreateSystems(context);

            updateSystems.Initialize();
            fixedUpdateSystems.Initialize();
            lateUpdateSystems.Initialize();

            AfterStart();
        }

        protected virtual void BeforeStart()
        {
            // for override
        }

        protected virtual void AfterStart()
        {
            // for override
        }

        private void OnDestroy()
        {
            //Teardown();
            controllerEntity.DestroyEntity();
        }

        public void RestartController()
        {
            updateSystems.ClearReactiveSystems();
            updateSystems.ActivateReactiveSystems();
            updateSystems.Cleanup();
            updateSystems.TearDown();

            fixedUpdateSystems.ClearReactiveSystems();
            fixedUpdateSystems.ActivateReactiveSystems();
            fixedUpdateSystems.Cleanup();
            fixedUpdateSystems.TearDown();

            lateUpdateSystems.ClearReactiveSystems();
            lateUpdateSystems.ActivateReactiveSystems();
            lateUpdateSystems.Cleanup();
            lateUpdateSystems.TearDown();

            updateSystems.Initialize();
            fixedUpdateSystems.Initialize();
            lateUpdateSystems.Initialize();
        }

        public void Teardown()
        {
            updateSystems.ClearReactiveSystems();
            updateSystems.DeactivateReactiveSystems();
            updateSystems.Cleanup();
            updateSystems.TearDown();

            fixedUpdateSystems.ClearReactiveSystems();
            fixedUpdateSystems.DeactivateReactiveSystems();
            fixedUpdateSystems.Cleanup();
            fixedUpdateSystems.TearDown();

            lateUpdateSystems.ClearReactiveSystems();
            lateUpdateSystems.DeactivateReactiveSystems();
            lateUpdateSystems.Cleanup();
            lateUpdateSystems.TearDown();
        }

        protected abstract IContext GetContext();


        private void CreateSystems(IContext context)
        {
            updateSystems.Add(CreateUpdateSystems(context));
            lateUpdateSystems.Add(CreateLateUpdateSystems(context));
            fixedUpdateSystems.Add(CreateFixedUpdateSystems(context));
        }

        protected abstract Systems CreateUpdateSystems(IContext context);

        protected abstract Systems CreateLateUpdateSystems(IContext context);

        protected abstract Systems CreateFixedUpdateSystems(IContext context);

        private void Update()
        {
            updateSystems.Execute();
        }

        private void FixedUpdate()
        {
            fixedUpdateSystems.Execute();
        }

        private void LateUpdate()
        {
            lateUpdateSystems.Execute();
            updateSystems.Cleanup();
            fixedUpdateSystems.Cleanup();
            lateUpdateSystems.Cleanup();
        }
    }
}