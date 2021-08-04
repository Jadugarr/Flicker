//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SemoGames.Effects.ImpactStar impactStarComponent = new SemoGames.Effects.ImpactStar();

    public bool isImpactStar {
        get { return HasComponent(GameComponentsLookup.ImpactStar); }
        set {
            if (value != isImpactStar) {
                var index = GameComponentsLookup.ImpactStar;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : impactStarComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherImpactStar;

    public static Entitas.IMatcher<GameEntity> ImpactStar {
        get {
            if (_matcherImpactStar == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ImpactStar);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherImpactStar = matcher;
            }

            return _matcherImpactStar;
        }
    }
}