using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using circuit;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace circuit
{
    [Serializable()]
    public class Connection
    {
        //Data Members:
        private Color color; //the fields is meant for providing the colour of a connection
        private Gate gate1; //the first gate of the connection that preform the output (where to comes from)
        private Gate gate2; //the second gate of the connection that preform the input (where to comes from)
        private int xPos; //To store the x coordinate where the user clicks on the second gate (gate2)  
        private int yPos; //To store the y coordinate where the user clicks on the second gate (gate2) 
        [NonSerialized()] private Panel Sheetpanel; //pane
        [NonSerialized()] ShapeContainer canvas;// to draw Connection(Line) of gates
        [NonSerialized()] public LineShape line;//Connection(Line)


        //Constructor:
        public Connection(Gate gate1, Gate gate2, Panel panel)
        {
            this.gate1 = gate1;
            this.gate2 = gate2;
            xPos = 0;
            yPos = 0;
            Sheetpanel = panel;
        }

        //Properties:
        public Color Color
        {
            get { return color; }
            set { this.color = value; }
        }

        public Gate Gate1
        {
            get { return gate1; }
            set { this.gate1 = value; }
        }

        public Gate Gate2
        {
            get { return gate2; }
            set { this.gate2 = value; }
        }

        public int XPos
        {
            get { return xPos; }
            set { this.xPos = value; }
        }

        public int YPos
        {
            get { return yPos; }
            set { this.yPos = value; }
        }


        //Methods:

        /// <summary>
        /// description of draw connection that the connection is going to be drawn on the grid depending on 
        /// the x1 and y1 coordinates of the first gate (output) and the x2 and y2 coordinates of the second gate (input)  
        /// </summary>
        /// <param name="x1">the x cordinate of the first gate</param>
        /// <param name="y1">the y cordinate of the first gate</param>
        /// <param name="x2">the x cordinate of the second gate</param>
        /// <param name="y2">the y cordinate of the second gate</param>
        public virtual void drawConnection(int eX, int eY, LineShape L, ShapeContainer C)
        {
            line = L;
            canvas = C;
            if (gate1.Location_x < gate2.Location_x)
            {
                xPos = eX;
                yPos = eY;
                canvas.Parent = Sheetpanel;
                line.Parent = canvas;
                if (gate2 is Not || gate2 is Sink)
                {
                    line.X1 = gate1.Location_x + 100;
                    line.X2 = gate2.Location_x;
                    line.Y1 = gate1.Location_y + 30;
                    line.Y2 = gate2.Location_y + 30;
                }

                else
                {

                    if (eY < 30)
                    {
                        line.X1 = gate1.Location_x + 100;
                        line.X2 = gate2.Location_x;
                        line.Y1 = gate1.Location_y + 30;
                        line.Y2 = gate2.Location_y + 11;
                    }
                    else
                    {
                        line.X1 = gate1.Location_x + 100;
                        line.X2 = gate2.Location_x;
                        line.Y1 = gate1.Location_y + 30;
                        line.Y2 = gate2.Location_y + 49;
                    }
                }
                gate1.FreeOutput = false;
            }

        }

        public void DeleteConnection()
        {
            canvas.Shapes.Remove(line);
            xPos = 0;
            yPos = 0;
            gate1.FreeOutput = true;
            if (gate2 is And)
            {
                And temp = (And)gate2;
                if (line.X2 == temp.Location_x && line.Y2 == temp.Location_y + 11)
                {
                    temp.Input1 = null;
                    temp.truthTable();
                }
                else
                {
                    temp.Input2 = null;
                    temp.truthTable();
                }
            }
            else if (gate2 is Or)
            {
                Or temp = (Or)gate2;
                if (line.X2 == temp.Location_x && line.Y2 == temp.Location_y + 11)
                {
                    temp.Input1 = null;
                }
                else
                {
                    temp.Input2 = null;
                }
            }
            else if (gate2 is Not)
            {
                Not temp = (Not)gate2;
            }
            else if (gate2 is Sink)
            {
                Sink temp = (Sink)gate2;
                temp.Input = null;
            }
            gate2.truthTable();
        }
    }
}


