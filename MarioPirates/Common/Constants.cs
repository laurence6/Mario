using Microsoft.Xna.Framework;

namespace MarioPirates
{
    internal static class Constants
    {
        public static readonly string CONTENT_PATH_ROOT = "Content\\";
        public static readonly string CONTENT_FILE_TYPE = ".json";
        public static readonly string LEVEL_DATA_PREFIX = "LevelData_";
        public static readonly string DATA_FILE_TYPE = ".json";
        public static readonly string MARIO_SPRITES_LIST_FILE = "MarioSpritesList.json";
        public static readonly string SPRITE_DATA_FILE = "SpritesData.json";
        public static readonly float SPRITE_DEPTH_MUL = 0.1f;

        public static readonly string KEYBOARD_EVENT_PREFIX = "Key";

        public static readonly string CONTENT_ROOT = "Content";
        public static readonly string HUD_SPRITE_FONT = "hud";

        public const int LIVES_RESET = 3;

        public static readonly string SCORE_STRING = "Score ";

        public static readonly string GAME_NAMESPACE = "MarioPirates.";

        public const int BLOCK_WIDTH = 16;
        public const int BLOCK_HEIGHT = 16;
        public static readonly Vector2 BLOCK_MARIO_COLLISION_VELOCITY = new Vector2(0f, -150f);
        public const float BLOCK_COLLISION_EVENT_DT = 500f;
        public static readonly string USED_BLOCK_SPRITE = "usedblock";
        public static readonly string STATE_PARAM = "State";

        public static readonly string BLUE_BRICK_BLOCK_SPRITE = "bluebrickblock";
        public static readonly string POWERUP_PARAM = "Powerup";

        public static readonly string BLUE_BRICK_DEBRIS_SPRITE = "bluebrickdebris";
        public static readonly string POSITION_PARAM = "Position";

        public static readonly string BLUE_BROKEN_BLOCK_SPRITE = "bluebrokenblock";

        public static readonly string BRICK_BLOCK_SPRITE = "brickblock";
        public static readonly string[] BRICK_BLOCK_COLLISION_POSITIONS = new string[4] { "upperleft", "upperright", "lowerleft", "lowerright" };
        public static readonly int[,] BRICK_BLOCK_COLLISION_OFFSETS = new int[4, 2] { { 0, 0 }, { 8, 0 }, { 0, 8 }, { 8, 8 } };
        public static readonly Vector2[] BRICK_BLOCK_COLLISION_VELOCITIES = new Vector2[] { new Vector2(-100f, -200f), new Vector2(100f, -200f), new Vector2(-100f, 0f), new Vector2(100f, 0f) };

        public static readonly string BRICK_DEBRIS_SPRITE = "brickdebris";
        public const int BRICK_DEBRIS_WIDTH = 8;
        public const int BRICK_DEBRIS_HEIGHT = 8;
        public const float BRICK_DEBRIS_MASS = 0.05f;

        public static readonly string BROKEN_BLOCK_SPRITE = "brokenblock";

        public static readonly string ORANGE_BLOCK_SPRITE = "orangeblock";

        public static readonly string QUESTION_BLOCK_SPRITE = "questionblock";

        public const float ENEMY_COLLISION_EVENT_DT = 3000f;

        public static readonly string GOOMBA_SPRITE = "goomba";
        public const int GOOMBA_WIDTH = 16;
        public const int GOOMBA_HEIGHT = 16;
        public const float GOOMBA_MASS = 0.1f;
        public static readonly Vector2 GOOMBA_INITIAL_VELOCITY = new Vector2(-25f, 0f);
        public static readonly Vector2 GOOMBA_STOMPED_KOOPA_COLLISION_VELOCITY = new Vector2(0f, -250f);
        public const int GOOMBA_POINTS = 100;

        public static readonly string KOOPA_LEFT_SPRITE = "koopa_left";
        public static readonly string KOOPA_RIGHT_SPRITE = "koopa_right";
        public static readonly string KOOPA_STOMPED_SPRITE = "koopa_stomped";
        public const int KOOPA_WIDTH = 16;
        public const int KOOPA_HEIGHT = 23;
        public const float KOOPA_MASS = 0.1f;
        public static readonly Vector2 KOOPA_INITIAL_VELOCITY = new Vector2(-25f, 0f);
        public static readonly Vector2 KOOPA_MARIO_COLLISION_VELOCITY = new Vector2(250f, 0f);
        public const int KOOPA_POINTS = 100;
        public static readonly Vector2 KOOPA_FIREBALL_COLLISION_VELOCITY = new Vector2(20f, -250f);

