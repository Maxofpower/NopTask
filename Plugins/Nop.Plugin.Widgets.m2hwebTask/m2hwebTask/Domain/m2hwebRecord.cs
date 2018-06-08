using System;
using Nop.Core;

//licence M2hweb.com all right reserved - For Nopcomeerce Job Task


using Nop.Web.Framework;

namespace Nop.Plugin.Widgets.m2hwebTask.Domain
{
	
	public class m2hwebRecord : BaseEntity
	{
	
		public int StoreId { get; set; }

		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Heading")]
		public string Heading { get; set; }

	
		[NopResourceDisplayName("Plugins.Widgets.m2hweb.ZoneId")]
		public string ZoneId { get; set; }

		
		[NopResourceDisplayName("Plugins.Widgets.m2hweb.CustomDivHTML")]
		public string CustomDivHTML { get; set; }

	
		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Customscript")]
		public string CustomScript { get; set; }

		
		[NopResourceDisplayName("Plugins.Widgets.m2hweb.DisplayOrder")]
		public int DisplayOrder { get; set; }

		
		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Published")]
		public bool Published { get; set; }

	
		public DateTime CreatedOnUtc { get; set; }
	}
}
