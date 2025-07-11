using System.ComponentModel.DataAnnotations.Schema;

namespace JPT.Models.Entities
{
    public class Faq
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("question")]
        public string Question { get; set; }

        [Column("answer")]
        public string Answer { get; set; }

        [Column("display_order")]
        public int DisplayOrder { get; set; }
    }
}