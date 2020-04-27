using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using RestaurantDP.Decorator;

namespace RestaurantDP.Visitor
{
    class ClientReport : IVisitor
    {
        private float _totalPrice;

        public float TotalPrice { get => _totalPrice; }

        public void Visit(Order order)
        {
            _totalPrice = order.Products.Sum(burger => burger.Price);
        }
    }
}
