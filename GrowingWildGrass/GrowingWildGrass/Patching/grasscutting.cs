using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace GrowingWildGrass.Patching
{
    [HarmonyPatch]
    static class BlockWildgrass_OnBlockBroken_Patch
    {
        [HarmonyPatch(typeof(Wildgrass.BlockWildgrass), "OnBlockBroken")]
        static void Postfix(Wildgrass.BlockWildgrass __instance, IWorldAccessor world, BlockPos pos, IPlayer byPlayer, float dropQuantityMultiplier)
        {
            world.Api.Logger.Event("Hello from postfix on {0}", __instance.Code.Path);
            if (__instance.CutInto == null)
                return;
            if (byPlayer != null)
            {
                EnumTool? activeTool = byPlayer.InventoryManager.ActiveTool.GetValueOrDefault();
                if (activeTool == EnumTool.Scythe & activeTool != null)
                {
                    bool trimMode = byPlayer.InventoryManager.ActiveHotbarSlot.Itemstack.Attributes.GetInt("toolMode", 0) == 0;
                    if (trimMode)
                        world.BlockAccessor.SetBlock(__instance.CutInto.Id, pos);
                    else
                        world.BlockAccessor.SetBlock(world.GetBlock(new AssetLocation("growingwildgrass:haylayer-free-" + __instance.CodeWithoutParts(2) + "-" + __instance.Variant["growth"] + "-grass-free")).Id, pos);
                }
            }
        }
    }
}
