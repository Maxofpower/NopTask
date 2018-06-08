//licence M2hweb.com all right reserved - For Nopcomeerce Job Task

using System;
using System.Data.Entity.ModelConfiguration;
using Nop.Plugin.Widgets.m2hwebTask.Domain;

namespace Nop.Plugin.Widgets.m2hwebTask.Data
{

	public class m2hwebRecordMap : EntityTypeConfiguration<m2hwebRecord>
	{

		public m2hwebRecordMap()
		{
			base.ToTable("m2hweb");
			base.HasKey<int>((m2hwebRecord m) => m.Id);
			base.Property<int>((m2hwebRecord m) => m.StoreId);
			base.Property((m2hwebRecord m) => m.Heading);
			base.Property((m2hwebRecord m) => m.ZoneId);
			base.Property((m2hwebRecord m) => m.CustomDivHTML);
			base.Property((m2hwebRecord m) => m.CustomScript);
			base.Property<int>((m2hwebRecord m) => m.DisplayOrder);
			base.Property<bool>((m2hwebRecord m) => m.Published);
			base.Property((m2hwebRecord m) => m.CreatedOnUtc);
		}
	}
}
