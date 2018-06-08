//licence M2hweb.com all right reserved - For Nopcomeerce Job Task

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Plugins;
using Nop.Plugin.Widgets.m2hwebTask.Data;
using Nop.Plugin.Widgets.m2hwebTask.Domain;
using Nop.Plugin.Widgets.m2hwebTask.Models;
using Nop.Services.Cms;
using Nop.Services.Localization;

namespace Nop.Plugin.Widgets.m2hwebTask
{
	
	public class m2hwebPlugin : BasePlugin, IWidgetPlugin, IPlugin
	{
		
		public m2hwebPlugin(m2hwebHtmlRecordObjectContext context, IWebHelper webHelper, IRepository<m2hwebRecord> m2hwebHtmlRepository)
		{
			this._webHelper = webHelper;
			this._context = context;
			this._m2hwebRepository = m2hwebHtmlRepository;
		}

		
		public IList<string> GetWidgetZones()
		{
			List<m2hwebRecord> UnlimitedHtmlEntity = this._m2hwebRepository.Table.ToList<m2hwebRecord>();
			List<string> widgetZoneList = new List<string>();
			foreach (m2hwebRecord x in UnlimitedHtmlEntity)
			{
				m2hwebModel model = this.EntityToUnlimitedHtmlModel(x);
				string widgetZone = (!string.IsNullOrWhiteSpace(model.ZoneId)) ? model.ZoneId : "footer";
				widgetZoneList.Add(widgetZone);
			}
			return widgetZoneList;
		}


		public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "Manage";
			controllerName = "WidgetsM2hweb";
			routeValues = new RouteValueDictionary
			{
				{
					"Namespaces",
                    "Nop.Plugin.Widgets.m2hwebTask.Controllers"
                },
				{
					"area",
					null
				}
			};
		}


		public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "PublicInfo";
			controllerName = "WidgetsM2hweb";
			routeValues = new RouteValueDictionary
			{
				{
					"Namespaces",
                    "Nop.Plugin.Widgets.m2hwebTask.Controllers"
                },
				{
					"area",
					null
				},
				{
					"widgetZone",
					widgetZone
				}
			};
		}

		
		public override void Install()
		{
			this._context.Install();
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Store", "Select Store Name", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Store.Hint", "Select Store Name", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Heading", "Title Header", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Heading.Hint", "Title Header", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Position", "Position", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Position.Hint", "Select Widgets Position.", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.CustomDivHTML", "Html Widget Content", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.CustomDivHTML.Hint", "Enter Html Content.", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Customscript", "Custom Js Script", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Customscript.Hint", "Enter Custom Js Script, if any.", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Published", "Published", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Published.Hint", "Check to publish this Content.Uncheck to unpublish", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.DisplayOrder", "Display Order", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Plugins.Widgets.m2hweb.DisplayOrder.Hint", "Set the Content display order. 1 represents top of the list", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "admin.contentmanagement.widgets.m2hweb", "Manage M2hweb Widget", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "widget.m2hweb", "List M2hweb Html Widget (for Nop Task)", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Add.Widgets.m2hweb.Details", "Add Html Widget", null);
			LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "Edit.Widgets.m2hweb.Details", "Edit Html Widget", null);
			base.Install();
		}


		public override void Uninstall()
		{
			this._context.Uninstall();
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Store");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Store.Hint");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Heading");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Heading.Hint");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Position");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Position.Hint");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.CustomDivHTML");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.CustomDivHTML.Hint");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Customscript");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Customscript.Hint");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Published");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.Published.Hint");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.DisplayOrder");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Plugins.Widgets.m2hweb.DisplayOrder.Hint");
			LocalizationExtensions.DeletePluginLocaleResource(this, "admin.contentmanagement.widgets.m2hweb");
			LocalizationExtensions.DeletePluginLocaleResource(this, "widget.m2hweb");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Add.Widgets.m2hweb.Details");
			LocalizationExtensions.DeletePluginLocaleResource(this, "Edit.Widgets.m2hweb.Details");
			base.Uninstall();
		}

	
		protected m2hwebModel EntityToUnlimitedHtmlModel(m2hwebRecord entity)
		{
			m2hwebModel i = new m2hwebModel();
			if (entity == null)
			{
				entity = new m2hwebRecord();
			}
			i.ZoneId = entity.ZoneId;
			return i;
		}

	
		private readonly IWebHelper _webHelper;

	
		private m2hwebHtmlRecordObjectContext _context;

	
		private IRepository<m2hwebRecord> _m2hwebRepository;
	}
}
