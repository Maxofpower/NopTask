//licence M2hweb.com all right reserved - For Nopcomeerce Job Task

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Stores;
using Nop.Plugin.Widgets.m2hwebTask.Domain;
using Nop.Plugin.Widgets.m2hwebTask.Models;
using Nop.Services.Cms;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Kendoui;

namespace Nop.Plugin.Widgets.m2hwebTask.Controllers
{

	public class WidgetsM2hwebController : BasePluginController
	{
	
		public WidgetsM2hwebController(IWorkContext workContext, IStoreContext storeContext, IStoreService storeService, IRepository<m2hwebRecord> UnlimitedHtmlRepository, IWidgetService widgetService)
		{
			this._workContext = workContext;
			this._storeContext = storeContext;
			this._storeService = storeService;
			this._m2hwebRepository = UnlimitedHtmlRepository;
			this._widgetService = widgetService;
		}


		protected m2hwebModel EntityTom2hwebModel(m2hwebRecord entity)
		{
			m2hwebModel i = new m2hwebModel();
			if (entity == null)
			{
				entity = new m2hwebRecord();
			}
			i.Id = entity.Id;
			i.StoreId = entity.StoreId;
			i.Heading = entity.Heading;
			i.ZoneId = entity.ZoneId;
			i.StoreName = "All";
			i.DisplayOrder = entity.DisplayOrder;
			i.Published = entity.Published;
			i.CustomDivHTML = entity.CustomDivHTML;
			i.CustomScript = entity.CustomScript;
			i.CreatedOnUtc = entity.CreatedOnUtc;
			Store selectedStore = this._storeService.GetStoreById(entity.StoreId);
			if (selectedStore != null)
			{
				i.StoreName = selectedStore.Name;
			}
			if (i.AvailableStores == null)
			{
				i.AvailableStores = new List<SelectListItem>();
			}
			i.AvailableStores.Add(new SelectListItem
			{
				Text = "Select Store",
				Value = "0"
			});
			foreach (Store store in this._storeService.GetAllStores())
			{
				i.AvailableStores.Add(new SelectListItem
				{
					Text = store.Name,
					Value = store.Id.ToString(),
					Selected = (selectedStore != null && store.Id == selectedStore.Id)
				});
			}
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "account_navigation_after",
				Value = "account_navigation_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "account_navigation_before",
				Value = "account_navigation_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "bloglist_page_after_posts",
				Value = "bloglist_page_after_posts"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "bloglist_page_before_posts",
				Value = "bloglist_page_before_posts"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "bloglist_page_inside_post",
				Value = "bloglist_page_inside_post"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "blogpost_page_after_comments",
				Value = "blogpost_page_after_comments"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "blogpost_page_before_body",
				Value = "blogpost_page_before_body"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "blogpost_page_before_comments",
				Value = "blogpost_page_before_comments"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "blogpost_page_inside_comment",
				Value = "blogpost_page_inside_comment"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "body_end_html_tag_before",
				Value = "body_end_html_tag_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "body_start_html_tag_after",
				Value = "body_start_html_tag_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "categorydetails_after_breadcrumb",
				Value = "categorydetails_after_breadcrumb"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "categorydetails_after_featured_products",
				Value = "categorydetails_after_featured_products"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "categorydetails_before_featured_products",
				Value = "categorydetails_before_featured_products"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "categorydetails_before_filters",
				Value = "categorydetails_before_filters"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "categorydetails_before_product_list",
				Value = "categorydetails_before_product_list"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "categorydetails_before_subcategories",
				Value = "categorydetails_before_subcategories"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "categorydetails_bottom",
				Value = "categorydetails_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "categorydetails_top",
				Value = "categorydetails_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_billing_address_bottom",
				Value = "checkout_billing_address_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_billing_address_middle",
				Value = "checkout_billing_address_middle"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_billing_address_top",
				Value = "checkout_billing_address_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_completed_bottom",
				Value = "checkout_completed_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_completed_top",
				Value = "checkout_completed_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_confirm_bottom",
				Value = "checkout_confirm_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_confirm_top",
				Value = "checkout_confirm_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_payment_info_bottom",
				Value = "checkout_payment_info_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_payment_info_top",
				Value = "checkout_payment_info_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_payment_method_bottom",
				Value = "checkout_payment_method_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_payment_method_top",
				Value = "checkout_payment_method_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_progress_after",
				Value = "checkout_progress_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_progress_before",
				Value = "checkout_progress_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_shipping_address_bottom",
				Value = "checkout_shipping_address_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_shipping_address_middle",
				Value = "checkout_shipping_address_middle"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_shipping_address_top",
				Value = "checkout_shipping_address_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_shipping_method_bottom",
				Value = "checkout_shipping_method_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "checkout_shipping_method_top",
				Value = "checkout_shipping_method_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "contactus_bottom",
				Value = "contactus_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "contactus_top",
				Value = "contactus_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "content_after",
				Value = "content_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "content_before",
				Value = "content_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "footer",
				Value = "footer"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "head_html_tag",
				Value = "head_html_tag"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "header",
				Value = "header"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "header_links_after",
				Value = "header_links_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "header_links_before",
				Value = "header_links_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "header_menu_after",
				Value = "header_menu_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "header_menu_before",
				Value = "header_menu_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "header_selectors",
				Value = "header_selectors"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "home_page_bottom",
				Value = "home_page_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "home_page_top",
				Value = "home_page_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "left_side_column_after",
				Value = "left_side_column_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "left_side_column_after_category_navigation",
				Value = "left_side_column_after_category_navigation"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "left_side_column_before_category_navigation",
				Value = "left_side_column_before_category_navigation"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "left_side_column_before",
				Value = "left_side_column_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "main_column_after",
				Value = "main_column_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "main_column_before",
				Value = "main_column_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "manufacturerdetails_after_featured_products",
				Value = "manufacturerdetails_after_featured_products"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "manufacturerdetails_before_featured_products",
				Value = "manufacturerdetails_before_featured_products"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "manufacturerdetails_before_filters",
				Value = "manufacturerdetails_before_filters"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "manufacturerdetails_before_product_list",
				Value = "manufacturerdetails_before_product_list"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "manufacturerdetails_bottom",
				Value = "manufacturerdetails_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "manufacturerdetails_top",
				Value = "manufacturerdetails_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "mob_header_menu_after",
				Value = "mob_header_menu_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "mob_header_menu_before",
				Value = "mob_header_menu_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "newsitem_page_after_comments",
				Value = "newsitem_page_after_comments"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "newsitem_page_before_body",
				Value = "newsitem_page_before_body"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "newsitem_page_before_comments",
				Value = "newsitem_page_before_comments"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "newsitem_page_inside_comment",
				Value = "newsitem_page_inside_comment"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "newslist_page_after_items",
				Value = "newslist_page_after_items"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "newslist_page_before_items",
				Value = "newslist_page_before_items"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "newslist_page_inside_item",
				Value = "newslist_page_inside_item"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "notifications",
				Value = "notifications"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_billing_address_bottom",
				Value = "op_checkout_billing_address_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_billing_address_middle",
				Value = "op_checkout_billing_address_middle"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_billing_address_top",
				Value = "op_checkout_billing_address_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_confirm_bottom",
				Value = "op_checkout_confirm_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_confirm_top",
				Value = "op_checkout_confirm_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_payment_info_bottom",
				Value = "op_checkout_payment_info_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_payment_info_top",
				Value = "op_checkout_payment_info_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_payment_method_bottom",
				Value = "op_checkout_payment_method_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_payment_method_top",
				Value = "op_checkout_payment_method_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_shipping_address_bottom",
				Value = "op_checkout_shipping_address_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_shipping_address_middle",
				Value = "op_checkout_shipping_address_middle"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_shipping_address_top",
				Value = "op_checkout_shipping_address_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_shipping_method_bottom",
				Value = "op_checkout_shipping_method_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "op_checkout_shipping_method_top",
				Value = "op_checkout_shipping_method_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "order_summary_cart_footer",
				Value = "order_summary_cart_footer"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "order_summary_content_after",
				Value = "order_summary_content_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "order_summary_content_before",
				Value = "order_summary_content_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "order_summary_content_deals",
				Value = "order_summary_content_deals"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "orderdetails_page_afterproducts",
				Value = "orderdetails_page_afterproducts"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "orderdetails_page_beforeproducts",
				Value = "orderdetails_page_beforeproducts"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "orderdetails_page_bottom",
				Value = "orderdetails_page_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "orderdetails_page_overview",
				Value = "orderdetails_page_overview"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "orderdetails_page_top",
				Value = "orderdetails_page_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productbox_add_info",
				Value = "productbox_add_info"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productbreadcrumb_after",
				Value = "productbreadcrumb_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productbreadcrumb_before",
				Value = "productbreadcrumb_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_add_info",
				Value = "productdetails_add_info"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_after_breadcrumb",
				Value = "productdetails_after_breadcrumb"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_after_pictures",
				Value = "productdetails_after_pictures"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_before_collateral",
				Value = "productdetails_before_collateral"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_before_pictures",
				Value = "productdetails_before_pictures"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_bottom",
				Value = "productdetails_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_overview_bottom",
				Value = "productdetails_overview_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_overview_top",
				Value = "productdetails_overview_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productdetails_top",
				Value = "productdetails_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productreviews_page_bottom",
				Value = "productreviews_page_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productreviews_page_inside_review",
				Value = "productreviews_page_inside_review"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productreviews_page_top",
				Value = "productreviews_page_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productsbytag_before_product_list",
				Value = "productsbytag_before_product_list"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productsbytag_bottom",
				Value = "productsbytag_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productsbytag_top",
				Value = "productsbytag_top"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productsearch_page_advanced",
				Value = "productsearch_page_advanced"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "productsearch_page_basic",
				Value = "productsearch_page_basic"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "profile_page_info_userdetails",
				Value = "profile_page_info_userdetails"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "profile_page_info_userstats",
				Value = "profile_page_info_userstats"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "right_side_column_after",
				Value = "right_side_column_after"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "right_side_column_before",
				Value = "right_side_column_before"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "searchbox",
				Value = "searchbox"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "searchbox_before_search_button",
				Value = "searchbox_before_search_button"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "vendordetails_bottom",
				Value = "vendordetails_bottom"
			});
			i.AvailableZones.Add(new SelectListItem
			{
				Text = "vendordetails_top",
				Value = "vendordetails_top"
			});
			return i;
		}

	
		protected m2hwebRecord m2hwebModelToEntity(m2hwebModel model)
		{
			return new m2hwebRecord
			{
				Id = model.Id,
				StoreId = model.StoreId,
				Heading = model.Heading,
				ZoneId = model.ZoneId,
				DisplayOrder = model.DisplayOrder,
				Published = model.Published,
				CustomDivHTML = model.CustomDivHTML,
				CustomScript = model.CustomScript,
				CreatedOnUtc = DateTime.UtcNow
			};
		}

	
		protected m2hwebRecord m2hwebModelToEntity(m2hwebRecord entity, m2hwebModel model)
		{
			entity.Id = model.Id;
			entity.StoreId = model.StoreId;
			entity.Heading = model.Heading;
			entity.ZoneId = model.ZoneId;
			entity.DisplayOrder = model.DisplayOrder;
			entity.Published = model.Published;
			entity.CustomDivHTML = model.CustomDivHTML;
			entity.CustomScript = model.CustomScript;
			entity.CreatedOnUtc = DateTime.UtcNow;
			return entity;
		}

	
		protected IList<m2hwebModel> Gem2hwebList()
		{
			List<m2hwebRecord> m2hwebEntity = this._m2hwebRepository.Table.ToList<m2hwebRecord>();
			List<m2hwebModel> m2hweblist = new List<m2hwebModel>();
			foreach (m2hwebRecord x in m2hwebEntity)
			{
				m2hwebModel model = this.EntityTom2hwebModel(x);
				m2hweblist.Add(model);
			}
			return m2hweblist;
		}

	
		protected override void Initialize(RequestContext requestContext)
		{
			CommonHelper.SetTelerikCulture();
			base.Initialize(requestContext);
		}

	
		[AdminAuthorize]
		public ActionResult Configure()
		{
			return base.View("~/Plugins/Widgets.m2hwebTask/Views/WidgetsM2hweb/Configure.cshtml");
		}

		[AdminAuthorize]
		[ChildActionOnly]
		public ActionResult Manage()
		{
			m2hwebRecord entity = new m2hwebRecord();
			m2hwebModel model = this.EntityTom2hwebModel(entity);
			return base.View("~/Plugins/Widgets.m2hwebTask/Views/WidgetsM2hweb/Manage.cshtml", model);
		}

		[HttpPost]
		public ActionResult m2hwebList(DataSourceRequest command, m2hwebModel model)
		{
			IList<m2hwebModel> m2hweblist = this.Gem2hwebList();
			return base.Json(new DataSourceResult
			{
				Data = m2hweblist,
				Total = m2hweblist.Count
			});
		}

	
		[AdminAuthorize]
		public ActionResult Create()
		{
			m2hwebRecord entity = new m2hwebRecord();
			m2hwebModel model = this.EntityTom2hwebModel(entity);
			return base.View("~/Plugins/Widgets.m2hwebTask/Views/WidgetsM2hweb/Create.cshtml", model);
		}

	
		[HttpPost]
		[ValidateInput(false)]
		[AdminAuthorize]
		public ActionResult Create(m2hwebModel vm)
		{
			m2hwebRecord entity = this.m2hwebModelToEntity(vm);
			this._m2hwebRepository.Insert(entity);
			return base.RedirectToAction("Configure");
		}

		[AdminAuthorize]
		[ValidateInput(false)]
		public ActionResult Update(int Id)
		{
			m2hwebRecord entity = this._m2hwebRepository.GetById(Id);
			m2hwebModel model = this.EntityTom2hwebModel(entity);
			return base.View("~/Plugins/Widgets.m2hwebTask/Views/WidgetsM2hweb/Update.cshtml", model);
		}
        
		[HttpPost]
		[AdminAuthorize]
		[ParameterBasedOnFormName("save-continue", "continueEditing")]
		[ValidateInput(false)]
		public ActionResult Update(m2hwebModel vm, bool continueEditing = true)
		{
			m2hwebRecord entity = this._m2hwebRepository.GetById(vm.Id);
			entity = this.m2hwebModelToEntity(entity, vm);
			this._m2hwebRepository.Update(entity);
			ActionResult result;
			if (continueEditing)
			{
				result = base.RedirectToAction("Update", new
				{
					id = vm.Id
				});
			}
			else
			{
				result = base.RedirectToAction("Configure");
			}
			return result;
		}

	
		[HttpPost]
		[AdminAuthorize]
		public ActionResult Delete(DataSourceRequest command, int Id)
		{
			m2hwebRecord entity = this._m2hwebRepository.GetById(Id);
			this._m2hwebRepository.Delete(entity);
			return base.RedirectToAction("Configure");
		}

		[AdminAuthorize]
		public ActionResult Delete(int Id)
		{
			m2hwebRecord entity = this._m2hwebRepository.GetById(Id);
			this._m2hwebRepository.Delete(entity);
			return base.RedirectToAction("Configure");
		}

		[ChildActionOnly]
		public ActionResult PublicInfo(string widgetZone, object additionalData = null)
		{
			PublicInfoModel model = new PublicInfoModel();
			model.m2hwebModelList = this.Gem2hwebList();
			model.m2hwebModelList = (from x in model.m2hwebModelList
			where x.StoreId == this._storeContext.CurrentStore.Id
			where x.Published
			where x.ZoneId == widgetZone
			select x).ToList<m2hwebModel>();
			ActionResult result;
			if (model.m2hwebModelList.Count == 0 || model == null)
			{
				result = base.Content("");
			}
			else
			{
				model.m2hwebModelList = (from x in model.m2hwebModelList
				orderby x.DisplayOrder
				select x).ToList<m2hwebModel>();
				result = base.View("~/Plugins/Widgets.m2hwebTask/Views/WidgetsM2hweb/PublicInfo.cshtml", model);
			}
			return result;
		}

	
		public ActionResult ReviewDetails(int Id)
		{
			m2hwebRecord entity = this._m2hwebRepository.GetById(Id);
			m2hwebModel model = this.EntityTom2hwebModel(entity);
			return base.View("~/Plugins/Widgets.m2hwebTask/Views/WidgetsM2hweb/ReviewDetails.cshtml", model);
		}

		private readonly IWorkContext _workContext;

		
		private readonly IStoreContext _storeContext;


		private readonly IStoreService _storeService;


		private IRepository<m2hwebRecord> _m2hwebRepository;

		
		private readonly IWidgetService _widgetService;
	}
}
