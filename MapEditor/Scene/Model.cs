using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace MarioPirates
{
    internal class Model
    {
        public List<IGameObject> Data { get; }

        public Model(string level)
        {
            Data = new JavaScriptSerializer()
                .Deserialize<LevelData>(ReadAllText(Constants.CONTENT_ROOT_PATH + Constants.LEVEL_DATA_PREFIX + level + Constants.DATA_FILE_TYPE))
                .Objects.Map(o => o.ToGameObject());
        }
    }
}
