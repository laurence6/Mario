﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MarioPirates
{
    internal sealed class Scene
    {
        public static Scene Instance { get; } = new Scene();

        List<LevelDataObject> levelDataObjects = new List<LevelDataObject>();

        private List<GameObject> gameObjects = new List<GameObject>();
        private List<GameObject> gameObjectsStatic = new List<GameObject>();

        private Scene() { }

        public void Reset()
        {
            gameObjects.Clear();
            gameObjectsStatic.Clear();

            LoadJSON();



            var mario = new Mario(600, 200);
            AddGameObject(mario, false);

            var hiddenBlock = new UsedBlock(100, 0);
            hiddenBlock.SetHidden(true);
            AddGameObject(hiddenBlock);

            var brickBlock = new BrickBlock(100, 150);
            AddGameObject(brickBlock);

            var brokenBlock = new BrokenBlock(100, 200);
            AddGameObject(brokenBlock);

            var usedBlock = new UsedBlock(100, 250);
            AddGameObject(usedBlock);

            var orangeBlock = new OrangeBlock(100, 100);
            AddGameObject(orangeBlock);

            var questionBlock = new QuestionBlock(100, 50);
            AddGameObject(questionBlock);

            var pipe = new Pipe(200, 200);
            AddGameObject(pipe);

            var flower = new Flower(400, 100);
            AddGameObject(flower);

            var coin = new Coin(600, 100);
            AddGameObject(coin);

            var star = new Star(500, 100);
            AddGameObject(star);

            var redMush = new RedMushroom(200, 100);
            AddGameObject(redMush);

            var greenMush = new GreenMushroom(300, 100);
            AddGameObject(greenMush);

            var koopa = new Koopa(700, 100);
            AddGameObject(koopa, false);

            var goomba = new Goomba(0, 400);
            AddGameObject(goomba, false);
            goomba.RigidBody.Velocity = new Vector2(100f, 0f);

            var bushes = new Bushes(100, 400);
            AddGameObject(bushes);

            var hills = new Hills(300, 400);
            AddGameObject(hills);
        }

        public void LoadJSON()
        {
            using (var read = new StreamReader("levelData.json"))
            {
                var json = read.ReadToEnd();
                levelDataObjects = JsonConvert.DeserializeObject<List<LevelDataObject>>(json);
            }
        }

        public void AddGameObject(GameObject o, bool isStatic = true) =>
            (isStatic ? gameObjectsStatic : gameObjects).Add(o);

        public void Update(float dt)
        {
            Physics.Simulate(dt, in gameObjects, in gameObjectsStatic);
        }

        public void Draw(SpriteBatch spriteBatch, Dictionary<string, Texture2D> textures)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            gameObjects.ForEach(o => o.Draw(spriteBatch, textures));
            gameObjectsStatic.ForEach(o => o.Draw(spriteBatch, textures));
            spriteBatch.End();
        }
    }
}
