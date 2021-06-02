namespace ConstructionFirm.Bl
{
    public class Material
    {
        public MaterialType MaterialType { get; set; }
        
        public int Count { get; set; }

        public decimal Price => MaterialType.Price * Count;

        public override string ToString()
        {
            return MaterialType.ToString() + "Count: " + Count + "Full Price: " + Price;
        }
    }
}