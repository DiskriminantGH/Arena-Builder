using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ArenaBuilder.Content.Items
{ 
	public class PlaceArena : ModItem
	{
		private const int Width = 300;
		private const int Height = 200;
		private const int Interval = 35;
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
			int index = 0;
			for (int i = player.Center.ToTileCoordinates().Y + 2; i > player.Center.ToTileCoordinates().Y - Height; i--)
            {
				for (int j = player.Center.ToTileCoordinates().X - Width; j < player.Center.ToTileCoordinates().X + Width; j++)
				{
					WorldGen.KillTile(j, i, noItem: false);
					if (index % Interval == 0)
					{
						WorldGen.PlaceTile(j, i, TileID.Platforms, forced: true);
					}
				}
				index++;
            }
            return true;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WoodPlatform, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
