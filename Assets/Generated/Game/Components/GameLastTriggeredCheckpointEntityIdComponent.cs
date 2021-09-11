//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity lastTriggeredCheckpointEntityIdEntity { get { return GetGroup(GameMatcher.LastTriggeredCheckpointEntityId).GetSingleEntity(); } }
    public SemoGames.CheckpointWall.LastTriggeredCheckpointEntityIdComponent lastTriggeredCheckpointEntityId { get { return lastTriggeredCheckpointEntityIdEntity.lastTriggeredCheckpointEntityId; } }
    public bool hasLastTriggeredCheckpointEntityId { get { return lastTriggeredCheckpointEntityIdEntity != null; } }

    public GameEntity SetLastTriggeredCheckpointEntityId(int newValue) {
        if (hasLastTriggeredCheckpointEntityId) {
            throw new Entitas.EntitasException("Could not set LastTriggeredCheckpointEntityId!\n" + this + " already has an entity with SemoGames.CheckpointWall.LastTriggeredCheckpointEntityIdComponent!",
                "You should check if the context already has a lastTriggeredCheckpointEntityIdEntity before setting it or use context.ReplaceLastTriggeredCheckpointEntityId().");
        }
        var entity = CreateEntity();
        entity.AddLastTriggeredCheckpointEntityId(newValue);
        return entity;
    }

    public void ReplaceLastTriggeredCheckpointEntityId(int newValue) {
        var entity = lastTriggeredCheckpointEntityIdEntity;
        if (entity == null) {
            entity = SetLastTriggeredCheckpointEntityId(newValue);
        } else {
            entity.ReplaceLastTriggeredCheckpointEntityId(newValue);
        }
    }

    public void RemoveLastTriggeredCheckpointEntityId() {
        lastTriggeredCheckpointEntityIdEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.CheckpointWall.LastTriggeredCheckpointEntityIdComponent lastTriggeredCheckpointEntityId { get { return (SemoGames.CheckpointWall.LastTriggeredCheckpointEntityIdComponent)GetComponent(GameComponentsLookup.LastTriggeredCheckpointEntityId); } }
    public bool hasLastTriggeredCheckpointEntityId { get { return HasComponent(GameComponentsLookup.LastTriggeredCheckpointEntityId); } }

    public void AddLastTriggeredCheckpointEntityId(int newValue) {
        var index = GameComponentsLookup.LastTriggeredCheckpointEntityId;
        var component = (SemoGames.CheckpointWall.LastTriggeredCheckpointEntityIdComponent)CreateComponent(index, typeof(SemoGames.CheckpointWall.LastTriggeredCheckpointEntityIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLastTriggeredCheckpointEntityId(int newValue) {
        var index = GameComponentsLookup.LastTriggeredCheckpointEntityId;
        var component = (SemoGames.CheckpointWall.LastTriggeredCheckpointEntityIdComponent)CreateComponent(index, typeof(SemoGames.CheckpointWall.LastTriggeredCheckpointEntityIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLastTriggeredCheckpointEntityId() {
        RemoveComponent(GameComponentsLookup.LastTriggeredCheckpointEntityId);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLastTriggeredCheckpointEntityId;

    public static Entitas.IMatcher<GameEntity> LastTriggeredCheckpointEntityId {
        get {
            if (_matcherLastTriggeredCheckpointEntityId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LastTriggeredCheckpointEntityId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLastTriggeredCheckpointEntityId = matcher;
            }

            return _matcherLastTriggeredCheckpointEntityId;
        }
    }
}