        public static readonly string CASTLE_SPRITE = "castle";
        public const int CASTLE_WIDTH = 80;
        public const int CASTLE_HEIGHT = 80;

        public static readonly string COIN_SPRITE = "coin";
        public const int COIN_WIDTH = 16;
        public const int COIN_HEIGHT = 14;
        public const float COIN_MASS = 0.05f;
        public const int COIN_POINTS = 200;

        public static readonly string FIREBALL_SPRITE = "fireball";
        public const int FIREBALL_WIDTH = 10;
        public const int FIREBALL_HEIGHT = 10;
        public const float FIREBALL_MASS = 0.0005f;
        public static readonly Vector2 FIREBALL_COLLISION_VELOCITY = new Vector2(200f, -200f);

        public static readonly string FLAG_SPRITE = "flag";
        public const int FLAG_WIDTH = 33;
        public const int FLAG_HEIGHT = 168;

        public static readonly string FLOWER_SPRITE = "flower";
        public const int FLOWER_WIDTH = 16;
        public const int FLOWER_HEIGHT = 16;
        public const int FLOWER_SCORE = 1000;

        public static readonly string RED_MUSHROOM_SPRITE = "redmushroom";
        public static readonly string GREEN_MUSHROOM_SPRITE = "greenmushroom";
        public const int REDMUSHROOM_SCORE = 1000;
        public const int MUSHROOM_WIDTH = 16;
        public const int MUSHROOM_HEIGHT = 16;
        public const float MUSHROOM_MASS = 0.05f;
        public static readonly Vector2 MUSHROOM_INITIAL_VELOCITY = new Vector2(50f, 0f);

        public static readonly string LONG_PIPE_SPRITE = "longpipe";
        public const int LONG_PIPE_WIDTH = 62;
        public const int LONG_PIPE_HEIGHT = 128;

        public static readonly string PIPE_BOTTOM_SPRITE = "pipelinebottom";
        public const int PIPE_BOTTOM_WIDTH = 32;

        public static readonly string PIPE_TOP_SPRITE = "pipelinetop";
        public static readonly string TO_LEVEL_PARAM = "ToLevel";
        public const int PIPE_TOP_WIDTH = 32;
        public const int PIPE_TOP_HEIGHT = 15;

        public static readonly string STAR_SPRITE = "star";
        public const int STAR_WIDTH = 14;
        public const int STAR_HEIGHT = 16;
        public const float STAR_MASS = 0.05f;
        public static readonly Vector2 STAR_INITIAL_VELOCITY = new Vector2(100f, 0f);
        public const float STAR_COLLISION_VELOCITY_Y = -200f;

        public const int MARIO_JUMP_HOLD_COUNT_LIMIT = 30;
        public const int MARIO_TRANSITION_COUNT_MAX = 30;
        public static readonly float[] MARIO_TRANSITION_ZOOM = { 2f, 1.67f, 1.33f, 1.67f, 1.33f, 1f };
        public const float MARIO_CO_R = 0.5f;
        public const float MARIO_JUMP_FORCE_Y = -5000f;
        public const float MARIO_JUMP_HOLD_COUNT_MULTIPLIER = 240f;
        public const float MARIO_RUN_FORCE_X = 2000f;
        public const float FIRE_MARIO_FIREBALL_EVENT_DT = 3000f;
        public const int MARIO_TRANSITION_COUNT = 5;
        public const float SMALL_MARIO_FLOWER_COLLISION_EVENT_DT = 1000f;
        public const float MARIO_LOCATION_IN_PIPE = 32f / 4f;
        public static readonly Vector2 MARIO_PIPE_COLLISION_VELOCITY = new Vector2(0f, 50f);
        public const float MARIO_PIPE_COLLISION_EVENT_DT = 1000f;
        public const float MARIO_MUSHROOM_COLLISION_EVENT_DT = 1000f;
        public const float MARIO_STAR_COLLISION_EVENT_DT = 3000f;
        public const float MARIO_ENEMY_COLLISION_EVENT_DT = 1000f;
        public static readonly Vector2 MARIO_ENEMY_COLLISION_VELOCITY = new Vector2(0f, -250f);
        public static Vector2 MARIO_DEFAULT_LOCATION = new Vector2(48, 360);
        public const float RESET_EVENT_DT = 1000f;

