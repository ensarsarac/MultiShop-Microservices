namespace MultiShop.WebUI.Settings
{
    public class ServiceApiSettings
    {
        public string OcelotUrl { get; set; }
        public string IdentityServerUrl { get; set; }
        public ServiceApi CatalogUrl { get; set; }
        public ServiceApi ImagesUrl { get; set; }
        public ServiceApi DiscountUrl { get; set; }
        public ServiceApi OrderUrl { get; set; }
        public ServiceApi CargoUrl { get; set; }
        public ServiceApi BasketUrl { get; set; }
        public ServiceApi PaymentUrl { get; set; }
        public ServiceApi CommentUrl { get; set; }
        public ServiceApi MessageUrl { get; set; }
    }
    public class ServiceApi
    {
        public string Path { get; set; }
    }
}
