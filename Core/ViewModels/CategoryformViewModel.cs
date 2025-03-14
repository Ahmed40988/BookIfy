namespace Bookify.Wep.Core.ViewModels
{
    public class CategoryformViewModel
    {
        public int Id { get; set; }
        [MaxLength(100,ErrorMessage ="Max Length can not more than 30 characters")]
        public string Name { get; set; } = null!;
    }
}
