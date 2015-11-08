using System;

namespace PlaytagonTest.Web.Models
{
    public class Character
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int Health { get; set; }

        public virtual int Mana { get; set; }

        public virtual int Level { get; set; }

        public virtual int Gold { get; set; }

        public virtual bool IsImmortal { get; set; }
    }
}