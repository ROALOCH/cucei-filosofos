using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Filosofos
{
    public partial class Home : Form
    {
        static Semaphore[] forks = new Semaphore[5];
        Philosopher[] philosophers = new Philosopher[5];

        Random random = new Random();
        public Home()
        {
            InitializeComponent();
            InitializeSemaphores();
            InitializePhilosophers();

            BW_UpdateUI.RunWorkerAsync();
        }

        private void InitializeSemaphores()
        {
            for (int i = 0; i < 5; i++)
            {
                forks[i] = new Semaphore(1, 1);
            }
        }
        private void InitializePhilosophers()
        {
            philosophers[0] = new Philosopher(0, 4, 0, PB_Fork4, PB_Fork0, LBL_Philosopher0, forks, LB_Info);
            philosophers[1] = new Philosopher(1, 0, 1, PB_Fork0, PB_Fork1, LBL_Philosopher1, forks, LB_Info);
            philosophers[2] = new Philosopher(2, 1, 2, PB_Fork1, PB_Fork2, LBL_Philosopher2, forks, LB_Info);
            philosophers[3] = new Philosopher(3, 2, 3, PB_Fork2, PB_Fork3, LBL_Philosopher3, forks, LB_Info);
            philosophers[4] = new Philosopher(4, 3, 4, PB_Fork3, PB_Fork4, LBL_Philosopher4, forks, LB_Info);

            this.Refresh();
        }

        private void BTN_Start_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 5; i++)
            {
                new Thread(StartWorking).Start(i);
            }
        }

        private void StartWorking(object index)
        {
            int i = (int)index;

            while(philosophers[i].getMeals() < 5)
            {
                int forkOne = i;
                int forkTwo = (i == 0 ? 4 : i - 1);

                bool isForkOneAvailable = forks[forkOne].WaitOne(100);
                bool isForkTwoAvailable = forks[forkTwo].WaitOne(100);

                if(isForkOneAvailable && isForkTwoAvailable)
                {
                    int waitTime = random.Next(1, 2);

                    philosophers[i].changeState('E');
                    Thread.Sleep(waitTime * 1000);
                    philosophers[i].addMeal();
                    BW_UpdateUI.ReportProgress((i * 10) + philosophers[i].getMeals());
                    philosophers[i].changeState('W');
                }

                if (isForkOneAvailable)
                {
                    forks[forkOne].Release();
                }

                if (isForkTwoAvailable)
                {
                    forks[forkTwo].Release();
                }
            }
        }

        private void BW_UpdateUI_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int philosopher = (e.ProgressPercentage % 100) / 10;
            philosophers[philosopher].updateMeals();
        }

        private void BW_UpdateUI_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {

            }
        }
    }
}
