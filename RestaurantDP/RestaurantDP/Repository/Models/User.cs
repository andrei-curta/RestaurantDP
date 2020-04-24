using RestaurantDP.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace Repository
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name
        {
            get;
            set;
        }


        public EOfferType OfferType
        {
            get;
            set;
        }

        public User()
        {
                
        }

        public User(string name, EOfferType offerType = EOfferType.Regular)
        {
            Name = name;
            OfferType = offerType;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}";
        }

        public override bool Equals(object obj)
        {
            return Id == ((User)obj).Id;
        }
    }
}
