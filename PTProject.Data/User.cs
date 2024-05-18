using System.Collections.Generic;

namespace PTProject.Data
{
    public partial class User : IUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<Events> Events { get; set; }
    }
}
