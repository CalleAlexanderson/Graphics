using System;
using Raylib_cs;

namespace Graphics
{
    class Program
    {
        static void Main(string[] args)
        {

            Raylib.InitWindow(800, 600, "Bad Time");

            float timerMaxValue = 1;
            float timerCurrentValue = timerMaxValue;
            float gameTimer = 0;
            string screen = "intro";
            int playerHp = 10;
            Rectangle playerRectangle = new Rectangle(400, 300, 20, 20);
            Rectangle borderWest = new Rectangle(190, 100, 10, 400);
            Rectangle borderEast = new Rectangle(600, 100, 10, 400);
            Rectangle borderNorth = new Rectangle(190, 100, 410, 10);
            Rectangle borderSouth = new Rectangle(190, 490, 410, 10);
            Rectangle enemy1 = new Rectangle(250, 70, 30, 30);
            Rectangle enemy2 = new Rectangle(320, 70, 30, 30);
            Rectangle enemy3 = new Rectangle(390, 70, 30, 30);
            Rectangle enemy4 = new Rectangle(460, 70, 30, 30);
            Rectangle enemy5 = new Rectangle(530, 70, 30, 30);
            Rectangle enemy6 = new Rectangle(600, 70, 30, 30);
            Rectangle enemy7 = new Rectangle(670, 70, 30, 30);



            while (!Raylib.WindowShouldClose())
            {

                if (screen == "game")
                {
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        if (!Raylib.CheckCollisionRecs(borderEast, playerRectangle))
                        {
                            playerRectangle.x += 0.1f;
                        }
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        if (!Raylib.CheckCollisionRecs(borderWest, playerRectangle))
                        {
                            playerRectangle.x -= 0.1f;
                        }
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                        if (!Raylib.CheckCollisionRecs(borderSouth, playerRectangle))
                        {
                            playerRectangle.y += 0.1f;
                        }
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                        if (!Raylib.CheckCollisionRecs(borderNorth, playerRectangle))
                        {
                            playerRectangle.y -= 0.1f;
                        }

                    }

                    timerCurrentValue -= Raylib.GetFrameTime();
                    gameTimer += Raylib.GetFrameTime();
                    if (Raylib.CheckCollisionRecs(borderNorth, playerRectangle) && timerCurrentValue < 0)
                    {
                        playerHp--;

                        timerCurrentValue = timerMaxValue;
                    }

                    if (Raylib.CheckCollisionRecs(borderEast, playerRectangle) && timerCurrentValue < 0)
                    {
                        playerHp--;

                        timerCurrentValue = timerMaxValue;
                    }

                    if (Raylib.CheckCollisionRecs(borderSouth, playerRectangle) && timerCurrentValue < 0)
                    {
                        playerHp--;

                        timerCurrentValue = timerMaxValue;
                    }

                    if (Raylib.CheckCollisionRecs(borderWest, playerRectangle) && timerCurrentValue < 0)
                    {
                        playerHp--;

                        timerCurrentValue = timerMaxValue;
                    }




                    if (playerHp == 0)
                    {
                        screen = "game over";
                    }

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);

                    Raylib.DrawRectangleRec(playerRectangle, Color.RAYWHITE);
                    Raylib.DrawRectangleRec(borderEast, Color.WHITE);
                    Raylib.DrawRectangleRec(borderNorth, Color.WHITE);
                    Raylib.DrawRectangleRec(borderSouth, Color.WHITE);
                    Raylib.DrawRectangleRec(borderWest, Color.WHITE);

                    Raylib.DrawText(playerHp.ToString(), 20, 20, 30, Color.RAYWHITE);
                    Raylib.DrawText(gameTimer.ToString(), 90, 20, 30, Color.RAYWHITE);

                    if (gameTimer > 2 && gameTimer < 3.5)
                    {
                        Raylib.DrawRectangleRec(enemy1, Color.WHITE);
                        enemy1.y += 0.1f;
                    }

                    if (gameTimer > 2.1 && gameTimer < 3.6)
                    {
                        Raylib.DrawRectangleRec(enemy2, Color.WHITE);
                        enemy2.y += 0.1f;
                    }

                    if (gameTimer > 2.2 && gameTimer < 3.7)
                    {
                        Raylib.DrawRectangleRec(enemy3, Color.WHITE);
                        enemy3.y += 0.1f;
                    }

                    if (gameTimer > 2.3 && gameTimer < 3.8)
                    {
                        Raylib.DrawRectangleRec(enemy4, Color.WHITE);
                        enemy4.y += 0.1f;
                    }

                    if (gameTimer > 2.4 && gameTimer < 3.9)
                    {
                        Raylib.DrawRectangleRec(enemy5, Color.WHITE);
                        enemy5.y += 0.1f;
                    }

                    if (gameTimer == 3.7)
                    {
                        enemy1.x = 1000;
                        enemy1.y = 20;
                    }

                    if (gameTimer > 4 && gameTimer < 5.5)
                    {
                        Raylib.DrawRectangleRec(enemy1, Color.WHITE);
                        enemy1.x -= 0.1f;
                    }

                }

                if (screen == "intro")
                {
                    Raylib.ClearBackground(Color.DARKPURPLE);
                    Raylib.DrawText("Press space to start", 100, 200, 50, Color.LIGHTGRAY);

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        screen = "game";
                    }
                }

                if (screen == "game over")
                {
                    Raylib.ClearBackground(Color.DARKGREEN);
                    Raylib.DrawText("Game Over", 300, 300, 40, Color.RED);
                    Raylib.DrawText("Press space to restart", 100, 200, 50, Color.LIGHTGRAY);

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                    {
                        screen = "game";
                        playerHp = 10;
                        playerRectangle.x = 400;
                        playerRectangle.y = 300;

                    }
                }


                Raylib.EndDrawing();
            }
        }
    }
}
