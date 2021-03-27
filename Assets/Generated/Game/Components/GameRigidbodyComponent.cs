//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.Common.RigidbodyComponent rigidbody { get { return (SemoGames.Common.RigidbodyComponent)GetComponent(GameComponentsLookup.Rigidbody); } }
    public bool hasRigidbody { get { return HasComponent(GameComponentsLookup.Rigidbody); } }

    public void AddRigidbody(UnityEngine.Rigidbody2D newValue) {
        var index = GameComponentsLookup.Rigidbody;
        var component = (SemoGames.Common.RigidbodyComponent)CreateComponent(index, typeof(SemoGames.Common.RigidbodyComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRigidbody(UnityEngine.Rigidbody2D newValue) {
        var index = GameComponentsLookup.Rigidbody;
        var component = (SemoGames.Common.RigidbodyComponent)CreateComponent(index, typeof(SemoGames.Common.RigidbodyComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRigidbody() {
        RemoveComponent(GameComponentsLookup.Rigidbody);
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

    static Entitas.IMatcher<GameEntity> _matcherRigidbody;

    public static Entitas.IMatcher<GameEntity> Rigidbody {
        get {
            if (_matcherRigidbody == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Rigidbody);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRigidbody = matcher;
            }

            return _matcherRigidbody;
        }
    }
}