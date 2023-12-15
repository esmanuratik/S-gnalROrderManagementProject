namespace SıgnalRApi.DAL.Entities
{
    /// <summary>
    /// Öne Çıkanlar
    /// 3 kısımdan oluşacak onun için ayrı ayrı 3 tane title ve description oluşturdum.
    /// </summary>
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string Title3 { get; set; }
        public string Description3 { get; set; }
    }
}
