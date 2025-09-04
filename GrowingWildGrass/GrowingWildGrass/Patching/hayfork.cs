using ArtOfGrowing.Blocks;
using ArtOfGrowing.Items;
using GrowingWildGrass.Blocks;
using HarmonyLib;
using Vintagestory.API.Common;

namespace GrowingWildGrass.Patching
{
    [HarmonyPatch]
    static class AOGItemHayFork_Patch
    {
        [HarmonyPatch(typeof(AOGItemHayfork), "CanMultiBreak")]
        static void PostFix(Block block, ref bool __result)
        {
            __result = __result || block is BlockWildgrassHaylayer;
        }
    }
}
