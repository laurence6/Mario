using Microsoft.Xna.Framework;

namespace MarioPirates
{
    public static class Constants
    {
        // Gameplay
        public static readonly int LIVES_RESET = 3;

        // Object
        public static readonly float OBJECT_PRECOLLISION_MASS = 1e-6f;

        // Block
        public static readonly int BLOCK_WIDTH = 16;
        public static readonly int BLOCK_HEIGHT = 16;
        public static readonly Vector2 BLOCK_MARIO_COLLISION_VELOCITY = new Vector2(0f, -150f);
        public static readonly float BLOCK_COLLISION_EVENT_DT = 500f;

        public static readonly string[] BRICK_BLOCK_COLLISION_POSITIONS = new string[4] { "upperleft", "upperright", "lowerleft", "lowerright" };
        public static readonly int[,] BRICK_BLOCK_COLLISION_OFFSETS = new int[4, 2] { { 0, 0 }, { 8, 0 }, { 0, 8 }, { 8, 8 } };
        public static readonly Vector2[] BRICK_BLOCK_COLLISION_VELOCITIES = new Vector2[] { new Vector2(-100f, -200f), new Vector2(100f, -200f), new Vector2(-100f, 0f), new Vector2(100f, 0f) };

        public static readonly int BRICK_DEBRIS_WIDTH = 8;
        public static readonly int BRICK_DEBRIS_HEIGHT = 8;
        public static readonly float BRICK_DEBRIS_MASS = 0.05f;

        // Enemy
        public static readonly float ENEMY_COLLISION_EVENT_DT = 3000f;

        public static readonly int GOOMBA_WIDTH = 16;
        public static readonly int GOOMBA_HEIGHT = 16;
        public static readonly float GOOMBA_MASS = 0.1f;
        public static readonly Vector2 GOOMBA_INITIAL_VELOCITY = new Vector2(-25f, 0f);
        public static readonly Vector2 GOOMBA_STOMPED_KOOPA_COLLISION_VELOCITY = new Vector2(0f, -250f);
        public static readonly int GOOMBA_POINTS = 100;

        public static readonly int KOOPA_WIDTH = 16;
        public static readonly int KOOPA_HEIGHT = 23;
        public static readonly float KOOPA_MASS = 0.1f;
        public static readonly Vector2 KOOPA_INITIAL_VELOCITY = new Vector2(-25f, 0f);
        public static readonly Vector2 KOOPA_MARIO_COLLISION_VELOCITY = new Vector2(250f, 0f);
        public static readonly int KOOPA_POINTS = 100;
        public static readonly Vector2 KOOPA_FIREBALL_COLLISION_VELOCITY = new Vector2(20f, -250f);

        // Item
        public static readonly int CASTLE_WIDTH = 80;
        public static readonly int CASTLE_HEIGHT = 80;

        public static readonly int COIN_WIDTH = 16;
        public static readonly int COIN_HEIGHT = 14;
        public static readonly float COIN_MASS = 0.05f;

        public static readonly int FIREBALL_WIDTH = 10;
        public static readonly int FIREBALL_HEIGHT = 10;
        public static readonly float FIREBALL_MASS = 0.05f;
        public static readonly Vector2 FIREBALL_COLLISION_VELOCITY = new Vector2(200f, -200f);

        public static readonly int FLAG_WIDTH = 33;
        public static readonly int FLAG_HEIGHT = 168;

        public static readonly int FLOWER_WIDTH = 16;
        public static readonly int FLOWER_HEIGHT = 16;

        public static readonly int MUSHROOM_WIDTH = 16;
        public static readonly int MUSHROOM_HEIGHT = 16;
        public static readonly float MUSHROOM_MASS = 0.05f;
        public static readonly Vector2 MUSHROOM_INITIAL_VELOCITY = new Vector2(50f, 0f);

        public static readonly int PIPE_BOTTOM_WIDTH = 32;

        public static readonly int PIPE_TOP_WIDTH = 32;
        public static readonly int PIPE_TOP_HEIGHT = 15;

