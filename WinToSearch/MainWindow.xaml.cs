using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinToSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            
            this.Left = (screenWidth - this.Width) / 2;
            this.Top = screenHeight + 50;
            this.Opacity = 0.7;
            
            this.Show();

            var moveAnimation = new DoubleAnimation
            {
                To = screenHeight - this.Height - 70,
                Duration = TimeSpan.FromMilliseconds(800),
                EasingFunction = new CubicEase 
                { 
                    EasingMode = EasingMode.EaseOut 
                },
                BeginTime = TimeSpan.FromMilliseconds(50)
            };

            var scaleYAnimation = new DoubleAnimation
            {
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(600),
                EasingFunction = new ElasticEase 
                { 
                    Oscillations = 1,
                    Springiness = 4,
                    EasingMode = EasingMode.EaseOut
                }
            };

            var fadeInAnimation = new DoubleAnimation
            {
                To = 1.0,
                Duration = TimeSpan.FromMilliseconds(400),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            this.BeginAnimation(Window.TopProperty, moveAnimation);
            var scaleTransform = (ScaleTransform)MainBorder.RenderTransform;
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleYAnimation);
            this.BeginAnimation(Window.OpacityProperty, fadeInAnimation);
        }
    }
}