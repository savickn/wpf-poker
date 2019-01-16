using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PokerCalculator {
    public sealed class SeatDataTemplateSelector : DataTemplateSelector {

        public DataTemplate OccupiedSeatDataTemplate { get; set; }

        public DataTemplate EmptySeatDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            var i = (Seat) item;
            if (i.isEmpty()) {
                return EmptySeatDataTemplate;
            } else {
                return OccupiedSeatDataTemplate;
            }
        }
    }
}
