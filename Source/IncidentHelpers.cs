using RimWorld;
using ToolkitPatchLib;
using MoreFactionInteraction;
using MoreFactionInteraction.MoreFactionWar;
using MoreFactionInteraction.World_Incidents;
using MoreFactionInteraction.More_Flavour;
using Verse;
using System.Linq;

namespace ToolkitMoreFactInterPatch
{
    public class IncidentHelper_MFI_ReverseTradeRequest : NormalIncidentHelper<IncidentWorker_ReverseTradeRequest>
    {
        public IncidentHelper_MFI_ReverseTradeRequest() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_ReverseTradeRequest")) { }
    }

    public class VoteHelper_MFI_ReverseTradeRequest : BasicVotingHelper<IncidentWorker_ReverseTradeRequest>
    {
        public VoteHelper_MFI_ReverseTradeRequest() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_ReverseTradeRequest")) { }
    }

    public class IncidentHelper_MFI_Extortion : WagerIncidentHelper<IncidentWorker_Extortion>
    {
        public IncidentHelper_MFI_Extortion() : base(IncidentCategoryDefOf.ThreatSmall, IncidentDef.Named("MFI_PirateExtortion")) { }
    }

    public class VoteHelper_MFI_Extortion : BasicVotingHelper<IncidentWorker_Extortion>
    {
        public VoteHelper_MFI_Extortion() : base(IncidentCategoryDefOf.ThreatSmall, IncidentDef.Named("MFI_PirateExtortion")) { }
    }

    public class IncidentHelper_MFI_WoundedCombatants : WagerIncidentHelper<IncidentWorker_WoundedCombatants>
    {
        public IncidentHelper_MFI_WoundedCombatants() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_WoundedCombatants")) { }
    }

    public class VoteHelper_MFI_WoundedCombatants : BasicVotingHelper<IncidentWorker_WoundedCombatants>
    {
        public VoteHelper_MFI_WoundedCombatants() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_WoundedCombatants")) { }
    }

    public class IncidentHelper_MFI_Roadworks : NormalIncidentHelper
    {
        public IncidentHelper_MFI_Roadworks() : base(IncidentCategoryDefOf.Misc, IncidentDef.Named("MFI_RoadWorks"), Find.World) { }

        public override bool IsPossible()
        {
            bool possible = base.IsPossible();
            if (!possible)
            {
                Map map;
                bool availableTargetMap = Find.Maps.Where(m => m.IsPlayerHome).TryRandomElement(out map);
                bool hasCommConsole = CommsConsoleUtility.PlayerHasPoweredCommsConsole();
                bool hasRandomNearbyTradeableSettlement = (from settlement in Find.WorldObjects.SettlementBases
                 where settlement.Visitable && settlement.Faction?.leader != null
                                            && settlement.trader.CanTradeNow
                                            && Find.WorldGrid.ApproxDistanceInTiles(map.Tile, settlement.Tile) < 36f
                                            && Find.WorldReachability.CanReach(map.Tile, settlement.Tile)
                 select settlement).RandomElementWithFallback(null) == null;

                ToolkitPatchLogger.ErrorLog("Roadworks", $"Roadworks not possible: HasTargetMap: {availableTargetMap} HasCommConsole: {hasCommConsole} HasNearbyTradeSettlement: {hasRandomNearbyTradeableSettlement}");
            }
            return possible;
        }
    }

    public class VoteHelper_MFI_Roadworks : BasicVotingHelper
    {
        public VoteHelper_MFI_Roadworks() : base(IncidentCategoryDefOf.Misc, IncidentDef.Named("MFI_RoadWorks")) { }
    }

    public class IncidentHelper_MFI_DiplomaticMarriage : NormalIncidentHelper<IncidentWorker_DiplomaticMarriage>
    {
        public IncidentHelper_MFI_DiplomaticMarriage() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_DiplomaticMarriage"), Find.World) { }
    }

