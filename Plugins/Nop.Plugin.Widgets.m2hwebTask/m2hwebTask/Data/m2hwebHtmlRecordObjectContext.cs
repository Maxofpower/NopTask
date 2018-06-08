//licence M2hweb.com all right reserved - For Nopcomeerce Job Task

using System;
using System.Collections.Generic;
using System.Data.Entity;
using Nop.Core;
using System.Data.Entity.Infrastructure;
using Nop.Data;
using Nop.Plugin.Widgets.m2hwebTask.Domain;

namespace Nop.Plugin.Widgets.m2hwebTask.Data
{

	public class m2hwebHtmlRecordObjectContext : DbContext, IDbContext
	{
	
		public m2hwebHtmlRecordObjectContext(string nameOrConnectionString) : base(nameOrConnectionString)
		{
		}

		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add<m2hwebRecord>(new m2hwebRecordMap());
			Database.SetInitializer<m2hwebHtmlRecordObjectContext>(null);
			base.OnModelCreating(modelBuilder);
		}

	
		public string CreateDatabaseInstallationScript()
		{
			
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

  
        public void Install()
		{
			Database.SetInitializer<m2hwebHtmlRecordObjectContext>(null);
			string dbScript = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[m2hweb]') AND type in (N'U'))\r\n                                BEGIN\r\n                                    CREATE TABLE [dbo].[m2hweb](\r\n\t                                    [Id] [int] IDENTITY(1,1) NOT NULL,\r\n\t                                    [StoreId] [int] NOT NULL,\t                                 \r\n\t                                    [Heading] [nvarchar](max) NULL,\t                                  \r\n                                        [ZoneId] [nvarchar](500) NULL,\r\n                                        [DisplayOrder] [int] NOT NULL,\r\n\t                                    [Published] [bit] NOT NULL,\r\n\t                                    [CustomDivHTML] [nvarchar](max) NULL,\r\n                                        [CustomScript] [nvarchar](max) NULL,\t                                   \r\n                                        [CreatedOnUtc] [datetime] NOT NULL                                   \r\n                                    PRIMARY KEY CLUSTERED \r\n                                    (\r\n\t                                    [Id] ASC\r\n                                    )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n                                    ) ON [PRIMARY]                                                                   \r\n\r\n                             END";
			base.Database.ExecuteSqlCommand(dbScript, new object[0]);
			this.SaveChanges();
		}

		
		public void Uninstall()
		{
			string dbScript = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[m2hweb]') AND type in (N'U'))\r\n                             BEGIN                             \r\n                              DROP TABLE [dbo].[m2hweb]                                                    \r\n                             END";
			base.Database.ExecuteSqlCommand(dbScript, new object[0]);
			this.SaveChanges();
		}


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }


        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
		{
			throw new NotImplementedException();
		}

	
		public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
		{
			throw new NotImplementedException();
		}

		public void Detach(object entity)
		{
			throw new NotImplementedException();
		}


		public bool ProxyCreationEnabled
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool AutoDetectChangesEnabled
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
