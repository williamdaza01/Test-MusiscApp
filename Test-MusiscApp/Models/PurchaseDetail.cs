using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test_MusiscApp.Models;

namespace Test_MusiscApp.Models
{
    public class PurchaseDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Client_Id { get; set; }

        public int Album_Id { get; set; }

        public double Total { get; set; }

        // Relación con Client
        public Cliente Client { get; set; }

        // Relación con AlbumSet
        public Album Album { get; set; }
    }
}
