//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity collectedAmountEntity { get { return GetGroup(GameMatcher.CollectedAmount).GetSingleEntity(); } }
    public SemoGames.Collectables.CollectedAmountComponent collectedAmount { get { return collectedAmountEntity.collectedAmount; } }
    public bool hasCollectedAmount { get { return collectedAmountEntity != null; } }

    public GameEntity SetCollectedAmount(int newValue) {
        if (hasCollectedAmount) {
            throw new Entitas.EntitasException("Could not set CollectedAmount!\n" + this + " already has an entity with SemoGames.Collectables.CollectedAmountComponent!",
                "You should check if the context already has a collectedAmountEntity before setting it or use context.ReplaceCollectedAmount().");
        }
        var entity = CreateEntity();
        entity.AddCollectedAmount(newValue);
        return entity;
    }

    public void ReplaceCollectedAmount(int newValue) {
        var entity = collectedAmountEntity;
        if (entity == null) {
            entity = SetCollectedAmount(newValue);
        } else {
            entity.ReplaceCollectedAmount(newValue);
        }
    }

    public void RemoveCollectedAmount() {
        collectedAmountEntity.Destroy();
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

    public SemoGames.Collectables.CollectedAmountComponent collectedAmount { get { return (SemoGames.Collectables.CollectedAmountComponent)GetComponent(GameComponentsLookup.CollectedAmount); } }
    public bool hasCollectedAmount { get { return HasComponent(GameComponentsLookup.CollectedAmount); } }

    public void AddCollectedAmount(int newValue) {
        var index = GameComponentsLookup.CollectedAmount;
        var component = (SemoGames.Collectables.CollectedAmountComponent)CreateComponent(index, typeof(SemoGames.Collectables.CollectedAmountComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCollectedAmount(int newValue) {
        var index = GameComponentsLookup.CollectedAmount;
        var component = (SemoGames.Collectables.CollectedAmountComponent)CreateComponent(index, typeof(SemoGames.Collectables.CollectedAmountComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCollectedAmount() {
        RemoveComponent(GameComponentsLookup.CollectedAmount);
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

    static Entitas.IMatcher<GameEntity> _matcherCollectedAmount;

    public static Entitas.IMatcher<GameEntity> CollectedAmount {
        get {
            if (_matcherCollectedAmount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollectedAmount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollectedAmount = matcher;
            }

            return _matcherCollectedAmount;
        }
    }
}
