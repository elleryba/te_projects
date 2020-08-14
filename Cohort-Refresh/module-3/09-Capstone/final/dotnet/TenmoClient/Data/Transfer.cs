using System.ComponentModel.DataAnnotations;

namespace TenmoClient.Data
{
    public class Transfer
    {
        public int TransferId { get; set; }
        [Required]
        public TransferType TransferType { get; set; }
        [Required]
        public TransferStatus TransferStatus { get; set; }
        [Required]
        public Account AccountFrom { get; set; }
        [Required]
        public Account AccountTo { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }

    public class NewTransfer
    {
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        public decimal Amount { get; set; }
        public TransferType TransferType { get; set; }
    }

    public enum TransferType
    {
        Request = 1,
        Send = 2
    }

    public enum TransferStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}
