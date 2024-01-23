using System.ComponentModel.DataAnnotations;

namespace StoredProcedure_Crud.Models
{
    public class StoredModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; }
    }
}
