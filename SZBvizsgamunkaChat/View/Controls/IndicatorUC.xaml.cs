using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SZBvizsgamunkaChat.View.Controls
{
    /// <summary>
    /// Interaction logic for IndicatorUC.xaml
    /// </summary>
    public partial class IndicatorUC : UserControl
    {
        public IndicatorUC()
        {
            InitializeComponent();
        }

        SolidColorBrush green= (SolidColorBrush)new BrushConverter().ConvertFromString("#FF96CBA4");
        SolidColorBrush gray= (SolidColorBrush)new BrushConverter().ConvertFromString("#FFEFEFEF");
        SolidColorBrush red= (SolidColorBrush)new BrushConverter().ConvertFromString("#FFE2747F");

        //kattintáskor az aktuális oszlopot kijelöli
        private void Grid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            int index = Convert.ToInt32((sender as Grid).Tag);
            if ((sender as Grid).Cursor==Cursors.Hand) SelectElement(index, green);
        }

        private int GetMaxGreenStroke()
        {
            for (int i = formContent.Children.Count-1; i >=0 ; i--) if (i % 2 == 0 && ((formContent.Children[i] as Grid).Children[1] as Rectangle).Stroke == green) return Convert.ToInt32((formContent.Children[i] as Grid).Tag);
            return -1;
        }

        /// <summary>
        /// amikor katntok a karikára
        /// TODO: alaphelyzetbe allitja szövegeklet, kijelöli az aktuális szöveget és a felette lévő karikat a belső karikat zöldre festi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectElement(int tagIndex, SolidColorBrush fill)
        {
            keszCntContr.Content =(fill==red)?"Hiba": "Kész";
            //unselect texts
            for (int i = 0; i < textContent.Children.Count; i++) ((textContent.Children[i] as Grid).Children[1] as Grid).Visibility = Visibility.Collapsed;
            //select text
            ((textContent.Children[tagIndex] as Grid).Children[1] as Grid).Visibility = Visibility.Visible;

            //select form
            for (int i = 0; i < formContent.Children.Count; i++)
            {
                if (Convert.ToInt32((formContent.Children[i] as Grid).Tag) <= tagIndex)
                {
                    if (i % 2 == 0)
                    {
                        //kor
                        ((formContent.Children[i] as Grid).Children[0] as Rectangle).Fill = fill;
                        ((formContent.Children[i] as Grid).Children[1] as Rectangle).Stroke = (fill == gray) ? Brushes.White : fill; //ha a fill a szurke akk feherre állítja (RESET)
                    }
                    else ((formContent.Children[i] as Grid).Children[0] as Grid).Background = fill; //vonal
                }
                if (i % 2 == 0) (formContent.Children[i] as Grid).Cursor = (Convert.ToInt32((formContent.Children[i] as Grid).Tag) <= GetMaxGreenStroke() && tagIndex != 2) ? Cursors.Hand : Cursors.Arrow; //kurzort beallitjuk
            }
            indicator.DataContext = (fill == red) ? 3 : tagIndex;

        }

        public  void Tovabb1()
        {
            SelectElement(1,green); //egyig mehet a kattingatás
        }

        public void Tovabb2()
        {
            SelectElement(2, green); //nem kattinthat( a regisztráció befejeződött)
        }

        public int GetSelectedRound()
        {
            for (int i = 0; i < textContent.Children.Count; i++) if (((textContent.Children[i] as Grid).Children[1] as Grid).Visibility == Visibility.Visible) return i;
            return -1;
        }

        public void Reset()
        {
            SelectElement(0, green);
        }

        public void Error()
        {
            SelectElement(2, red);
        }
    }
}
