using System.Text;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Samples.Demos.Prefabs;
using FarseerPhysics.Samples.ScreenSystem;
using Microsoft.Xna.Framework;

namespace FarseerPhysics.Samples.Demos
{
    internal class SimpleDemo5 : PhysicsGameScreen, IDemoScreen
    {
        private Border _border;
        private Objects _circles;

        #region IDemoScreen Members

        public string GetTitle()
        {
            return "Collision Categories";
        }

        public string GetDetails()
        {
            var sb = new StringBuilder();
            sb.AppendLine("This demo shows how to setup complex collision scenerios.");
            sb.AppendLine("In this demo:");
            sb.AppendLine("  - Circles and rectangles are set to only collide with themselves.");
            sb.AppendLine("  - Stars are set to collide with gears.");
            sb.AppendLine("  - Gears are set to collide with stars.");
            sb.AppendLine("  - The agent is set to collide with everything but stars");
            sb.AppendLine(string.Empty);
            sb.AppendLine("GamePad:");
            sb.AppendLine("  - Rotate agent: left and right triggers");
            sb.AppendLine("  - Move agent: right thumbstick");
            sb.AppendLine("  - Move cursor: left thumbstick");
            sb.AppendLine("  - Grab object (beneath cursor): A button");
            sb.AppendLine("  - Drag grabbed object: left thumbstick");
            sb.AppendLine("  - Exit to menu: Back button");
            sb.AppendLine(string.Empty);
            sb.AppendLine("Keyboard:");
            sb.AppendLine("  - Rotate agent: left and right arrows");
            sb.AppendLine("  - Move agent: A,S,D,W");
            sb.AppendLine("  - Exit to menu: Escape");
            sb.AppendLine(string.Empty);
            sb.AppendLine("Mouse / Touchscreen");
            sb.AppendLine("  - Grab object (beneath cursor): Left click");
            sb.AppendLine("  - Drag grabbed object: move mouse / finger");
            return sb.ToString();
        }

        #endregion

        public override void LoadContent()
        {
            base.LoadContent();

            World.Gravity = Vector2.Zero;

            _border = new Border(World, ScreenManager, Camera);

            var startPosition = new Vector2(-10f, 0f);
            var endPosition = new Vector2(10, 0f);
            _circles = new Objects(World, ScreenManager, startPosition, endPosition, 15, 0.6f, ObjectType.Circle)
            {
                //Collide with itself only
                CollisionCategories = Category.Cat1,
                CollidesWith = Category.Cat1
            };

            
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.SpriteBatch.Begin(0, null, null, null, null, null, Camera.View);

            _circles.Draw();

            ScreenManager.SpriteBatch.End();
            _border.Draw();
            base.Draw(gameTime);
        }
    }
}