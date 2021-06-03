using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Filosofos
{
    class Philosopher
    {
        int id = 0;
        int meals = 0;
        char state = 'W'; // W = Waiting, E = Eating

        int forkOne, forkTwo;
        Semaphore[] forks;

        // UI //

        Label box = null;
        ListBox listBox = null;
        Image forkLeftImg = null, forkRightImg = null;
        PictureBox forkLeft = null, forkRight = null;

        Color waitingColor = Color.FromName("SkyBlue");
        Color eatingColor = Color.FromName("LimeGreen");

        public Philosopher(int id, int forkOne, int forkTwo, PictureBox forkLeft, PictureBox forkRight, Label box, Semaphore[] forks, ListBox listBox)
        {
            this.id = id;
            this.forkOne = forkOne;
            this.forkTwo = forkTwo;
            this.forkLeft = forkLeft;
            this.forkRight = forkRight;
            this.box = box;
            this.forks = forks;

            this.listBox = listBox;

            changeForksStateUI(false);
            changePhilosopherBoxStateUI(waitingColor);
        }

        public int getID() => id;
        public int getMeals() => meals;
        public void addMeal()
        {
            meals = meals + 1;
        }
        public char getState() => state;
        public void setState(char state)
        {
            this.state = state;
        }

        // UI //
        public void changeState(char state)
        {
            // W = Waiting, E = Eating

            switch (state)
            {
                case 'W':
                    changeForksStateUI(false);
                    changePhilosopherBoxStateUI(waitingColor);
                    break;
                case 'E':
                    changeForksStateUI(true);
                    changePhilosopherBoxStateUI(eatingColor);
                    break;
                default:
                    break;
            }
        }

        private void changeForksStateUI(bool active)
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
        private void changePhilosopherBoxStateUI(Color color)
        {
            box.ForeColor = color;
        }
        public void updateMeals()
        {
            listBox.Items[id] = ($"Filósofo {id + 1} Comidas: {meals}");
        }
    }
}
