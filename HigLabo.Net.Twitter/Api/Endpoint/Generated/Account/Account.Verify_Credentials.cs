using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HigLabo.Net.Twitter.Api_1_1
{
    public partial class Account
    {
        public partial class Verify_Credentials
        {
            public class Command : TwitterCommand
            {
                public Boolean? include_entities { get; set; }
                public Boolean? skip_status { get; set; }

                public override String GetApiEndpointUrl()
                {
                    return "https://api.twitter.com/1.1/account/verify_credentials.json";
                }
                public override HttpMethodName GetHttpMethodName()
                {
                    return HttpMethodName.Get;
                }
            }
            public class Result
            {
                [JsonProperty("contributors_enabled")]
                public Boolean contributors_enabled { get; set; }
                [JsonProperty("created_at")]
                public String created_at { get; set; }
                [JsonProperty("default_profile")]
                public Boolean default_profile { get; set; }
                [JsonProperty("default_profile_image")]
                public Boolean default_profile_image { get; set; }
                [JsonProperty("description")]
                public String description { get; set; }
                [JsonProperty("favourites_count")]
                public Int64 favourites_count { get; set; }
                [JsonProperty("follow_request_sent")]
                public String follow_request_sent { get; set; }
                [JsonProperty("followers_count")]
                public Int64 followers_count { get; set; }
                [JsonProperty("following")]
                public String following { get; set; }
                [JsonProperty("friends_count")]
                public Int64 friends_count { get; set; }
                [JsonProperty("geo_enabled")]
                public Boolean geo_enabled { get; set; }
                [JsonProperty("id")]
                public Int64 id { get; set; }
                [JsonProperty("id_str")]
                public String id_str { get; set; }
                [JsonProperty("is_translator")]
                public Boolean is_translator { get; set; }
                [JsonProperty("lang")]
                public String lang { get; set; }
                [JsonProperty("listed_count")]
                public Int64 listed_count { get; set; }
                [JsonProperty("location")]
                public String location { get; set; }
                [JsonProperty("name")]
                public String name { get; set; }
                [JsonProperty("notifications")]
                public String notifications { get; set; }
                [JsonProperty("profile_background_color")]
                public String profile_background_color { get; set; }
                [JsonProperty("profile_background_image_url")]
                public String profile_background_image_url { get; set; }
                [JsonProperty("profile_background_image_url_https")]
                public String profile_background_image_url_https { get; set; }
                [JsonProperty("profile_background_tile")]
                public Boolean profile_background_tile { get; set; }
                [JsonProperty("profile_image_url")]
                public String profile_image_url { get; set; }
                [JsonProperty("profile_image_url_https")]
                public String profile_image_url_https { get; set; }
                [JsonProperty("profile_link_color")]
                public String profile_link_color { get; set; }
                [JsonProperty("profile_sidebar_border_color")]
                public String profile_sidebar_border_color { get; set; }
                [JsonProperty("profile_sidebar_fill_color")]
                public String profile_sidebar_fill_color { get; set; }
                [JsonProperty("profile_text_color")]
                public String profile_text_color { get; set; }
                [JsonProperty("profile_use_background_image")]
                public Boolean profile_use_background_image { get; set; }
                [JsonProperty("protected")]
                public Boolean @protected { get; set; }
                [JsonProperty("screen_name")]
                public String screen_name { get; set; }
                [JsonProperty("show_all_inline_media")]
                public Boolean show_all_inline_media { get; set; }
                [JsonProperty("status")]
                public Statu status { get; set; }
                [JsonProperty("statuses_count")]
                public Int64 statuses_count { get; set; }
                [JsonProperty("time_zone")]
                public String time_zone { get; set; }
                [JsonProperty("url")]
                public String url { get; set; }
                [JsonProperty("utc_offset")]
                public Int64 utc_offset { get; set; }
                [JsonProperty("verified")]
                public Boolean verified { get; set; }

                public class Statu
                {
                    [JsonProperty("contributors")]
                    public String contributors { get; set; }
                    [JsonProperty("coordinates")]
                    public Coordinate coordinates { get; set; }
                    [JsonProperty("created_at")]
                    public String created_at { get; set; }
                    [JsonProperty("favorited")]
                    public Boolean favorited { get; set; }
                    [JsonProperty("geo")]
                    public Geo geo { get; set; }
                    [JsonProperty("id")]
                    public Int64 id { get; set; }
                    [JsonProperty("id_str")]
                    public String id_str { get; set; }
                    [JsonProperty("in_reply_to_screen_name")]
                    public String in_reply_to_screen_name { get; set; }
                    [JsonProperty("in_reply_to_status_id")]
                    public Int64 in_reply_to_status_id { get; set; }
                    [JsonProperty("in_reply_to_status_id_str")]
                    public String in_reply_to_status_id_str { get; set; }
                    [JsonProperty("in_reply_to_user_id")]
                    public Int64 in_reply_to_user_id { get; set; }
                    [JsonProperty("in_reply_to_user_id_str")]
                    public String in_reply_to_user_id_str { get; set; }
                    [JsonProperty("place")]
                    public Place place { get; set; }
                    [JsonProperty("retweet_count")]
                    public Int64 retweet_count { get; set; }
                    [JsonProperty("retweeted")]
                    public Boolean retweeted { get; set; }
                    [JsonProperty("source")]
                    public String source { get; set; }
                    [JsonProperty("text")]
                    public String text { get; set; }
                    [JsonProperty("truncated")]
                    public Boolean truncated { get; set; }

                    public class Coordinate
                    {
                        [JsonProperty("coordinates")]
                        public Double[] coordinates { get; set; }
                        [JsonProperty("type")]
                        public String type { get; set; }
                    }
                    public class Geo
                    {
                        [JsonProperty("coordinates")]
                        public Double[] coordinates { get; set; }
                        [JsonProperty("type")]
                        public String type { get; set; }
                    }
                    public class Place
                    {
                        [JsonProperty("attributes")]
                        public Attribute attributes { get; set; }
                        [JsonProperty("bounding_box")]
                        public Bounding_Box bounding_box { get; set; }
                        [JsonProperty("country")]
                        public String country { get; set; }
                        [JsonProperty("country_code")]
                        public String country_code { get; set; }
                        [JsonProperty("full_name")]
                        public String full_name { get; set; }
                        [JsonProperty("id")]
                        public String id { get; set; }
                        [JsonProperty("name")]
                        public String name { get; set; }
                        [JsonProperty("place_type")]
                        public String place_type { get; set; }
                        [JsonProperty("url")]
                        public String url { get; set; }

                        public class Attribute
                        {
                        }
                        public class Bounding_Box
                        {
                            [JsonProperty("coordinates")]
                            public Double[][][] coordinates { get; set; }
                            [JsonProperty("type")]
                            public String type { get; set; }
                        }
                    }
                }
            }
        }
    }
}
