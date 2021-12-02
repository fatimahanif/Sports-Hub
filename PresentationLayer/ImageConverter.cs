using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DAL;
using BussinessLogicLayer;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace PresentationLayer
{
    [ValueConversion(typeof(ProductCategory), typeof(BitmapImage))]
    public class ImageConverter : IValueConverter
    {
        public static ImageConverter imageConverter = new ImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "images/badminton_set.jpg";

            switch ((int)value)
            {
                case 1:
                    image = "images/badminton_racket.jpg";
                   // Console.WriteLine("badminton");
                    break;

                case 2:
                    image = "images/badminton_shuttlecock.jpg";
                    break;

                case 3:
                    image = "images/badminton_net.jpg";
                    break;
                case 4:
                    image = "images/badminton_set.jpg";
                    break;
                case 5:
                    image = "images/tennis_racket.jpg";
                    break;
                case 6:
                    image = "images/tennis_ball.png";
                    break;
                case 7:
                    image = "images/tennis_net.jpg";
                    break;
                case 8:
                    image = "images/tennis_set.jpg";
                    break;
                case 9:
                    image = "images/tabletennis_racket.jpg";
                    break;
                case 10:
                    image = "images/tabletennis_ball.jpg";
                    break;
                case 11:
                    image = "images/tabletennis_net.jpg";
                    break;
                case 12:
                    image = "images/tabletennis_set.jpg";
                    break;
                case 13:
                    image = "images/tabletennis_table.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
