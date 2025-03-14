namespace Bookify.Wep.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;
         public bool IsDeleted { get; set; }
        public DateTime Createdon{ get; set; }= DateTime.Now;
        public DateTime? lastupdated { get; set; }

    }
}
