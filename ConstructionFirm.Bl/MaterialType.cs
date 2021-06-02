namespace ConstructionFirm.Bl
{
    public class MaterialType
    {
        public string Body { get; set; }

        public decimal Price { get; set; }
        
        public override string ToString()
        {
            return $"{Body} - {Price}$";
        }

    }
}