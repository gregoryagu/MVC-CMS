using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheCommLine.ViewModels
{
    using Core;

    public class ThreeColumnContent : ViewModelBase
    {
        [MapToDb]
        public Column Column1 { get; set; }

        [MapToDb]
        public Column Column2 { get; set; }

        [MapToDb]
        public Column Column3 { get; set; }

        //The number of Bootstrap Grid Columns.
        //4 is the default for each column, which gives 3 equal spacing;
        private int _gridColumns = 4;
        public int GridColumns { get { return this._gridColumns; } set { this._gridColumns = value; } }

    }
}