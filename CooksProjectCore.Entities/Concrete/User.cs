using CooksProjectCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CooksProjectCore.Entities.Concrete
{
    public class User:IEntity
    {
        public User()
        {
            this.SocialMedia = new SocialMedia();
        }
        public int ID{ get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Email{ get; set; }
        public string ImageLocation{ get; set; }
        public DateTime AddedDate{ get; set; }
        public Nullable<DateTime> ModifiedDate{ get; set; }
        public string Job{ get; set; }
        [DataType(DataType.Password)]
        public byte[] PasswordHash{ get; set; }
        [DataType(DataType.Password)]
        public byte[] PasswordSalt{ get; set; }
        public virtual SocialMedia SocialMedia{ get; set; }
    }
}
