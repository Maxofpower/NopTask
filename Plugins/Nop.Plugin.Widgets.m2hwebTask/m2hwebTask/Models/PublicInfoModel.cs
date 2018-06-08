
//licence M2hweb.com all right reserved - For Nopcomeerce Job Task


using System;
using System.Collections.Generic;
using Nop.Web.Framework.Mvc;

namespace Nop.Plugin.Widgets.m2hwebTask.Models
{

	public class PublicInfoModel : BaseNopModel
	{

		public PublicInfoModel()
		{
			this.m2hwebModelList = new List<m2hwebModel>();
		}


		public IList<m2hwebModel> m2hwebModelList { get; set; }
	}
}
