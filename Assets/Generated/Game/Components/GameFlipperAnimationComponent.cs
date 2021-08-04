//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly SemoGames.Effects.FlipperAnimationComponent flipperAnimationComponent = new SemoGames.Effects.FlipperAnimationComponent();

    public bool isFlipperAnimation {
        get { return HasComponent(GameComponentsLookup.FlipperAnimation); }
        set {
            if (value != isFlipperAnimation) {
                var index = GameComponentsLookup.FlipperAnimation;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : flipperAnimationComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherFlipperAnimation;

    public static Entitas.IMatcher<GameEntity> FlipperAnimation {
        get {
            if (_matcherFlipperAnimation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FlipperAnimation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFlipperAnimation = matcher;
            }

            return _matcherFlipperAnimation;
        }
    }
}