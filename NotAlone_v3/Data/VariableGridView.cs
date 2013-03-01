using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NotAlone_v3.Data
{
    public class VariableGridView : GridView
    {
        protected override void PrepareContainerForItemOverride(
        DependencyObject element, object item)
        {
            var menuTilesItem = item as Data.MenuTiles;

            if (menuTilesItem != null)
            {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty,
                menuTilesItem.HorizontalSize);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty,
                menuTilesItem.VerticalSize);
            }

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}
