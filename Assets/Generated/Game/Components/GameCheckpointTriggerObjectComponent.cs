//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.CheckpointWall.CheckpointTriggerObjectComponent checkpointTriggerObject { get { return (SemoGames.CheckpointWall.CheckpointTriggerObjectComponent)GetComponent(GameComponentsLookup.CheckpointTriggerObject); } }
    public bool hasCheckpointTriggerObject { get { return HasComponent(GameComponentsLookup.CheckpointTriggerObject); } }

    public void AddCheckpointTriggerObject(UnityEngine.GameObject newValue) {
        var index = GameComponentsLookup.CheckpointTriggerObject;
        var component = (SemoGames.CheckpointWall.CheckpointTriggerObjectComponent)CreateComponent(index, typeof(SemoGames.CheckpointWall.CheckpointTriggerObjectComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCheckpointTriggerObject(UnityEngine.GameObject newValue) {
        var index = GameComponentsLookup.CheckpointTriggerObject;
        var component = (SemoGames.CheckpointWall.CheckpointTriggerObjectComponent)CreateComponent(index, typeof(SemoGames.CheckpointWall.CheckpointTriggerObjectComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCheckpointTriggerObject() {
        RemoveComponent(GameComponentsLookup.CheckpointTriggerObject);
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

    static Entitas.IMatcher<GameEntity> _matcherCheckpointTriggerObject;

    public static Entitas.IMatcher<GameEntity> CheckpointTriggerObject {
        get {
            if (_matcherCheckpointTriggerObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CheckpointTriggerObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCheckpointTriggerObject = matcher;
            }

            return _matcherCheckpointTriggerObject;
        }
    }
}