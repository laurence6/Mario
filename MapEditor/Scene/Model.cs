﻿using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal class Model
    {
        public readonly string level;
        public readonly string dataFilePath;

        public readonly LevelData Data;
        public readonly List<IGameObject> Objects = new List<IGameObject>();

        public Model(string level)
        {
            this.level = level;
            dataFilePath = Constants.DATA_FILES_PATH + Constants.LEVEL_DATA_PREFIX + level + Constants.DATA_FILE_TYPE;
            Data = new JavaScriptSerializer().Deserialize<LevelData>(ReadAllText(dataFilePath));
            Data.Objects.ForEach(o => Objects.Add(o.ToGameObject()));
        }

        public IGameObject AddGameObject(GameObjectParam param)
        {
            var obj = param.ToGameObject();
            Data.Objects.Add(param);
            Objects.Add(obj);
            return obj;
        }

        public void RemoveGameObject(IGameObject obj)
        {
            var idx = Objects.FindIndex(o => o == obj);
            Data.Objects.RemoveAt(idx);
            Objects.RemoveAt(idx);
        }

        public void Write()
        {
            for (var i = 0; i < Objects.Count; i++)
            {
                Data.Objects[i].Location[0] = (int)Objects[i].RelLocation.X;
                Data.Objects[i].Location[1] = (int)Objects[i].RelLocation.Y;
            }
            var json = new JavaScriptSerializer().Serialize(Data);
            WriteAllText(dataFilePath, json);
        }
    }
}
