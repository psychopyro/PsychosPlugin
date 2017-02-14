namespace Turbo.Plugins.PsychosPlugins
{
    using Turbo.Plugins.Default;
    public class RiftGaurdianAddsMarkerPlugin : BasePlugin
    {

        public WorldDecoratorCollection RiftGaurdianAddDecorator { get; set; }
        public bool GaurdianIsAlive { get; set;}
 
        public RiftGaurdianAddsMarkerPlugin()
        {
            Enabled = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
 
            GaurdianIsAlive = false;

            RiftGaurdianAddDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 17, 255, 69, 2, SharpDX.Direct2D1.DashStyle.Dash),
                    Radius = 4f,
            });
        }
 
        public override void PaintWorld(WorldLayer layer)
        {
            var monsters = Hud.Game.AliveMonsters;

            if (Hud.Game.SpecialArea != SpecialArea.GreaterRift)
            {
                GaurdianIsAlive = false;
                return;
            }

            if (GaurdianIsAlive == false)
            {            
                foreach (var monster in monsters)
                {
                    if (monster.Rarity == ActorRarity.Boss)
                    {
                        GaurdianIsAlive = true;
                        break;
                    }
                }
            }

            if (GaurdianIsAlive == true)
            {
                foreach (var monster in monsters)
                {
                    if (monster.Rarity == ActorRarity.Boss) continue;
                    RiftGaurdianAddDecorator.Paint(layer, monster, monster.FloorCoordinate, string.Empty);
                }
            }
        }
    }
}
