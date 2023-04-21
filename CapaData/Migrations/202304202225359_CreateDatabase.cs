namespace CapaData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nombre = c.String(),
                        Usuario_Transaccion = c.String(defaultValue: "USER"),
                        Fecha_Transaccion = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Cedula = c.String(maxLength: 50, unicode: false),
                        Usuario_Nombre = c.String(maxLength: 16, unicode: false),
                        Contrasena = c.String(),
                        Fecha_Nacimiento = c.DateTime(nullable: false),
                        Usuario_Transaccion = c.String(defaultValue: "USER"),
                        Fecha_Transaccion = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.Cedula, unique: true)
                .Index(t => t.Usuario_Nombre, unique: true)
                .Index(t => t.Fecha_Nacimiento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "RoleId", "dbo.Roles");
            DropIndex("dbo.Usuarios", new[] { "Fecha_Nacimiento" });
            DropIndex("dbo.Usuarios", new[] { "Usuario_Nombre" });
            DropIndex("dbo.Usuarios", new[] { "Cedula" });
            DropIndex("dbo.Usuarios", new[] { "RoleId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Roles");
        }
    }
}
