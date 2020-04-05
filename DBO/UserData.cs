using System;
using System.Collections.Generic;

namespace record_keep_api.DBO
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class UserData
    {
        public UserData()
        {
            Collection = new HashSet<Collection>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Collection> Collection { get; set; }
    }
}