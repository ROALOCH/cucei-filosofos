using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filosofos
{
    class Philosopher
    {
        int id = 0;
        char state = 'T'; // T = Thinking, W = Waiting, E = Eating

        // UI //

        Label box = null;
        Image forkLeftImg = null, forkRightImg = null;
        PictureBox forkLeft = null, forkRight = null;

        Color thinkingColor = Color.FromName("DeepPink");
        Color waitingColor = Color.FromName("SkyBlue");
        Color eatingColor = Color.FromName("LimeGreen");

        public Philosopher(int id, PictureBox forkLeft, PictureBox forkRight, Label box)
        {
            this.id = id;
            this.forkLeft = forkLeft;
            this.forkRight = forkRight;
            this.box = box;
        }

        public int getID() => id;
        public char getState() => state;
        public void setState(char state)
        {
            this.state = state;
        }
        public void changeState(char state)
        {
            // T = Thinking, W = Waiting, E = Eating

            switch (state)
            {
                case 'T':
                    changeForksState(false);
                    changePhilosopherBoxState(thinkingColor);
                    break;
                case 'W':
                    changeForksState(false);
                    changePhilosopherBoxState(waitingColor);
                    break;
                case 'E':
                    changeForksState(true);
                    changePhilosopherBoxState(eatingColor);
                    break;
                default:
                    break;
            }
        }

        private void changeForksState(bool active)
        {

            switch (id)
            {
                case 0:
                    forkLeftImg = active ? Filosofos.Properties.Resources.Fork4A : Filosofos.Properties.Resources.Fork4;
                    forkRightImg = active ? Filosofos.Properties.Resources.Fork0A : Filosofos.Properties.Resources.Fork0;
                    break;
                case 1:
                    forkLeftImg = active ? Filosofos.Properties.Resources.Fork0A : Filosofos.Properties.Resources.Fork0;
                    forkRightImg = active ? Filosofos.Properties.Resources.Fork1A : Filosofos.Properties.Resources.Fork1;
                    break;
                case 2:
                    forkLeftImg = active ? Filosofos.Properties.Resources.Fork1A : Filosofos.Properties.Resources.Fork1;
                    forkRightImg = active ? Filosofos.Properties.Resources.Fork2A : Filosofos.Properties.Resources.Fork2;
                    break;
                case 3:
                    forkLeftImg = active ? Filosofos.Properties.Resources.Fork2A : Filosofos.Properties.Resources.Fork2;
                    forkRightImg = active ? Filosofos.Properties.Resources.Fork3A : Filosofos.Properties.Resources.Fork3;
                    break;
                case 4:
                    forkLeftImg = active ? Filosofos.Properties.Resources.Fork3A : Filosofos.Properties.Resources.Fork3;
                    forkRightImg = active ? Filosofos.Properties.Resources.Fork4A : Filosofos.Properties.Resources.Fork4;
                    break;
            }

            this.forkLeft.Image = forkLeftImg;
            this.forkRight.Image = forkRightImg;            
        }
        private void changePhilosopherBoxState(Color color)
        {
            box.ForeColor = color;
        }
    }
}
