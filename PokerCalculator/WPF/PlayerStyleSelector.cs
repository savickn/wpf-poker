using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PokerCalculator
{
    public class PlayerStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container) {


            Style st = new Style();
            st.TargetType = typeof(ListViewItem);
            return st;

            /*Style st = new Style();
            st.TargetType = typeof(ListViewItem);
            Setter backGroundSetter = new Setter();
            backGroundSetter.Property = ListViewItem.BackgroundProperty;
            ListView listView =
                ItemsControl.ItemsControlFromItemContainer(container)
                  as ListView;
            int index =
                listView.ItemContainerGenerator.IndexFromContainer(container);
            if (index % 2 == 0) {
                backGroundSetter.Value = Brushes.LightBlue;
            } else {
                backGroundSetter.Value = Brushes.Beige;
            }
            st.Setters.Add(backGroundSetter);
            return st;*/
        }

    }
}
