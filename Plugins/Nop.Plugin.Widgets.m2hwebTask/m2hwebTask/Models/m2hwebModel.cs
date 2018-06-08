//licence M2hweb.com all right reserved - For Nopcomeerce Job Task

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.m2hwebTask.Models
{

	public class m2hwebModel : BaseNopEntityModel
	{

		public m2hwebModel()
		{
			this.AvailableStores = new List<SelectListItem>();
			this.AvailableZones = new List<SelectListItem>();
		}


		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Store")]
		public int StoreId { get; set; }


		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Store")]
		public string StoreName { get; set; }

		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Heading")]
		public string Heading { get; set; }

		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Position")]
		public string ZoneId { get; set; }

		public IList<SelectListItem> AvailableZones { get; set; }

		[NopResourceDisplayName("Plugins.Widgets.m2hweb.CustomDivHTML")]
		public string CustomDivHTML { get; set; }


		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Customscript")]
		public string CustomScript { get; set; }


		[NopResourceDisplayName("Plugins.Widgets.m2hweb.DisplayOrder")]
		public int DisplayOrder { get; set; }


		[NopResourceDisplayName("Plugins.Widgets.m2hweb.Published")]
		public bool Published { get; set; }


		public IList<SelectListItem> AvailableStores { get; set; }


		public DateTime CreatedOnUtc { get; set; }
	}
}
