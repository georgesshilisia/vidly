namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            CreateTable(
                "dbo.Rootobjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        meta_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Metas", t => t.meta_id)
                .Index(t => t.meta_id);
            
            CreateTable(
                "dbo.Metas",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        next = c.String(),
                        method = c.String(),
                        total_count = c.Int(nullable: false),
                        link = c.String(),
                        count = c.Int(nullable: false),
                        description = c.String(),
                        lon = c.String(),
                        title = c.String(),
                        url = c.String(),
                        updated = c.Long(nullable: false),
                        lat = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        amount = c.Single(nullable: false),
                        accepts = c.String(),
                        description = c.String(),
                        currency = c.String(),
                        label = c.String(),
                        required = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        join_mode = c.String(),
                        created = c.Long(nullable: false),
                        name = c.String(),
                        group_lon = c.Single(nullable: false),
                        urlname = c.String(),
                        group_lat = c.Single(nullable: false),
                        who = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MeetupModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        meta_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Metas", t => t.meta_id)
                .Index(t => t.meta_id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        utc_offset = c.Int(nullable: false),
                        rsvp_limit = c.Int(nullable: false),
                        headcount = c.Int(nullable: false),
                        visibility = c.String(),
                        waitlist_count = c.Int(nullable: false),
                        created = c.Long(nullable: false),
                        maybe_rsvp_count = c.Int(nullable: false),
                        description = c.String(),
                        event_url = c.String(),
                        yes_rsvp_count = c.Int(nullable: false),
                        name = c.String(),
                        time = c.Long(nullable: false),
                        updated = c.Long(nullable: false),
                        status = c.String(),
                        duration = c.Int(nullable: false),
                        how_to_find_us = c.String(),
                        fee_id = c.Int(),
                        group_id = c.Int(),
                        venue_id = c.Int(),
                        MeetupModel_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Fees", t => t.fee_id)
                .ForeignKey("dbo.Groups", t => t.group_id)
                .ForeignKey("dbo.Venues", t => t.venue_id)
                .ForeignKey("dbo.MeetupModels", t => t.MeetupModel_id)
                .Index(t => t.fee_id)
                .Index(t => t.group_id)
                .Index(t => t.venue_id)
                .Index(t => t.MeetupModel_id);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        country = c.String(),
                        localized_country_name = c.String(),
                        city = c.String(),
                        address_1 = c.String(),
                        name = c.String(),
                        lon = c.Single(nullable: false),
                        state = c.String(),
                        lat = c.Single(nullable: false),
                        repinned = c.Boolean(nullable: false),
                        zip = c.String(),
                        phone = c.String(),
                        address_2 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.Customers");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
            DropTable("dbo.Rentals");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DrivingLicense = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customer_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                        NumberAvailable = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                        Birthdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Results", "MeetupModel_id", "dbo.MeetupModels");
            DropForeignKey("dbo.Results", "venue_id", "dbo.Venues");
            DropForeignKey("dbo.Results", "group_id", "dbo.Groups");
            DropForeignKey("dbo.Results", "fee_id", "dbo.Fees");
            DropForeignKey("dbo.MeetupModels", "meta_id", "dbo.Metas");
            DropForeignKey("dbo.Rootobjects", "meta_id", "dbo.Metas");
            DropIndex("dbo.Results", new[] { "MeetupModel_id" });
            DropIndex("dbo.Results", new[] { "venue_id" });
            DropIndex("dbo.Results", new[] { "group_id" });
            DropIndex("dbo.Results", new[] { "fee_id" });
            DropIndex("dbo.MeetupModels", new[] { "meta_id" });
            DropIndex("dbo.Rootobjects", new[] { "meta_id" });
            DropTable("dbo.Venues");
            DropTable("dbo.Results");
            DropTable("dbo.MeetupModels");
            DropTable("dbo.Groups");
            DropTable("dbo.Fees");
            DropTable("dbo.Metas");
            DropTable("dbo.Rootobjects");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            CreateIndex("dbo.Rentals", "Movie_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Movies", "GenreId");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
