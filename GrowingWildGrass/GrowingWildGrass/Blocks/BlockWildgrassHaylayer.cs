using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace GrowingWildGrass.Blocks
{
    internal class BlockWildgrassHaylayer : Block
    {
        public override void OnBlockBroken(IWorldAccessor world, BlockPos pos, IPlayer byPlayer, float dropQuantityMultiplier = 1)
        {
            base.OnBlockBroken(world, pos, byPlayer, dropQuantityMultiplier);
            if (Variant["overlay"] == "eaten") world.BlockAccessor.SetBlock(world.GetBlock(new AssetLocation("wildgrass:" + Variant["wildgrass"] + "-0-free")).Id, pos);
            world.BlockAccessor.MarkBlockDirty(pos);
        }
        public override bool OnBlockInteractStart(IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel)
        {
            var alldrops = GetDrops(world, blockSel.Position, byPlayer);
            foreach (var drop in alldrops)
            {
                if (!byPlayer.InventoryManager.TryGiveItemstack(drop, true))
                {
                    world.SpawnItemEntity(drop, blockSel.Position.ToVec3d().AddCopy(0.5, 0.1, 0.5));
                }
            }
            if (Variant["overlay"] == "eaten") world.BlockAccessor.SetBlock(world.GetBlock(new AssetLocation("wildgrass:" + Variant["wildgrass"] + "-0-free")).Id, blockSel.Position);
            else world.BlockAccessor.SetBlock(0, blockSel.Position);
            world.BlockAccessor.MarkBlockDirty(blockSel.Position);
            return true;
        }
    }
}
