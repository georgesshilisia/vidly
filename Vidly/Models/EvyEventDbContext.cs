namespace Vidly.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
using System.Web.Services;

    public class EvyEventDbContext : DbContext
    {
        // Your context has been configured to use a 'EvyEventDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Vidly.Models.EvyEventDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EvyEventDbContext' 
        // connection string in the application configuration file.
        public EvyEventDbContext()
            : base("name=EvyEventDbContext")
        {
        }
        public DbSet<MeetupModel> Meetup { get; set; }
        public DbSet<Rootobject> Eventbrite { get; set; }
        public DbSet<Meta> Meta { get; set; }
        public DbSet<Result> Result { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Fee> Fee { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
    public class MeetupModel
    {
        public int id { get; set; }
        public List<Result> results { get; set; }
        public Meta meta { get; set; }

    }
    public class Rootobject
    {
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
        public int id { get; set; }
        public float amount { get; set; }
        public string accepts { get; set; }
        public string description { get; set; }
        public string currency { get; set; }
        public string label { get; set; }
        public string required { get; set; }
    }
    
   

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}