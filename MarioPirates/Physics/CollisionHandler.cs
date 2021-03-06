﻿using Microsoft.Xna.Framework;
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
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                    }

                    break;
                }

                case Coin _:
                {
                    var @this = self as Coin;
                    if (other is Mario)
                    {
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                        Coins.Ins.Value++;
                        Score.Ins.Value += Constants.COIN_POINTS;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, @this, new GameObjectCreateEventArgs(new PromptingPoints(@this.Location.X, @this.Location.Y, Constants.COIN_POINTS)));
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this));
                    }

                    break;
                }

                case Flag _:
                {
                    var @this = self as Flag;
                    if (other is Mario)
                    {
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                    }
                    break;
                }

                case Flower _:
                {
                    var @this = self as Flower;
                    if (other is Mario)
                    {
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                        Score.Ins.Value += Constants.FLOWER_SCORE;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, @this, new GameObjectCreateEventArgs(new PromptingPoints(@this.Location.X, @this.Location.Y, Constants.FLOWER_SCORE)));
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this));
                    }

                    break;
                }

                case GreenMushroom _:
                {
                    var @this = self as GreenMushroom;
                    if (other is Mario)
                    {
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
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
                        @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                        Score.Ins.Value += Constants.REDMUSHROOM_SCORE;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, @this, new GameObjectCreateEventArgs(new PromptingPoints(@this.Location.X, @this.Location.Y, Constants.REDMUSHROOM_SCORE)));
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
                                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, @this, new GameObjectCreateEventArgs(new PromptingPoints(@this.Location.X, @this.Location.Y, Constants.COIN_POINTS)));
                                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, thisQuestionBlock, new GameObjectDestroyEventArgs(powerupObj), Constants.BLOCK_COLLISION_EVENT_DT);
                                        AudioManager.Ins.PowerupCoin();
                                    }
                                    else
                                    {
                                        AudioManager.Ins.ItemAppear();
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
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, @this, new GameObjectCreateEventArgs(new PromptingPoints(@this.Location.X, @this.Location.Y, Constants.GOOMBA_POINTS)));
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
                        @this.Stomped = true;
                        Score.Ins.Value += Constants.KOOPA_POINTS;
                        EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, @this, new GameObjectCreateEventArgs(new PromptingPoints(@this.Location.X, @this.Location.Y, Constants.KOOPA_POINTS)));
                        if (mario.State.IsInvincible)
                        {
                            @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                            @this.RigidBody.Velocity = Vector2.Zero;
                            EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this), Constants.ENEMY_COLLISION_EVENT_DT);
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

                case Octopus _:
                    {
                        var @this = self as Octopus;

                        if ((other is Mario mario && (side == CollisionSide.Top || mario.State.IsInvincible)) || other is Fireball)
                        {
                            @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                            @this.RigidBody.Velocity = Vector2.Zero;
                            Score.Ins.Value += Constants.OCTOPUS_POINTS;
                            EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, @this, new GameObjectCreateEventArgs(new PromptingPoints(@this.Location.X, @this.Location.Y, Constants.OCTOPUS_POINTS)));
                            EventManager.Ins.RaiseEvent(EventEnum.GameObjectDestroy, @this, new GameObjectDestroyEventArgs(@this), Constants.ENEMY_COLLISION_EVENT_DT);
                        }

                        break;
                    }

                case Fish _:
                    {
                        var @this = self as Fish;

                        if ((other is Mario mario && (side == CollisionSide.Top || mario.State.IsInvincible)) || other is Fireball)
                        {
                            @this.RigidBody.CollisionLayerMask = CollisionLayer.None;
                            @this.RigidBody.Velocity = Vector2.Zero;
                            Score.Ins.Value += Constants.FISH_POINTS;
                            EventManager.Ins.RaiseEvent(EventEnum.GameObjectCreate, @this, new GameObjectCreateEventArgs(new PromptingPoints(@this.Location.X, @this.Location.Y, Constants.FISH_POINTS)));
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
                    switch (other)
                    {
                        case Flower _:
                            if (@this.State.IsSmall)
                            {
                                @this.TransitionToBigCount = 0;
                                @this.State.Transiting();
                                EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(@this.State.CancelTransiting), Constants.SMALL_MARIO_FLOWER_COLLISION_EVENT_DT);
                            }
                            @this.State.TurnFire();
                            break;
                        case PipeTop pipe when pipe.ToLevel != null && side is CollisionSide.Bottom && @this.State.IsCrouch:
                            @this.UnsubscribeInput();
                            @this.Location = new Vector2(pipe.Location.X + Constants.MARIO_LOCATION_IN_PIPE, @this.Location.Y);
                            @this.RigidBody.Motion = MotionEnum.Keyframe;
                            @this.RigidBody.Velocity = Constants.MARIO_PIPE_COLLISION_VELOCITY;
                            @this.RigidBody.ApplyForce(WorldForce.None);
                            EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(() =>
                            {
                                @this.SubscribeInput();
                                @this.RigidBody.Motion = MotionEnum.Dynamic;
                                @this.RigidBody.Velocity = Vector2.Zero;
                                @this.RigidBody.ApplyForce(WorldForce.Friction | WorldForce.Gravity);
                                Scene.Ins.Active(pipe.ToLevel);
                                Scene.Ins.ResetActive();
                            }), Constants.MARIO_PIPE_COLLISION_EVENT_DT);
                            break;
                        case LongPipe _ when side is CollisionSide.Right:
                            @this.UnsubscribeInput();
                            @this.RigidBody.Motion = MotionEnum.Keyframe;
                            @this.RigidBody.Velocity = -Constants.MARIO_PIPE_COLLISION_VELOCITY;
                            @this.RigidBody.ApplyForce(WorldForce.None);
                            var currLevel = Scene.Ins.ActiveScene.level;
                            Scene.Ins.Active(Constants.LEVEL_1_SCENE);
                            Scene.Ins.ResetScene(currLevel);
                            EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(() =>
                            {
                                @this.SubscribeInput();
                                @this.RigidBody.Motion = MotionEnum.Dynamic;
                                @this.RigidBody.Velocity = Vector2.Zero;
                                @this.RigidBody.ApplyForce(WorldForce.Friction | WorldForce.Gravity);
                            }), Constants.MARIO_PIPE_COLLISION_EVENT_DT);
                            break;
                        case Flag _:
                            @this.UnsubscribeInput();
                            @this.RigidBody.ApplyForce(WorldForce.Gravity);
                            @this.RigidBody.Velocity = Constants.MARIO_WALKING_VELOCITY;
                            EventManager.Ins.RaiseEvent(EventEnum.Win, @this, null, Constants.MARIO_WALKING_DT);
                            break;
                        case RedMushroom _:
                            if (@this.State.IsSmall)
                            {
                                @this.TransitionToBigCount = 0;
                                @this.State.Transiting();
                                EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(@this.State.CancelTransiting), Constants.MARIO_MUSHROOM_COLLISION_EVENT_DT);
                                AudioManager.Ins.GetPower();
                            }
                            @this.State.TurnBig();
                            break;
                        case Star _:
                            @this.State.TurnInvincible();
                            break;
                        case Goomba _:
                        case Octopus _:
                        case Fish _:
                        case Koopa _:
                            if ((side is CollisionSide.Bottom) || @this.State.IsInvincible || @this.State.IsTransiting)
                            {
                                if (side is CollisionSide.Bottom)
                                {
                                    @this.RigidBody.Velocity = Constants.MARIO_ENEMY_COLLISION_VELOCITY;
                                }
                            }
                            else
                            {
                                if (!@this.State.IsSmall)
                                {
                                    @this.TransitionToSmallCount = 0;
                                    @this.State.Transiting();
                                    EventManager.Ins.RaiseEvent(EventEnum.Action, @this, new ActionEventArgs(@this.State.CancelTransiting), Constants.MARIO_ENEMY_COLLISION_EVENT_DT);
                                    @this.State.TurnSmall();
                                }
                                else
                                {
                                    @this.RigidBody.Velocity = Constants.MARIO_ENEMY_COLLISION_VELOCITY;
                                    @this.State.TurnDead();
                                }
                            }
                            break;
         
                            case VirtualPlane _:
                            @this.State.TurnDead();
                            break;
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
