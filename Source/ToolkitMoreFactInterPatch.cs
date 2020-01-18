using Verse;
using ToolkitPatchLib;

namespace ToolkitMoreFactInterPatch
{
    public class ToolkitMoreFactInterPatch : Mod
    {
        public ToolkitMoreFactInterPatch(ModContentPack content) : base(content)
        {
            ToolkitPatchLogger.LOGGERNAME = "TMFIP";
        }

        public override string SettingsCategory() => "Toolkit MFI Patch";
    }
}
