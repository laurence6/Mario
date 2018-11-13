using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MarioPirates
{
    internal static class CollisionHandler
    {
        public static void PreCollide(GameObjectRigidBody self, GameObjectRigidBody other)
        {
            switch (self)
            {
                case Star _:
                {
                    var @this = self as Star;
                    if (other is Mario)
                    {
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this));
                    }

                    break;
                }

                case Goomba _:
                {
                    var @this = self as Goomba;
                    if (other is Koopa koopa && koopa.Stomped)
                    {
                        @this.RigidBody.Mass = Constants.OBJECT_TINY_MASS;
                    }

                    break;
                }

                case Coin _:
                {
                    var @this = self as Coin;
                    if (other is Mario)
                    {
                        @this.RigidBody.Mass = Constants.OBJECT_TINY_MASS;
                        Coins.Ins.Value++;
                        Score.Ins.Value += Constants.COIN_POINTS;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this));
                    }

                    break;
                }

                case Fireball _:
                {
                    var @this = self as Fireball;
                    @this.RigidBody.Mass = Constants.OBJECT_TINY_MASS;
                    break;
                }

                case Flower _:
                {
                    var @this = self as Flower;
                    if (other is Mario)
                    {
                        @this.RigidBody.Mass = Constants.OBJECT_TINY_MASS;
                        Score.Ins.Value += Constants.FLOWER_SCORE;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this));
                    }

                    break;
                }

                case GreenMushroom _:
                {
                    var @this = self as GreenMushroom;
                    if (other is Mario)
                    {
                        @this.RigidBody.Mass = Constants.OBJECT_TINY_MASS;
                        Lives.Ins.Value++;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this));
                    }

                    break;
                }

                case RedMushroom _:
                {
                    var @this = self as RedMushroom;
                    if (other is Mario)
                    {
                        @this.RigidBody.Mass = Constants.OBJECT_TINY_MASS;
                        Score.Ins.Value += Constants.REDMUSHROOM_SCORE;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this));
                    }

                    break;
                }
            }
        }


        public static void PostCollide(GameObjectRigidBody self, GameObjectRigidBody other, CollisionSide side)
        {
            switch (self)
            {
                case Block _:
                {
                    var @this = self as Block;

                    if (other is Mario)
                    {
                        if (side == CollisionSide.Bottom && @this.RigidBody.Motion == MotionEnum.Static && !@this.IsUsed)
                        {
                            if (@this.State == BlockState.Hidden)
                                @this.State = BlockState.Normal;

                            @this.RigidBody.Motion = MotionEnum.Keyframe;
                            @this.RigidBody.Velocity = Constants.BLOCK_MARIO_COLLISION_VELOCITY;
                        }
                    }

                    if (self is BrickBlock thisBrickBlock)
                    {
                        if (other is Mario mario && side == CollisionSide.Bottom)
                        {
                            if (thisBrickBlock.Powerup != null)
                            {
                                thisBrickBlock.State = BlockState.Used;

                                var powerupObj = new GameObjectParam
                                {
                                    TypeName = thisBrickBlock.Powerup,
                                    Location = new int[2] { (int)thisBrickBlock.Location.X, (int)thisBrickBlock.Location.Y - Constants.BLOCK_HEIGHT * 2 },
                                    Motion = MotionEnum.Dynamic,
                                }.ToGameObject();
                                EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, thisBrickBlock, new GameObjectCreateEventArgs(powerupObj));
                                if (thisBrickBlock.Powerup == Constants.COIN_TYPE_NAME)
                                {
                                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, thisBrickBlock, new GameObjectDestroyEventArgs(powerupObj), Constants.BLOCK_COLLISION_EVENT_DT);
                                }
                                thisBrickBlock.Powerup = null;
                            }
                            else if (thisBrickBlock.State == BlockState.Normal && !(mario.State.IsSmall || mario.State.IsDead))
                            {
                                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, thisBrickBlock, new GameObjectDestroyEventArgs(thisBrickBlock));

                                for (var i = 0; i < Constants.BRICK_BLOCK_COLLISION_POSITIONS.Length; i++)
                                {
                                    var debris = new GameObjectParam
                                    {
                                        TypeName = Constants.BRICK_DEBRIS_TYPE_NAME,
                                        Location = new int[] { (int)thisBrickBlock.Location.X + Constants.BRICK_BLOCK_COLLISION_OFFSETS[i, 0], (int)thisBrickBlock.Location.Y + Constants.BRICK_BLOCK_COLLISION_OFFSETS[i, 1] },
                                        Motion = MotionEnum.Dynamic,
                                        Params = new Dictionary<string, string> { { Constants.POSITION_PARAM, Constants.BRICK_BLOCK_COLLISION_POSITIONS[i] } },
                                    }.ToGameObject();
                                    (debris as GameObjectRigidBody).RigidBody.Velocity = Constants.BRICK_BLOCK_COLLISION_VELOCITIES[i];
                                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, thisBrickBlock, new GameObjectCreateEventArgs(debris));
                                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, thisBrickBlock, new GameObjectDestroyEventArgs(debris), Constants.BLOCK_COLLISION_EVENT_DT);
                                }
                            }
                        }
                    }

                    else if (self is BlueBrickBlock thisBlueBrickBlock)
                    {
                        if (other is Mario mario && side == CollisionSide.Bottom)
                        {
                            if (thisBlueBrickBlock.Powerup != null)
                            {
                                thisBlueBrickBlock.State = BlockState.Used;

                                var powerupObj = new GameObjectParam
                                {
                                    TypeName = thisBlueBrickBlock.Powerup,
                                    Location = new int[2] { (int)thisBlueBrickBlock.Location.X, (int)thisBlueBrickBlock.Location.Y - Constants.BLOCK_HEIGHT * 2 },
                                    Motion = MotionEnum.Dynamic,
                                }.ToGameObject();
                                EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, thisBlueBrickBlock, new GameObjectCreateEventArgs(powerupObj));
                                if (thisBlueBrickBlock.Powerup == Constants.COIN_TYPE_NAME)
                                {
                                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, thisBlueBrickBlock, new GameObjectDestroyEventArgs(powerupObj), Constants.BLOCK_COLLISION_EVENT_DT);
                                }
                                thisBlueBrickBlock.Powerup = null;
                            }
                            else if (thisBlueBrickBlock.State == BlockState.Normal && !(mario.State.IsSmall || mario.State.IsDead))
                            {
                                EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, thisBlueBrickBlock, new GameObjectDestroyEventArgs(thisBlueBrickBlock));

                                for (var i = 0; i < Constants.BRICK_BLOCK_COLLISION_POSITIONS.Length; i++)
                                {
                                    var debris = new GameObjectParam
                                    {
                                        TypeName = Constants.BLUE_BRICK_DEBRIS_TYPE_NAME,
                                        Location = new int[] { (int)thisBlueBrickBlock.Location.X + Constants.BRICK_BLOCK_COLLISION_OFFSETS[i, 0], (int)thisBlueBrickBlock.Location.Y + Constants.BRICK_BLOCK_COLLISION_OFFSETS[i, 1] },
                                        Motion = MotionEnum.Dynamic,
                                        Params = new Dictionary<string, string> { { Constants.POSITION_PARAM, Constants.BRICK_BLOCK_COLLISION_POSITIONS[i] } },
                                    }.ToGameObject();
                                    (debris as GameObjectRigidBody).RigidBody.Velocity = Constants.BRICK_BLOCK_COLLISION_VELOCITIES[i];
                                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, thisBlueBrickBlock, new GameObjectCreateEventArgs(debris));
                                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, thisBlueBrickBlock, new GameObjectDestroyEventArgs(debris), Constants.BLOCK_COLLISION_EVENT_DT);
                                }
                            }

                        }
                    }

                    else if (self is QuestionBlock thisQuestionBlock)
                    {
                        if (other is Mario)
                        {
                            if (thisQuestionBlock.State == BlockState.Normal && side == CollisionSide.Bottom)
                            {
                                thisQuestionBlock.State = BlockState.Used;

                                if (thisQuestionBlock.Powerup != null)
                                {
                                    var powerupObj = new GameObjectParam
                                    {
                                        TypeName = thisQuestionBlock.Powerup,
                                        Location = new int[2] { (int)thisQuestionBlock.Location.X, (int)thisQuestionBlock.Location.Y - 2 * Constants.BLOCK_HEIGHT },
                                        Motion = MotionEnum.Dynamic,
                                    }.ToGameObject();
                                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, thisQuestionBlock, new GameObjectCreateEventArgs(powerupObj));
                                    if (thisQuestionBlock.Powerup == Constants.COIN_TYPE_NAME)
                                    {
                                        Coins.Ins.Value++;
                                        Score.Ins.Value += Constants.COIN_POINTS;
                                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, thisQuestionBlock, new GameObjectDestroyEventArgs(powerupObj), Constants.BLOCK_COLLISION_EVENT_DT);
                                    }
                                }
                            }
                        }
                    }

                    break;
                }

                case Goomba _:
                {
                    var @this = self as Goomba;

                    if ((other is Mario mario && (side == CollisionSide.Top || mario.State.IsInvincible)) || other is Fireball)
                    {
                        @this.Sprite = SpriteFactory.Ins.CreateSprite(Constants.GOOMBA_STOMPED_SPRITE);
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                        @this.RigidBody.Velocity = Vector2.Zero;
                        Score.Ins.Value += Constants.GOOMBA_POINTS;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this), Constants.ENEMY_COLLISION_EVENT_DT);
                    }
                    else if (other is Koopa koopa && koopa.Stomped)
                    {
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                        @this.RigidBody.Velocity = Constants.GOOMBA_STOMPED_KOOPA_COLLISION_VELOCITY;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this), Constants.ENEMY_COLLISION_EVENT_DT);
                    }

                    break;
                }

                case Koopa _:
                {
                    var @this = self as Koopa;
                    if (other is Mario mario && (side == CollisionSide.Top || mario.State.IsInvincible))
                    {
                        @this.RigidBody.Velocity = new Vector2(!@this.Stomped || @this.RigidBody.Velocity.X.DeEPS() != 0f ? 0f : other.RigidBody.Bound.Center.X > @this.RigidBody.Bound.Center.X ? -Constants.KOOPA_MARIO_COLLISION_VELOCITY.X : Constants.KOOPA_MARIO_COLLISION_VELOCITY.X, 0f);
                        if (!@this.Stomped)
                        {
                            @this.Stomped = true;
                            Score.Ins.Value += Constants.KOOPA_POINTS;
                        }
                        else if(side is CollisionSide.Top)
                        {
                            Score.Ins.Value += Constants.KOOPA_POINTS;
                        }
                    }
                    else if (other is Fireball)
                    {
                        @this.Stomped = true;
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                        @this.RigidBody.Velocity = new Vector2(@this.RigidBody.Velocity.X + (side == CollisionSide.Left ? Constants.KOOPA_FIREBALL_COLLISION_VELOCITY.X : 0f) + (side == CollisionSide.Right ? -Constants.KOOPA_FIREBALL_COLLISION_VELOCITY.X : 0f), Constants.KOOPA_FIREBALL_COLLISION_VELOCITY.Y);
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this), Constants.ENEMY_COLLISION_EVENT_DT);
                    }

                    break;
                }

                case Fireball _:
                {
                    var @this = self as Fireball;
                    if (@this.RigidBody.Grounded)
                    {
                        @this.RigidBody.Velocity = new Vector2(@this.RigidBody.Velocity.X, Constants.FIREBALL_COLLISION_VELOCITY.Y);
                    }
                    if (other is Goomba || other is Koopa)
                    {
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this));
                    }

                    break;
                }

                case Star _:
                {
                    var @this = self as Star;
                    if (@this.RigidBody.Grounded)
                    {
                        @this.RigidBody.Velocity = new Vector2(@this.RigidBody.Velocity.X, Constants.STAR_COLLISION_VELOCITY_Y);
                    }

                    break;
                }

                case Mario _:
                {
                    var @this = self as Mario;
                    if (other is Coin)
                    {
                    }
                    else if (other is Flower)
                    {
                        if (@this.State.IsSmall)
                        {
                            @this.TransitionToBigCount = 0;
                            @this.State.Transiting();
                            EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(() => @this.State.CancelTransiting()), Constants.SMALL_MARIO_FLOWER_COLLISION_EVENT_DT);
                        }
                        @this.State.Fire();
                    }
                    else if (other is GreenMushroom)
                    {
                    }
                    else if (other is PipeTop pipe && pipe.ToLevel != null && side is CollisionSide.Bottom && @this.State.Action.State == MarioStateEnum.Crouch)
                    {
                        @this.UnsubscribeInput();
                        @this.Location = new Vector2(pipe.Location.X + Constants.MARIO_LOCATION_IN_PIPE, @this.Location.Y);
                        @this.RigidBody.Motion = MotionEnum.Keyframe;
                        @this.RigidBody.Velocity = Constants.MARIO_PIPE_COLLISION_VELOCITY;
                        EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(() =>
                        {
                            @this.SubscribeInput();
                            @this.RigidBody.Motion = MotionEnum.Dynamic;
                            @this.RigidBody.Velocity = Vector2.Zero;
                            Scene.Ins.Active(pipe.ToLevel);
                            Scene.Ins.ResetActive();
                        }), Constants.MARIO_PIPE_COLLISION_EVENT_DT);
                    }
                    else if (other is LongPipe && side is CollisionSide.Right)
                    {
                        @this.UnsubscribeInput();
                        @this.RigidBody.Motion = MotionEnum.Keyframe;
                        @this.RigidBody.Velocity = -Constants.MARIO_PIPE_COLLISION_VELOCITY;
                        Scene.Ins.Active(Constants.LEVEL_1_SCENE);
                        Scene.Ins.ResetScene(Constants.SECRET_LEVEL_SCENE);
                        EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(() =>
                        {
                            @this.SubscribeInput();
                            @this.RigidBody.Motion = MotionEnum.Dynamic;
                            @this.RigidBody.Velocity = Vector2.Zero;
                        }), Constants.MARIO_PIPE_COLLISION_EVENT_DT);
                    }
                    else if (other is RedMushroom)
                    {
                        if (@this.State.IsSmall)
                        {
                            @this.TransitionToBigCount = 0;
                            @this.State.Transiting();
                            EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(() => @this.State.CancelTransiting()), Constants.MARIO_MUSHROOM_COLLISION_EVENT_DT);
                        }
                        @this.State.Big();
                    }
                    else if (other is Star)
                    {
                        @this.State.Invincible();
                        EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(() => @this.State.CancelInvincible()), Constants.MARIO_STAR_COLLISION_EVENT_DT);
                    }

                    if (other is Goomba || other is Koopa)
                    {
                        if (!(side is CollisionSide.Bottom) && !@this.State.IsInvincible && !@this.State.IsTransiting)
                        {
                            if (@this.State.IsSmall)
                            {
                                @this.RigidBody.Velocity = Constants.MARIO_ENEMY_COLLISION_VELOCITY;
                                @this.State.Dead();
                            }
                            else
                            {
                                @this.TransitionToSmallCount = 0;
                                @this.State.Transiting();
                                EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(() => @this.State.CancelTransiting()), Constants.MARIO_ENEMY_COLLISION_EVENT_DT);
                                @this.State.Small();
                            }
                        }
                        else if (side is CollisionSide.Bottom)
                        {
                            @this.RigidBody.Velocity = Constants.MARIO_ENEMY_COLLISION_VELOCITY;
                        }
                    }

                    break;
                }

                case VirtualPlane _:
                {
                    var @this = self as VirtualPlane;
                    other.RigidBody.CollisionLayerMask = CollisionLayer.None;
                    EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(other));
                    break;
                }
            }
        }
    }
}
