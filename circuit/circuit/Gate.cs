using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace circuit
{
    [Serializable()]
    public abstract class Gate
    {
        public delegate void GateEventHandler(Gate semder, int changedoutput);

        public event GateEventHandler outputchanged;

        //Data Members:
        private int location_x; //the x upper left corner of a certain gate
        private int location_y; //the y upper left corner of a certain gate
        private int output; // the result of a certain gate
        private Image image; //to store the shape of the gate
        private bool freeOutput = true; //to check whether the output of a certain gate is available or not  
        private string type; //to store the type of the gate 

        //Constructor:
        public Gate(int x, int y, string type)
        {
            this.location_x = x;
            this.location_y = y;
            this.type = type;
        }

        //properties:
        public int Location_x
        {
            get { return location_x; }
            set { this.location_x = value; }
        }

        public int Location_y
        {
            get { return location_y; }
            set { this.location_y = value; }
        }

        public int Output
        {
            get { return output; }
            set { this.output = value; }
        }

        public Image Image
        {
            get { return image; }
            set { this.image = value; }
        }

        public bool FreeOutput
        {
            get { return freeOutput; }
            set { this.freeOutput = value; }
        }
        //Methods:

        /// <summary>
        /// description of drop gate that drop a certain gate into the grid
        /// </summary>
        public abstract void dropGate(PictureBox pb);

        /// <summary>
        /// description of truth table that going to be used to get the value of the output of a certain gate
        /// </summary>
        public abstract void truthTable();
        

        public void RaiseEvent(int changedoutput)
        {
            if (outputchanged != null)
            {
                this.outputchanged(this, changedoutput);
            }
        }
    }
}


