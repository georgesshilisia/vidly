using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.Eventbrite
{

    
    public class Rootobject
    {
        [Key]
        public int id { get; set; }
        public Result[] results { get; set; }
        public Meta meta { get; set; }
    }

    public class Meta
    {
        public string next { get; set; }
        public string method { get; set; }
        public int total_count { get; set; }
        public string link { get; set; }
        public int count { get; set; }
        public string description { get; set; }
        public string lon { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        [Key]
        public string id { get; set; }
        public long updated { get; set; }
        public string lat { get; set; }
    }

    public class Result
    {
        public int utc_offset { get; set; }
        public int rsvp_limit { get; set; }
        public int headcount { get; set; }
        public string visibility { get; set; }
        public int waitlist_count { get; set; }
        public long created { get; set; }
        public int maybe_rsvp_count { get; set; }
        public string description { get; set; }
        public string event_url { get; set; }
        public int yes_rsvp_count { get; set; }
        public string name { get; set; }
        [Key]
        public string id { get; set; }
        public long time { get; set; }
        public long updated { get; set; }
        public Group group { get; set; }
        public string status { get; set; }
        public Venue venue { get; set; }
        public int duration { get; set; }
        public string how_to_find_us { get; set; }
        public Fee fee { get; set; }
    }

    public class Group
    {
        public string join_mode { get; set; }
        public long created { get; set; }
        public string name { get; set; }
        public float group_lon { get; set; }
        [Key]
        public int id { get; set; }
        public string urlname { get; set; }
        public float group_lat { get; set; }
        public string who { get; set; }
    }

    public class Venue
    {
        public string country { get; set; }
        public string localized_country_name { get; set; }
        public string city { get; set; }
        public string address_1 { get; set; }
        public string name { get; set; }
        public float lon { get; set; }
        [Key]
        public int id { get; set; }
        public string state { get; set; }
        public float lat { get; set; }
        public bool repinned { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string address_2 { get; set; }
    }

    public class Fee
    {
        public float amount { get; set; }
        public string accepts { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public string label { get; set; }
        public string required { get; set; }
    }


    //public class EventbriteModel
    //{

    //     public Pagination pagination { get; set; }
    //     public List<Event> events { get; set; }
    //}
    //public class Pagination
    //{
    //    public int object_count { get; set; }
    //    public int page_number { get; set; }
    //    public int page_size { get; set; }
    //    public int page_count { get; set; }
    //}
    //public class Event
    //{
    //    public Name name { get; set; }
    //    public Description description { get; set; }
    //    public string id { get; set; }
    //    public string url { get; set; }
    //    public string vanity_url { get; set; }
    //    public Start start { get; set; }
    //    public End end { get; set; }
    //    public DateTime created { get; set; }
    //    public DateTime changed { get; set; }
    //    public int capacity { get; set; }
    //    public string status { get; set; }
    //    public string currency { get; set; }
    //    public bool listed { get; set; }
    //    public bool shareable { get; set; }
    //    public bool online_event { get; set; }
    //    public int tx_time_limit { get; set; }
    //    public bool hide_start_date { get; set; }
    //    public bool hide_end_date { get; set; }
    //    public string locale { get; set; }
    //    public bool is_locked { get; set; }
    //    public string privacy_setting { get; set; }
    //    public bool is_series { get; set; }
    //    public bool is_series_parent { get; set; }
    //    public bool is_reserved_seating { get; set; }
    //    public string logo_id { get; set; }
    //    public string organizer_id { get; set; }
    //    public string venue_id { get; set; }
    //    public string category_id { get; set; }
    //    public string subcategory_id { get; set; }
    //    public string format_id { get; set; }
    //    public string resource_uri { get; set; }
    //    public Logo logo { get; set; }
    //}
    //public class Name
    //{
    //    public string text { get; set; }
    //    public string html { get; set; }
    //}
    // public class Description
    //{
    //    public string text { get; set; }
    //    public string html { get; set; }
    //}
    //public class Start
    //{
    //    public string timezone { get; set; }
    //    public DateTime local { get; set; }
    //    public DateTime utc { get; set; }
    //}

    //public class End
    //{
    //    public string timezone { get; set; }
    //    public DateTime local { get; set; }
    //    public DateTime utc { get; set; }
    //}

    //public class Logo
    //{
    //    public string id { get; set; }
    //    public string url { get; set; }
    //    public string aspect_ratio { get; set; }
    //    public string edge_color { get; set; }
    //    public bool edge_color_set { get; set; }

    //}
}