    public class VoteHelper_MFI_DiplomaticMarriage : BasicVotingHelper<IncidentWorker_DiplomaticMarriage>
    {
        public VoteHelper_MFI_DiplomaticMarriage() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_DiplomaticMarriage")) { }
    }

    public class IncidentHelper_MFI_MysticalShaman : NormalIncidentHelper
    {
        public IncidentHelper_MFI_MysticalShaman() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_MysticalShaman"), Find.World) { }
    }

    public class VoteHelper_MFI_MysticalShaman : BasicVotingHelper
    {
        public VoteHelper_MFI_MysticalShaman() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_MysticalShaman")) { }
    }

    public class IncidentHelper_MFI_HuntersLodge : NormalIncidentHelper<IncidentWorker_HuntersLodge>
    {
        public IncidentHelper_MFI_HuntersLodge() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_HuntersLodge"), Find.World) { }
    }

    public class VoteHelper_MFI_HuntersLodge : BasicVotingHelper<IncidentWorker_HuntersLodge>
    {
        public VoteHelper_MFI_HuntersLodge() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_HuntersLodge")) { }
    }

    public class IncidentHelper_MFI_SettlementBaseAttack : NormalIncidentHelper<IncidentWorker_SettlementBaseAttack>
    {
        public IncidentHelper_MFI_SettlementBaseAttack() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_SettlementBaseAttack"), Find.World) { }
    }

    public class VoteHelper_MFI_SettlementBaseAttack : BasicVotingHelper<IncidentWorker_SettlementBaseAttack>
    {
        public VoteHelper_MFI_SettlementBaseAttack() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_SettlementBaseAttack")) { }
    }

    public class IncidentHelper_MFI_BumperCrop : NormalIncidentHelper<IncidentWorker_BumperCrop>
    {
        public IncidentHelper_MFI_BumperCrop() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_BumperCropRequest"), Find.World) { }
    }

    public class VoteHelper_MFI_BumperCrop : BasicVotingHelper<IncidentWorker_BumperCrop>
    {
        public VoteHelper_MFI_BumperCrop() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_BumperCropRequest")) { }
    }

    public class IncidentHelper_MFI_FactionPeaceTalks : NormalIncidentHelper<IncidentWorker_FactionPeaceTalks>
    {
        public IncidentHelper_MFI_FactionPeaceTalks() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_Quest_PeaceTalks"), Find.World) { }
    }

    public class VoteHelper_MFI_FactionPeaceTalks : BasicVotingHelper<IncidentWorker_FactionPeaceTalks>
    {
        public VoteHelper_MFI_FactionPeaceTalks() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_Quest_PeaceTalks")) { }
    }

    public class IncidentHelper_MFI_AnnualExpo : NormalIncidentHelper<IncidentWorker_AnnualExpo>
    {
        public IncidentHelper_MFI_AnnualExpo() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_AnnualExpo"), Find.World) { }
    }

    public class VoteHelper_MFI_AnnualExpo : BasicVotingHelper<IncidentWorker_AnnualExpo>
    {
        public VoteHelper_MFI_AnnualExpo() : base(IncidentCategoryDefOf.WorldQuest, IncidentDef.Named("MFI_AnnualExpo")) { }
    }

    public class IncidentHelper_MFI_QuestSpreadingPirateCamp : NormalIncidentHelper<IncidentWorker_SpreadingOutpost>
    {
        public IncidentHelper_MFI_QuestSpreadingPirateCamp() : base(IncidentCategoryDefOf.Misc, IncidentDef.Named("MFI_QuestSpreadingPirateCamp"), Find.World) { }
    }

    public class VoteHelper_MFI_QuestSpreadingPirateCamp : BasicVotingHelper<IncidentWorker_SpreadingOutpost>
    {
        public VoteHelper_MFI_QuestSpreadingPirateCamp() : base(IncidentCategoryDefOf.Misc, IncidentDef.Named("MFI_QuestSpreadingPirateCamp")) { }
    }
}
