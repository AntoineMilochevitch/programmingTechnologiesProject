namespace PTProject.Presentations.Models
{
    public class ProcessState
    {
        public int ProcessStateId { get; set; }
        public virtual int UserId { get; set; }
        public virtual int GoodId { get; set; }
        public string Description { get; set; }
    }
}
