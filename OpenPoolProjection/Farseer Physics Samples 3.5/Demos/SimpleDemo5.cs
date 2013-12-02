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
        private Objects _circles1;
        private Objects _circles2;
        private Objects _circles3;
        private Objects _circles4;

        #region IDemoScreen Members

        public string GetTitle()
        {
            return "Collision Categories";
        }

        public string GetDetails()
        {
            var sb = new StringBuilder();
            sb.AppendLine("This project try to demonstrate physics of billiard game");
            sb.AppendLine("In this demo:");
            sb.AppendLine("  - Circles are set to only collide with themselves.");
            sb.AppendLine(string.Empty);
            sb.AppendLine("GamePad:");
            sb.AppendLine("  - Rotate agent: left and right triggers");
            sb.AppendLine("  - Move cursor: left thumbstick");
            sb.AppendLine("  - Grab object (beneath cursor): A button");
            sb.AppendLine("  - Drag grabbed object: left thumbstick");
            sb.AppendLine("  - Exit to menu: Back button");
            sb.AppendLine(string.Empty);
            sb.AppendLine("Keyboard:");
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



            var startXPoint = -10f;
            var startYPoint = -3f;
            var diameter = 1.2f;
            var ballCount = 5;
            var startPosition = new Vector2(startXPoint, startYPoint);
            var endPosition = new Vector2(startXPoint, startYPoint + ((diameter-0.2f) * ballCount));

            _circles = new Objects(World, ScreenManager, startPosition, endPosition, ballCount, diameter/2f, ObjectType.Circle)
            {
                //Collide with itself only
                CollisionCategories = Category.Cat1,
                CollidesWith = Category.Cat1
            };

            startXPoint+=1.1f;
            startYPoint += 0.6f;
            ballCount=4;
            startPosition = new Vector2(startXPoint, startYPoint);
            endPosition = new Vector2(startXPoint, startYPoint + ((diameter - 0.2f) * ballCount));
            _circles1 = new Objects(World, ScreenManager, startPosition, endPosition, ballCount, diameter / 2f, ObjectType.Circle)
            {
                //Collide with itself only
                CollisionCategories = Category.Cat1,
                CollidesWith = Category.Cat1
            };

            startXPoint += 1.1f;
            startYPoint += 0.6f;
            ballCount = 3;
            startPosition = new Vector2(startXPoint, startYPoint);
            endPosition = new Vector2(startXPoint, startYPoint + ((diameter -0.3f) * ballCount));
            _circles2 = new Objects(World, ScreenManager, startPosition, endPosition, ballCount, diameter / 2f, ObjectType.Circle)
            {
                //Collide with itself only
                CollisionCategories = Category.Cat1,
                CollidesWith = Category.Cat1
            };

            startXPoint += 1.1f;
            startYPoint += 0.6f;
            ballCount = 2;
            startPosition = new Vector2(startXPoint, startYPoint);
            endPosition = new Vector2(startXPoint, startYPoint + ((diameter - 0.5f) * ballCount));
            _circles3 = new Objects(World, ScreenManager, startPosition, endPosition, ballCount, diameter / 2f, ObjectType.Circle)
            {
                //Collide with itself only
                CollisionCategories = Category.Cat1,
                CollidesWith = Category.Cat1
            };


            startXPoint += 1f;
            startYPoint += 0.7f;
            ballCount = 2;
            startPosition = new Vector2(startXPoint, startYPoint);
            endPosition = new Vector2(startXPoint *-1f, startYPoint);

            _circles4 = new Objects(World, ScreenManager, startPosition, endPosition, ballCount, diameter / 2f, ObjectType.Circle)
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
            _circles1.Draw();
            _circles2.Draw();
            _circles3.Draw();
            _circles4.Draw();
            ScreenManager.SpriteBatch.End();
            _border.Draw();
            base.Draw(gameTime);
        }
    }
}