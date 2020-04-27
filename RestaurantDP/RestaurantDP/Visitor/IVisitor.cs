using Repository;
using RestaurantDP.Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP.Visitor
{
    public interface IVisitor
    {
        void Visit(Order order);
    }
}
