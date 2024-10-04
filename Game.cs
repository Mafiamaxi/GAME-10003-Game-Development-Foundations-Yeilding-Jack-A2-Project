// Include code libraries you need below (use the namespace).
using Game10003;
using System;
using System.Numerics;
using System.Drawing;
using System.Windows.Input;
using Raylib_cs;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Color bgColor = new Color(0x1b, 0x9a, 0xac);
        Color purple = new Color(0xff, 0xd0, 0xd0);
        Color orange = new Color(0xf4, 0x84, 0x8c);
        Color Gray = new Color(0xf5, 0x73, 0x5c);

        float[] ycoordinates = [85, 340, 430];
        float pelletRadius = 10;
        Vector2[] linepositions = new Vector2[2];
        int lineelements = 0;


        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("White arrows");
            Window.SetSize(800, 600);
            Draw.FillColor = Color.Gray;

        }
        //pellets


        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.White);
            Vector2 Mice = Raylib.GetMousePosition();
            //Store mouse position and draw line for trail effect
            if (Raylib.IsMouseButtonUp(MouseButton.Left))
            {
                linepositions[lineelements] = Mice;
                lineelements++;
                lineelements %= 2;
                
            }
            Draw.FillColor = Color.Red;
            for (int i = 0; i < linepositions.Length; i++)
            {
                Draw.Circle(linepositions[i], 2);
            }
           
            Draw.Line(linepositions[0], linepositions[1]);
            //draw random purple square in random area
            Draw.LineSize = 9;
            Draw.FillColor = new Color(172, 5, 255);
            //run loop 45 times
            for (int index = 0; index < 45; index++)
            {
                Draw.Square(200 + Random.Integer(-20,20), 60 + Random.Integer(-20, 20), 260); 
            }
            //Draw orange rectangle at players mouse position
            Draw.LineSize = 10;
            Draw.FillColor = new Color(255, 115, 0);
            //run loop 45 times
            for (int index = 0; index < 9; index++)
            {
                Draw.Rectangle(Mice.X, Mice.Y, 300, 200);
            }

            //pellets
            Draw.FillColor = Color.Gray;
            for (int index = 0; index < 3; index++)
            {
                int xOffset = index * 430;
                Draw.Circle(20, ycoordinates[0], pelletRadius);

            }
            DrawHouse(500, 500);
        }
        
        void DrawHouse(int x, int y)
        {
            //Draw a square x and y positions and this will be the base of the house
            Draw.FillColor = new Color (102, 46, 6);
            Draw.Square(x, y, 100);

            //This is the roof and its above the base of the house
            Draw.FillColor = Color.Blue;
            Draw.Triangle(x, y, x + 100, y, x + 50, y - 100);
            //Draw a window on the house
            Draw.Rectangle(x + 50, y + 30, 20, 30);
        }
    }
}