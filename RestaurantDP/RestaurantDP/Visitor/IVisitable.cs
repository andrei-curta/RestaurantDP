using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantDP.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
