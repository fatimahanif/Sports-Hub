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

            switch ((ProductCategory)value)
            {
                case ProductCategory.Badminton:
                    image = "images/badminton_set.jpg";
                    Console.WriteLine("badminton");
                    break;

                case ProductCategory.TableTennis:
                    image = "images/tabletennis_set.jpg";
                    break;

                case ProductCategory.Tennis:
                    image = "images/tennis_set.jpg";
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
