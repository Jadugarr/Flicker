//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.Bumpers.BumperCollisionVelocityComponent bumperCollisionVelocity { get { return (SemoGames.Bumpers.BumperCollisionVelocityComponent)GetComponent(GameComponentsLookup.BumperCollisionVelocity); } }
    public bool hasBumperCollisionVelocity { get { return HasComponent(GameComponentsLookup.BumperCollisionVelocity); } }

    public void AddBumperCollisionVelocity(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.BumperCollisionVelocity;
        var component = (SemoGames.Bumpers.BumperCollisionVelocityComponent)CreateComponent(index, typeof(SemoGames.Bumpers.BumperCollisionVelocityComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBumperCollisionVelocity(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.BumperCollisionVelocity;
        var component = (SemoGames.Bumpers.BumperCollisionVelocityComponent)CreateComponent(index, typeof(SemoGames.Bumpers.BumperCollisionVelocityComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBumperCollisionVelocity() {
        RemoveComponent(GameComponentsLookup.BumperCollisionVelocity);
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

    static Entitas.IMatcher<GameEntity> _matcherBumperCollisionVelocity;

    public static Entitas.IMatcher<GameEntity> BumperCollisionVelocity {
        get {
            if (_matcherBumperCollisionVelocity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BumperCollisionVelocity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBumperCollisionVelocity = matcher;
            }

            return _matcherBumperCollisionVelocity;
        }
    }
}