namespace PTProject.Data
{
    public class User : IUser
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public List<Events>? Events { get; set; }
    }
}