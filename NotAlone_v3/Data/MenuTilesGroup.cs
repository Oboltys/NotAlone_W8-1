using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAlone_v3.Data
{
    public class MenuTilesGroup
    {
        public string GroupName { get; set; }
        public ObservableCollection<Data.MenuTiles> MenuTiles { get; set; }

        public MenuTilesGroup()
        {
            MenuTiles = new ObservableCollection<Data.MenuTiles>();
        }
    }
}