        public static readonly string MARIO_STATE_EXTEND = "_";
        public static readonly string STAR_MARIO_SUFFIX = "_star";
        public const int MARIO_STATE_SUBSTRING_LENGTH = 4;
        public static readonly string BIG_MARIO_PREFIX = "big";
        public static readonly string MARIO_BRAKE_SUFFIX = "_brake";

        public const float ACCELERATING_MARIO_MULTIPLIER = 10f;
        public const float NONACCELERATING_MARIO_MULTIPLIER = 1f;

        public const int BIG_MARIO_WIDTH = 32;
        public const int BIG_MARIO_HEIGHT = 64;

        public const int DEAD_MARIO_WIDTH = 30;
        public const int DEAD_MARIO_HEIGHT = 28;

        public const int FIRE_MARIO_WIDTH = 32;
        public const int FIRE_MARIO_HEIGHT = 64;

        public const int SMALL_MARIO_WIDTH = 34;
        public const int SMALL_MARIO_HEIGHT = 30;

        public const int BACKGROUND_WIDTH = 800;
        public const int BACKGROUND_HEIGHT = 480;
        public static readonly string BACKGROUND_PARAM = "Background";

        public const int VIRTUAL_PLANE_HEIGHT = 32;
        public const float VIRTUAL_PLANE_EVENT_DT = 100f;

        public const int VIRTUAL_WALL_WIDTH = 16;

        public static readonly string COIN_TYPE_NAME = "Coin";
        public static readonly string BRICK_DEBRIS_TYPE_NAME = "BrickDebris";
        public static readonly string BLUE_BRICK_DEBRIS_TYPE_NAME = "BlueBrickDebris";
        public static readonly string GOOMBA_STOMPED_SPRITE = "goomba_stomped";

        public const int N_STEPS = 4;

        public const float RIGID_BODY_MASS = 1e24f;
        public const float RIGID_BODY_CO_R = 1f;
        public const float RIGID_BODY_VELOCITY_MAGNITUDE_BOUND = 480f;
        public const float RIGID_BODY_FRICTION_MULTIPLIER = 0.0001f;
        public const float RIGID_BODY_GRAVITY_VELOCITY_Y = 6f;
        public const float RIGID_BODY_RESOLVE_COLLIDE_NORMAL = 1f;

        public const string LEVEL_1_SCENE = "1";
        public const string SECRET_LEVEL_SCENE = "secret";
        public const string GAMEOVER_SCENE = "gameover";
        public const string WIN_SCENE = "win";
        public const string DEFAULT_SCENE = LEVEL_1_SCENE;
        public static readonly string[] AVAILABLE_SCENES = new string[] { LEVEL_1_SCENE, SECRET_LEVEL_SCENE, GAMEOVER_SCENE, WIN_SCENE };
        public const int SCREEN_WIDTH = 800;
        public const int SCREEN_HEIGHT = 480;

        public const ulong HASH_MAP_SIZE = 128;
        public const int INT_SIZE = 32;

        public static readonly string SCORE_TITLE = "SCORE";
        public static readonly string COINS_TITLE = "COINS";
        public static readonly string LEVEL_TITLE = "LEVEL";
        public static readonly string TIME_TITLE = "TIME";
        public static readonly string LIVES_TITLE = "LIVES";
        public static readonly Vector2 SCORE_TITLE_POSITION = new Vector2(800f / 11f, 48f);
        public static readonly Vector2 COINS_TITLE_POSITION = new Vector2(3f * 800f / 11f, 48f);
        public static readonly Vector2 LEVEL_TITLE_POSITION = new Vector2(5f * 800f / 11f, 48f);
        public static readonly Vector2 TIME_TITLE_POSITION = new Vector2(7f * 800f / 11f, 48f);
        public static readonly Vector2 LIVES_TITLE_POSITION = new Vector2(9f * 800f / 11f, 48f);
        public static readonly Vector2 SCORE_VALUE_POSITION = new Vector2(800f / 11f, 96f);
        public static readonly Vector2 COINS_VALUE_POSITION = new Vector2(3f * 800f / 11f, 96f);
        public static readonly Vector2 LEVEL_VALUE_POSITION = new Vector2(5f * 800f / 11f, 96f);
        public static readonly Vector2 TIME_VALUE_POSITION = new Vector2(7f * 800f / 11f, 96f);
        public static readonly Vector2 LIVES_VALUE_POSITION = new Vector2(9f * 800f / 11f, 96f);

        public const float FRAME_UPDATE_INTERVAL = 250f;
        public const float MAX_DEPTH = 10f;
    }
}
