namespace TopMessenger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        NickName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        DateOfSend = c.DateTime(nullable: false),
                        PhotoOfUser = c.String(),
                        Dender_Id = c.Int(),
                        Receiver_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Dender_Id)
                .ForeignKey("dbo.Users", t => t.Receiver_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Dender_Id)
                .Index(t => t.Receiver_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserFriendLists",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        FriendList_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.FriendList_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.FriendLists", t => t.FriendList_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.FriendList_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Receiver_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Dender_Id", "dbo.Users");
            DropForeignKey("dbo.UserFriendLists", "FriendList_Id", "dbo.FriendLists");
            DropForeignKey("dbo.UserFriendLists", "User_Id", "dbo.Users");
            DropIndex("dbo.UserFriendLists", new[] { "FriendList_Id" });
            DropIndex("dbo.UserFriendLists", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "Receiver_Id" });
            DropIndex("dbo.Messages", new[] { "Dender_Id" });
            DropTable("dbo.UserFriendLists");
            DropTable("dbo.Messages");
            DropTable("dbo.Users");
            DropTable("dbo.FriendLists");
        }
    }
}
