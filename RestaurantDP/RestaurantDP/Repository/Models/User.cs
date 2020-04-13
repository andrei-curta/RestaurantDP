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
        public string Type
        {
            get;
            set;
        }

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

        [Required]
        [StringLength(50, MinimumLength = 7)]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}";
        }


    }
}
