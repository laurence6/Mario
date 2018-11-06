using Microsoft.Xna.Framework;

namespace MarioPirates
{
    public static class Constants
    {
        // Gameplay
        public static readonly int LIVES_RESET = 3;

        // Block, BrickBlock, BrickDebris, QuestionBlock
        public static readonly int BLOCK_WIDTH = 16;
        public static readonly int BLOCK_HEIGHT = 16;
        public static readonly float BLOCK_MARIO_COLLISION_VELOCITY = 150f;

        public static readonly float DESTROY_COIN_DELAY = 500f;
        public static readonly float BRICK_BLOCK_MARIO_COLLISION_VELOCITY = 100f;
        public static readonly float DESTORY_DEBRIS_DELAY = 500f;

        public static readonly int BRICK_DEBRIS_WIDTH = 8;
        public static readonly int BRICK_DEBRIS_HEIGHT = 8;
        public static readonly float BRICK_DEBRIS_MASS = 0.05f;

        // Goomba, Koopa
        public static readonly int GOOMBA_WIDTH = 16;
        public static readonly int GOOMBA_HEIGHT = 16;
        public static readonly float GOOMBA_MASS = 0.1f;
        public static readonly float GOOMBA_INITIAL_VELOCITY = -25f;
        public static readonly float GOOMBA_PRECOLLISION_MASS = 1e-6f;
        public static readonly float DESTROY_GOOMBA_DELAY = 3000f;
        public static readonly float GOOMBA_STOMPED_KOOPA_COLLISION_VELOCITY = 250f;
        public static readonly int GOOMBA_POINTS = 100;

        public static readonly int KOOPA_WIDTH = 16;
        public static readonly int KOOPA_HEIGHT = 23;
        public static readonly float KOOPA_MASS = 0.1f;
        public static readonly float KOOPA_INITIAL_VELOCITY = -25f;
        public static readonly float KOOPA_MARIO_COLLISION_VELOCITY = 250f;
        public static readonly int KOOPA_POINTS = 100;
        public static readonly float KOOPA_FIREBALL_SIDE_COLLISION_VELOCITY = 20f;
        public static readonly float KOOPA_FIREBALL_COLLISION_Y_VELOCITY = -250f;
        public static readonly float DESTROY_KOOPA_DELAY = 3000f;


        // Castle, Coin, Fireball, Flag, Flower, GreenMushroom, PipeBottom, PipeTop, RedMushroom, Star
        public static readonly int CASTLE_WIDTH = 80;
        public static readonly int CASTLE_HEIGHT = 80;

        public static readonly int COIN_WIDTH = 16;
        public static readonly int COIN_HEIGHT = 14;
        public static readonly float COIN_MASS = 0.05f;
        public static readonly float COIN_PRECOLLISION_MASS = 1e-6f;

        public static readonly int FIREBALL_WIDTH = 10;
        public static readonly int FIREBALL_HEIGHT = 10;
        public static readonly float FIREBALL_MASS = 0.05f;
        public static readonly float FIREBALL_PRECOLLISION_MASS = 1e-6f;
        public static readonly float FIREBALL_COLLISION_VELOCITY = 200f;
        public static readonly float DESTROY_FIREBALL_DELAY = 3000f;

        public static readonly int FLAG_WIDTH = 33;
        public static readonly int FLAG_HEIGHT = 168;

        public static readonly int FLOWER_WIDTH = 16;
        public static readonly int FLOWER_HEIGHT = 16;
        public static readonly float FLOWER_PRECOLLISION_MASS = 1e-6f;
        public static readonly float DESTROY_FLOWER_DELAY = 1000f;

        public static readonly int MUSHROOM_WIDTH = 16;
        public static readonly int MUSHROOM_HEIGHT = 16;
        public static readonly float MUSHROOM_MASS = 0.05f;
        public static readonly float MUSHROOM_INITIAL_VELOCITY = 50f;
        public static readonly float MUSHROOM_PRECOLLISION_MASS = 1e-6f;

        public static readonly int PIPE_BOTTOM_WIDTH = 32;

        public static readonly int PIPE_TOP_WIDTH = 32;
        public static readonly int PIPE_TOP_HEIGHT = 15;

        public static readonly int STAR_WIDTH = 14;
        public static readonly int STAR_HEIGHT = 16;
        public static readonly float STAR_MASS = 0.05f;
        public static readonly float STAR_INITIAL_VELOCITY = 100f;
        public static readonly float STAR_COLLISION_VELOCITY = -200f;


        // Mario, MarioStateAccelerated, MarioStateBig, MarioStateDead, MarioStateFire, MarioStateSmall
        public static readonly int MARIO_JUMP_HOLD_COUNT_LIMIT = 30;
        public static readonly int MARIO_TRANSITION_COUNT_MAX = 30;
        public static readonly float[] MARIO_TRANSITION_ZOOM = { 2f, 1.67f, 1.33f, 1.67f, 1.33f, 1f };
        public static readonly float MARIO_CO_R = 0.5f;
        public static readonly float MARIO_Y_FORCE = -5000;
        public static readonly float MARIO_JUMP_HOLD_COUNT_MULTIPLIER = 240;
        public static readonly float MARIO_X_FORCE = 2000f;
        public static readonly int MARIO_TRANSITION_COUNT = 5;
        public static readonly float MARIO_LOCATION_IN_PIPE = 8f;
        public static readonly float MARIO_PIPE_COLLISION_VELOCITY = 50f;
        public static readonly float MARIO_COLLISION_EVENT_DELAY = 1000f;
        public static readonly float MARIO_STAR_COLLISION_EVENT_DELAY = 3000f;
        public static readonly float SMALL_MARIO_ENEMY_COLLISION_VELOCITY = -250f;
        public static readonly float MARIO_ENEMY_COLLISION_VELOCITY = -200f;
        public static readonly float MARIO_DISPOSE_EVENT_DELAY = 4000f;


        // Background, VirtualWall

        // Physics, RigisBody

        // Camera, HashMap

        // Sprite
    }
}
