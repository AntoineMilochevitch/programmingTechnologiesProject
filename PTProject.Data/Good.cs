namespace PTProject.Data
{
    public partial class Good : IGood
    {
        public int GoodId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }
}
