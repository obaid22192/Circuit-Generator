﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace circuit
{
    [Serializable()]
    public class Sink : Gate
    {
        //Data Members:
        private Gate input; //the value of a sink gate
        [NonSerialized()] PictureBox sinkPic;

        //Constructor:
        public Sink(int x, int y, string type, Panel panel)
            : base(x, y, type)
        {
            if (Location_x < 107)
            {
                Location_x = 110;
            }
            input = null;

            Image = circuit.Properties.Resources.offbulff;
        }

        //Properties:
        public Gate Input
        {
            get { return input; }
            set { this.input = value; }
        }


        //Methods:

        /// <summary>
        /// description of drop gate that drop a sink gate into the grid
        /// </summary>
        public override void dropGate(PictureBox pb)
        {

            sinkPic = pb;
            sinkPic.Image = Image;
        }


        /// <summary>
        /// description of truth table that going to be used to get the value of the output of a sink gate
        /// </summary>
        public override void truthTable()
        {
            if (input != null)
            {
                base.Output = input.Output;
            }
            else
            {
                base.Output = 0;
            }
            if (base.Output == 1)
            {
                sinkPic.Image = circuit.Properties.Resources.Onbulb;

            }
            else
            {
                sinkPic.Image = Image;
            }
        }
    }
}

