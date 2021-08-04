//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SemoGames.Common.AnimationComponent animation { get { return (SemoGames.Common.AnimationComponent)GetComponent(GameComponentsLookup.Animation); } }
    public bool hasAnimation { get { return HasComponent(GameComponentsLookup.Animation); } }

    public void AddAnimation(UnityEngine.Animation newValue) {
        var index = GameComponentsLookup.Animation;
        var component = (SemoGames.Common.AnimationComponent)CreateComponent(index, typeof(SemoGames.Common.AnimationComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnimation(UnityEngine.Animation newValue) {
        var index = GameComponentsLookup.Animation;
        var component = (SemoGames.Common.AnimationComponent)CreateComponent(index, typeof(SemoGames.Common.AnimationComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnimation() {
        RemoveComponent(GameComponentsLookup.Animation);
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

    static Entitas.IMatcher<GameEntity> _matcherAnimation;

    public static Entitas.IMatcher<GameEntity> Animation {
        get {
            if (_matcherAnimation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Animation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimation = matcher;
            }

            return _matcherAnimation;
        }
    }
}