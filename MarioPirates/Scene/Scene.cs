﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal sealed class Scene
    {
        public class SceneData
        {
            public readonly string level;
            private readonly Mario player;

            public bool HasPlayer { get; private set; }
            public Vector2 PlayerLastLocation { get; private set; } = Constants.MARIO_DEFAULT_LOCATION;
            private HashMap gameObjectContainer = new HashMap();
            private List<IGameObject> gameObjectsNoRigidBody = new List<IGameObject>();

            public SceneData(string level, Mario player)
            {
                this.level = level;
                this.player = player;
            }

            public void Reset()
            {
                gameObjectContainer.Reset();
                gameObjectsNoRigidBody.Clear();
                PlayerLastLocation = Constants.MARIO_DEFAULT_LOCATION;

                AddGameObject(new VirtualPlane(0f, Constants.SCREEN_HEIGHT - 1));
                AddGameObject(new VirtualWall(0f, 0f));
                AddGameObject(new VirtualWall(Constants.SCREEN_WIDTH - Constants.VIRTUAL_WALL_WIDTH, 0f));

                var levelData = new JavaScriptSerializer().Deserialize<LevelData>(ReadAllText(Constants.DATA_FILES_PATH + Constants.LEVEL_DATA_PREFIX + level + Constants.DATA_FILE_TYPE));
                HasPlayer = levelData.HasPlayer;
                if (HasPlayer)
                {
                    AddGameObject(player);
                }
                levelData.Objects.ForEach(o =>
                {
                    AddGameObject(o.ToGameObject());
                });
                levelData.Objects = null;

                var sceneEndBound = 0f;
                gameObjectContainer.ForEachVisible(o => sceneEndBound = sceneEndBound.Max(o.RigidBody.Bound.Right));
                var endWall = new VirtualWall(sceneEndBound - Constants.SCREEN_WIDTH / 2, 0f)
                {
                    IsLocationAbsolute = false
                };

                AddGameObject(endWall);
            }

            public void AddGameObject(IGameObject o)
            {
                if (o is GameObjectRigidBody objectRigidBody)
                    gameObjectContainer.Add(objectRigidBody);
                else
                    gameObjectsNoRigidBody.Add(o);
            }

            public void RemoveGameObject(IGameObject o)
            {
                if (o is GameObjectRigidBody objectRigidBody)
                    gameObjectContainer.Remove(objectRigidBody);
                else
                    gameObjectsNoRigidBody.Remove(o);
            }

            public void Update(float dt)
            {
                Physics.Simulate(dt, gameObjectContainer);

                gameObjectsNoRigidBody.ForEach(o => o.Update(dt));
                gameObjectContainer.ForEachVisible(o => o.Update(dt));
            }

            public void Draw(SpriteBatch spriteBatch)
            {
                spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: Camera.Ins.Transform);
                gameObjectsNoRigidBody.ForEach(o => o.Draw(spriteBatch));
                gameObjectContainer.ForEachVisible(o => o.Draw(spriteBatch));
                spriteBatch.End();
            }

            public void Active()
            {
                if (HasPlayer)
                {
                    player.Location = PlayerLastLocation;
                    player.AllowJumpInAir = Constants.ALLOW_JUMP_IN_AIR[level];
                }
            }

            public void Deactive()
            {
                if (HasPlayer)
                    PlayerLastLocation = player.Location;
            }
        }

        public static readonly Scene Ins = new Scene();

        private Scene()
        {
        }

        private Dictionary<string, SceneData> scenes = new Dictionary<string, SceneData>();
        public SceneData ActiveScene { get; private set; }
        internal Mario Player { get; set; }

        private Action unsubscribe = null;

        public void Reset()
        {
            Player?.Dispose();
            scenes.Clear();
            var param = new GameObjectParam
            {
                TypeName = "Mario",
                Location = new int[] { (int)Constants.MARIO_DEFAULT_LOCATION.X, (int)Constants.MARIO_DEFAULT_LOCATION.Y },
                Motion = MotionEnum.Dynamic,
                Force = WorldForce.Gravity | WorldForce.Friction,
                Mass = 1,
            };
            Player = (Mario)param.ToGameObject();
            ActiveScene = null;
            unsubscribe = null;
            Constants.AVAILABLE_SCENES.ForEach(level => scenes.Add(level, new SceneData(level, Player)));
            scenes.ForEach((name, scene) => scene.Reset());
        }

        public void ResetActive()
        {
            ActiveScene.Reset();
            Player.Location = ActiveScene.PlayerLastLocation;
        }

        public void ResetScene(string level) => scenes[level].Reset();

        public void Active(string level)
        {
            unsubscribe?.Invoke();
            unsubscribe = null;

            ActiveScene?.Deactive();
            ActiveScene = scenes[level];
            ActiveScene.Active();
            Camera.Ins.Reset();
            Camera.Ins.LookAt(Player.Location);

            unsubscribe += EventManager.Ins.Subscribe(EventEnum.GameObjectCreate, (s, e) => ActiveScene.AddGameObject((e as GameObjectCreateEventArgs).Object));
            unsubscribe += EventManager.Ins.Subscribe(EventEnum.GameObjectDestroy, (s, e) =>
            {
                var eventArgs = e as GameObjectDestroyEventArgs;
                (eventArgs.Object as IDisposable)?.Dispose();
                ActiveScene.RemoveGameObject(eventArgs.Object);
            });
        }

        public void Update(float dt) => ActiveScene.Update(dt);

        public void Draw(SpriteBatch spriteBatch) => ActiveScene.Draw(spriteBatch);
    }
}
