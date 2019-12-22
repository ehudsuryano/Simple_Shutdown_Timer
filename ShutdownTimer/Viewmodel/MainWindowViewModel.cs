using ShutdownTimer.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace ShutdownTimer.Viewmodel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _timer;
        private string _hoursInput;
        private string _minutesInput;
        private DispatcherTimer timer;
        private DispatcherTimer timerdisply;
        private DateTime startTime;
        private TimeSpan remaining;
        private ICommand _startCommand;
        private ICommand _pauseCommand;
        private ICommand _moreCommand;
        private ICommand _lessCommand;
        private ICommand _m5Command;
        private ICommand _m10Command;
        private ICommand _m15Command;
        private ICommand _m20Command;
        private ICommand _m30Command;
        private ICommand _m40Command;
        private ICommand _stopCommand;
        private bool isActive;

        public MainWindowViewModel()
        {
            timerdisply = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 100),
            };
            timerdisply.Tick += TimerDisplay_Tick;

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0),
            };
            timer.Tick += Timer_Tick;
        }

        public ICommand MoreCommand
        {
            get
            {
                return _moreCommand ?? (_moreCommand = new CommandHandler(() => More(), true));
            }
            set
            {

            }
        }

        public ICommand LessCommand
        {
            get
            {
                return _lessCommand ?? (_lessCommand = new CommandHandler(() => Less(), true));
            }
            set
            {

            }
        }

        public ICommand PauseCommand
        {
            get
            {
                return _pauseCommand ?? (_pauseCommand = new CommandHandler(() => Pause(), true));
            }
            set
            {

            }
        }

        public ICommand StartCommand
        {
            get
            {
                return _startCommand ?? (_startCommand = new CommandHandler(() => Start(), true));
            }
            set
            {

            }
        }

        public ICommand M5Command
        {
            get
            {
                return _m5Command ?? (_m5Command = new CommandHandler(() => MinutePreset(5), true));
            }
            set
            {

            }
        }

        public ICommand M10Command
        {
            get
            {
                return _m10Command ?? (_m10Command = new CommandHandler(() => MinutePreset(10), true));
            }
            set
            {

            }
        }

        public ICommand M15Command
        {
            get
            {
                return _m15Command ?? (_m15Command = new CommandHandler(() => MinutePreset(15), true));
            }
            set
            {

            }
        }

        public ICommand M20Command
        {
            get
            {
                return _m20Command ?? (_m20Command = new CommandHandler(() => MinutePreset(20), true));
            }
            set
            {

            }
        }

        public ICommand M30Command
        {
            get
            {
                return _m30Command ?? (_m30Command = new CommandHandler(() => MinutePreset(30), true));
            }
            set
            {

            }
        }

        public ICommand M40Command
        {
            get
            {
                return _m40Command ?? (_m40Command = new CommandHandler(() => MinutePreset(40), true));
            }
            set
            {

            }
        }

        public ICommand StopCommand
        {
            get
            {
                return _stopCommand ?? (_stopCommand = new CommandHandler(() => Stop(), true));
            }
            set
            {

            }
        }

        private void Stop()
        {
            timerdisply.Stop();
            timer.Stop();
        }

        private void MinutePreset(int minutes)
        {           
            MinutesInput = minutes.ToString();
            Start();
        }

        private void More()
        {
            int.TryParse(MinutesInput, out int min);
            if (min<=0)
            {
                min++;
                MinutesInput = min.ToString();
            }
            else
            {
                min++;
                MinutesInput = min.ToString();
            }
        }

        private void Less()
        {
            int.TryParse(MinutesInput, out int min);
            if (min > 0)
            {
                min--;
                MinutesInput = min.ToString();
            }            
        }
        
        private void Pause()
        {
            if (isActive ==true)
            {
                if (timer.IsEnabled == true)
                {
                    timerdisply.Stop();
                    timer.Stop();
                    return;
                }
                if (timer.IsEnabled == false)
                {
                    this.startTime = DateTime.Now;
                    timer.Interval = remaining;
                    timer.Start();
                    timerdisply.Start();                                       
                }
            }       
        }    

        public void Start()
        {
            if ((HoursInput == "0" && MinutesInput == "0") || (HoursInput == "" && MinutesInput == "0") || (HoursInput == null && MinutesInput == "0"))
            {
                return;
            }
            try
            {
                if ((HoursInput == "0" && MinutesInput == "0") || (HoursInput == "" && MinutesInput == "0"))
                {
                    return;
                }            
                this.startTime = DateTime.Now;
                if (HoursInput == "" || HoursInput == null || int.Parse(HoursInput) < 0)
                {
                    HoursInput = "0";
                }
                timer.Interval = new TimeSpan(int.Parse(HoursInput), int.Parse(MinutesInput), 0);
                timer.Start();
                timerdisply.Start();
                isActive = true;
            }
            catch
            {

            }
        }

        public string HoursInput
        {
            get { return _hoursInput; }
            set { _hoursInput = value; OnPropertyChanged(); }
        }

        public string MinutesInput
        {
            get { return _minutesInput; }
            set { _minutesInput = value; OnPropertyChanged(); }
        }

        public string Timer
        {
            get { return _timer; }
            set { _timer = value; OnPropertyChanged(); }
        }

        private void TimerDisplay_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var difference = now - this.startTime;
            this.remaining = timer.Interval - difference;
            Timer = remaining.ToString("hh\\:mm\\:ss");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {         
            ShutDown();
        }

        private void ShutDown()
        {
           //MessageBoxResult alert = MessageBox.Show("shutdown");
           System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
        }
    } 
}
