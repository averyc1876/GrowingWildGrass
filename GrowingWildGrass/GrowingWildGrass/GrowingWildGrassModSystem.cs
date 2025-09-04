using GrowingWildGrass.Blocks;
using HarmonyLib;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.Server;

namespace GrowingWildGrass
{
    public class GrowingWildGrassModSystem : ModSystem
    {
        Harmony harmony;
        // Called on server and client
        // Useful for registering block/entity classes on both sides
        public override void Start(ICoreAPI api)
        {
            harmony = new Harmony(Mod.Info.ModID);
            harmony.PatchAll();

            api.RegisterBlockClass("BlockWildgrassHaylayer", typeof(BlockWildgrassHaylayer));
        }

        public override void Dispose()
        {
            base.Dispose();
            harmony.UnpatchAll();
        }

    }
}
