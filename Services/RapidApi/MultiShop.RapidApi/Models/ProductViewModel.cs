namespace MultiShop.RapidApi.Models
{
    public class ProductViewModel
    {

            public string status { get; set; }
            public string request_id { get; set; }
            public Datum[] data { get; set; }
        

        public class Datum
        {
            public string product_id { get; set; }
            public string product_title { get; set; }
            public string product_description { get; set; }
            public string[] product_photos { get; set; }
            public Product_Attributes product_attributes { get; set; }
            public float product_rating { get; set; }
            public string product_page_url { get; set; }
            public string product_offers_page_url { get; set; }
            public string product_specs_page_url { get; set; }
            public string product_reviews_page_url { get; set; }
            public string product_page_url_v2 { get; set; }
            public int product_num_reviews { get; set; }
            public int product_num_offers { get; set; }
            public string[] typical_price_range { get; set; }
            public Offer offer { get; set; }
        }

        public class Product_Attributes
        {
        }

        public class Offer
        {
            public string store_name { get; set; }
            public object store_rating { get; set; }
            public string offer_page_url { get; set; }
            public object store_review_count { get; set; }
            public string store_reviews_page_url { get; set; }
            public string price { get; set; }
            public string shipping { get; set; }
            public bool on_sale { get; set; }
            public object original_price { get; set; }
            public string product_condition { get; set; }
            public string payment_methods { get; set; }
            public string coupon_discount_percent { get; set; }
        }

    }
}
