namespace Client.DTO.Read
{
    public class TightsDTO
    {
  
        public int Id { get; set; }

        public string Size { get; set; }
        
        public string Date { get; set; }

        public SupplierDTO Supplier { get; set; }
        
        public BuyerDTO Buyer{ get; set; }
    }
}