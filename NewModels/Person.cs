using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace iBanking.NewModels
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        public Person() 
        {
            this.Email = string.Empty;
            this.Name = string.Empty;
            this.Password = string.Empty;
            this.Id = 0;
            this.CreatedAt = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}