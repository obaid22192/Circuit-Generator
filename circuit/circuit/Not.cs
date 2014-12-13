using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace circuit
{
    [Serializable()]
    public class Not : Gate
    {
        //Data Members:
        private Gate input; //the value of a not gate

        //Constructor:
        public Not(int x, int y, string type, Panel panel)
            : base(x, y, type)
        {
            if (Location_x < 107)
            {
                Location_x = 110;
            }
            input = null;
            Output = 0;
            Image = circuit.Properties.Resources.not;
        }
        //Properties:
        public Gate Input
        {
            get { return input; }
            set { input = value; }
        }

        //Methods:

        /// <summary>
        /// description of drop gate that drop a not gate into the grid
        /// </summary>
        public override void dropGate(PictureBox pb)
        {
            pb.Image = Image;
        }

        
        /// <summary>
        /// description of truth table that going to be used to get the value of the output of a not gate
        /// </summary>
        public override void truthTable()
        {
            if (input.Output == 0)
            {
                base.Output = 1;
                base.RaiseEvent(base.Output);
            }
            else
            {
                base.Output = 0;
                base.RaiseEvent(base.Output);
            }
        }
    }
}


