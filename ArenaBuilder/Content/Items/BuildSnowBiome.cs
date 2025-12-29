using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArenaBuilder.Content.Items
{ 
	public class BuildSnowBiome : ModItem
	{
		private const int Width = 150;
		private const int Depth = 100;
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(silver: 1);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = false;
		}

        public override bool? UseItem(Player player)
        {
			for (int i = player.Center.ToTileCoordinates().Y + 2; i < player.Center.ToTileCoordinates().Y + 2 + Depth; i++)
			{
				for (int j = player.Center.ToTileCoordinates().X - Width; j < player.Center.ToTileCoordinates().X + Width; j++)
				{
					WorldGen.PlaceTile(j, i, TileID.SnowBlock, forced: true);
				}
			}
			return true;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SnowBlock, 100);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}