using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAlone_v3.Data
{
    public class MenuTiles
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        private int _horizontalSize = 1;
        public int HorizontalSize
        {
            get { return _horizontalSize; }
            set { _horizontalSize = value; }
        }

        private int _verticalSize = 1;
        public int VerticalSize
        {
            get { return _verticalSize; }
            set { _verticalSize = value; }
        }
    }
}
