using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Examples
{
    [TestClass]
    public class TestModel
    {
        [TestMethod]
        public void GetAllTypes()
        {
            DbContextOptionsBuilder<ControllDB> dbContextOptionsBuilder = new DbContextOptionsBuilder<ControllDB>();
            dbContextOptionsBuilder.UseInMemoryDatabase();
            using (ControllDB context = new ControllDB(dbContextOptionsBuilder.Options))
            {
                foreach (IEntityType eType in context.Model.GetEntityTypes())
                {
                    Console.WriteLine(eType);
                    Console.WriteLine("Name:{0}; GetType:{1}", eType.Name, eType.ClrType);
                }
            }
        }
        [TestMethod]
        public void GetAllDefaults()
        {
            DbContextOptionsBuilder<ControllDB> dbContextOptionsBuilder = new DbContextOptionsBuilder<ControllDB>();
            dbContextOptionsBuilder.UseInMemoryDatabase();
            using (ControllDB context = new ControllDB(dbContextOptionsBuilder.Options))
            {
                foreach (IEntityType eType in context.Model.GetEntityTypes())
                {
                    IRelationalEntityTypeAnnotations rAnns = eType.Relational();
                    if (rAnns == null) continue;
                    Console.WriteLine(eType);
                    Console.WriteLine("TableName:[{0}].[{1}]", rAnns.Schema, rAnns.TableName);
                    foreach (IProperty property in eType.GetProperties())
                    {
                        var defaultValue = property.Relational().DefaultValue;
                        var defaultValueSql = property.Relational().DefaultValueSql;
                        if (defaultValue == null && defaultValueSql == null) continue;
                        Console.WriteLine("{0}=>{1}, {2}, {3}", property.Name, property.Relational().ColumnName, defaultValue, defaultValueSql);
                    }
                }
            }
        }
    }
}
