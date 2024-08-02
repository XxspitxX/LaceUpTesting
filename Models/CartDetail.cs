using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Models
{

    public partial class CartDetail : ObservableObject
    {
        public ObjectId? id { get; set; }

        [ObservableProperty]
        private Product? _product;
        [ObservableProperty]
        private int? _quantity;

    }
}
