using RestaurantDP.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP.Visitor
{
    public class Order : IVisitable
    {
        private List<BurgerDecorator> _products = new List<BurgerDecorator>();

        public List<BurgerDecorator> Products { get => _products; }

        public void AddProduct(BurgerDecorator product)
        {
            _products.Add(product);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
