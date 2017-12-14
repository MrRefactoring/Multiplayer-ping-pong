﻿using Lib.Interfaces;
using Lib.API;
using System.Windows;
using System.Threading;
using System;

namespace Lib
{
    public class Logic: ILogic
    {

        private Config config;
        private CollisionDetection collision;
        private AnimationController animationController;

        public Logic(Config config)
        {
            this.config = config;
            animationController = new AnimationController(config);
            collision = new CollisionDetection(config);
        }

        public void move(string key)
        {
            ball();
            player(key);
            enemy();
        }

        private void player(string key)
        {
            if (key == "up" && !collision.topCollision(config.left, 10))
            {
                config.left.Margin = new Thickness(config.left.Margin.Left,
                    config.left.Margin.Top - config.playerSpeed, 0, 0);
            }
            else if (key == "down" && !collision.bottomCollision(config.left, 10))
            {
                config.left.Margin = new Thickness(config.left.Margin.Left,
                    config.left.Margin.Top + config.playerSpeed, 0, 0);
            }
        }

        private void enemy()
        {
            double center = config.right.Margin.Top + config.right.Height / 2;
            double ballPosition = config.ball.Margin.Top + config.ball.Height / 2;
            if (ballPosition > center && !collision.bottomCollision(config.right, 8))
            {
                config.right.Margin = new Thickness(config.right.Margin.Left,
                    config.right.Margin.Top + config.enemySpeed, 0, 0);
            } else if (ballPosition < center && !collision.topCollision(config.right, 8))
            {
                config.right.Margin = new Thickness(config.right.Margin.Left,
                    config.right.Margin.Top - config.enemySpeed, 0, 0);
            }
        }

        private void ball()
        {
            if (collision.topCollision(config.ball) || collision.bottomCollision(config.ball))
            {
                config.invertVertcalSpeed();
            } else if (collision.leftPadCollision() || collision.rightPadCollision())
            {
                config.invertHorisontalSpeed();
            } else if (collision.leftCollision(config.ball))
            {
                config.score(false);
                config.speed = null;
                setStartPosition();
            } else if (collision.rightCollision(config.ball))
            {
                config.score(true);
                config.speed = null;
                setStartPosition();
            }
            config.ball.Margin = new Thickness(config.ball.Margin.Left + config.speed[0],
                config.ball.Margin.Top + config.speed[1], 0, 0);
        }

        public void setStartPosition()
        {
            animationController.setStartPosition(config.ball, config.ballPosition);
            animationController.setStartPosition(config.left, config.leftPosition);
            animationController.setStartPosition(config.right, config.rightPosition);
        }

    }
}