        public static readonly int STAR_WIDTH = 14;
        public static readonly int STAR_HEIGHT = 16;
        public static readonly float STAR_MASS = 0.05f;
        public static readonly Vector2 STAR_INITIAL_VELOCITY = new Vector2(100f, 0f);
        public static readonly float STAR_COLLISION_VELOCITY_Y = -200f;


        // Mario
        public static readonly int MARIO_JUMP_HOLD_COUNT_LIMIT = 30;
        public static readonly int MARIO_TRANSITION_COUNT_MAX = 30;
        public static readonly float[] MARIO_TRANSITION_ZOOM = { 2f, 1.67f, 1.33f, 1.67f, 1.33f, 1f };
        public static readonly float MARIO_CO_R = 0.5f;
        public static readonly float MARIO_JUMP_FORCE_Y = -5000f;
        public static readonly float MARIO_JUMP_HOLD_COUNT_MULTIPLIER = 240f;
        public static readonly float MARIO_RUN_FORCE_X = 2000f;
        public static readonly float FIRE_MARIO_FIREBALL_EVENT_DT = 3000f;
        public static readonly int MARIO_TRANSITION_COUNT = 5;
        public static readonly float SMALL_MARIO_FLOWER_COLLISION_EVENT_DT = 1000f;
        public static readonly float MARIO_LOCATION_IN_PIPE = 32f / 4f;
        public static readonly Vector2 MARIO_PIPE_COLLISION_VELOCITY = new Vector2(0f, 50f);
        public static readonly float MARIO_PIPE_COLLISION_EVENT_DT = 1000f;
        public static readonly float MARIO_MUSHROOM_COLLISION_EVENT_DT = 1000f;
        public static readonly float MARIO_STAR_COLLISION_EVENT_DT = 3000f;
        public static readonly Vector2 SMALL_MARIO_ENEMY_COLLISION_VELOCITY = new Vector2(0f, -250f);
        public static readonly float MARIO_ENEMY_COLLISION_EVENT_DT = 1000f;
        public static readonly Vector2 MARIO_ENEMY_COLLISION_VELOCITY = new Vector2(0f, -200f);
        public static readonly float MARIO_DISPOSE_EVENT_DT = 4000f;

        public static readonly float ACCELERATING_MARIO_MULTIPLIER = 10f;
        public static readonly float NONACCELERATING_MARIO_MULTIPLIER = 1f;

        public static readonly int BIG_MARIO_WIDTH = 32;
        public static readonly int BIG_MARIO_HEIGHT = 64;

        public static readonly int DEAD_MARIO_WIDTH = 30;
        public static readonly int DEAD_MARIO_HEIGHT = 28;

        public static readonly int FIRE_MARIO_WIDTH = 32;
        public static readonly int FIRE_MARIO_HEIGHT = 64;

        public static readonly int SMALL_MARIO_WIDTH = 34;
        public static readonly int SMALL_MARIO_HEIGHT = 30;

        // Virtual
        public static readonly int BACKGROUND_WIDTH = 800;
        public static readonly int BACKGROUND_HEIGHT = 480;

        public static readonly float VIRTUAL_PLANE_EVENT_DT = 1000f;
        public static readonly Vector2 VIRTUAL_PLANE_COLLISION_VELOCITY = new Vector2(0f, 100f);

        public static readonly int VIRTUAL_WALL_WIDTH = 16;

        // Physics
        public static readonly int N_STEPS = 4;

        public static readonly float RIGID_BODY_MASS = 1e24f;
        public static readonly float RIGID_BODY_CO_R = 1f;
        public static readonly float RIGID_BODY_VELOCITY_MAGNITUDE_BOUND = 480f;
        public static readonly float RIGID_BODY_FRICTION_MULTIPLIER = 0.0001f;
        public static readonly float RIGID_BODY_GRAVITY_VELOCITY_Y = 6f;
        public static readonly float RIGID_BODY_RESOLVE_COLLIDE_NORMAL = 1f;

        // Scene
        public static readonly int SCREEN_WIDTH = 800;
        public static readonly int SCREEN_HEIGHT = 480;

        public const ulong HASH_MAP_SIZE = 64;
        public static readonly int INT_SIZE = 32;

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

        // Sprite
        public static readonly float FRAME_UPDATE_INTERVAL = 15f * 0.016f;
    }
}
