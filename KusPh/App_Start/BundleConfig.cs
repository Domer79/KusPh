using System.Web.Optimization;

namespace TaxOrg
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/jquery").Include(
                "~/scripts/jquery-2.1.3.min.js",
                "~/scripts/jquery-ui-1.11.4.min.js"
                ));

            bundles.Add(new ScriptBundle("~/jqgrid").Include(
                "~/scripts/jquery.jqGrid.min.js",
                "~/scripts/i18n/grid.locale-ru.js"
                ));

            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                    "~/Scripts/bootstrap.min.js"
                ));

            #region Темы jQuery-UI

            //            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //                "~/Content/jquery-ui.css",
            //                "~/Content/jquery-ui.structure.css",
            //                "~/Content/themes/base/jquery-ui.theme.css",
            //                "~/Content/jquery.jqGrid/ui.jqgrid.css"
            //                ));
            bundles.Add(new StyleBundle("~/Content/themes/black-tie/css").Include(
                "~/Content/jquery-ui.css",
                "~/Content/jquery-ui.structure.css",
                "~/Content/themes/black-tie/jquery-ui.black-tie.min.css",
                "~/Content/jquery.jqGrid/ui.jqgrid.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/blitzer/css").Include(
                "~/Content/jquery-ui.css",
                "~/Content/jquery-ui.structure.css",
                "~/Content/themes/blitzer/jquery-ui.blitzer.min.css",
                "~/Content/jquery.jqGrid/ui.jqgrid.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/smoothness/css").Include(
                "~/Content/jquery-ui.css",
                "~/Content/jquery-ui.structure.css",
                "~/Content/themes/smoothness/jquery-ui.theme.css",
                "~/Content/jquery.jqGrid/ui.jqgrid.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/redmond/css").Include(
                "~/Content/jquery-ui.css",
                "~/Content/jquery-ui.structure.css",
                "~/Content/themes/redmond/jquery-ui.theme.css",
                "~/Content/jquery.jqGrid/ui.jqgrid.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/ui-lightness/css").Include(
                "~/Content/jquery-ui.css",
                "~/Content/jquery-ui.structure.css",
                "~/Content/themes/ui-lightness/jquery-ui.theme.css",
                "~/Content/jquery.jqGrid/ui.jqgrid.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/overcast/css").Include(
                "~/Content/jquery-ui.css",
                "~/Content/jquery-ui.structure.css",
                "~/Content/themes/overcast/jquery-ui.overcast.css",
                "~/Content/jquery.jqGrid/ui.jqgrid.css"
                ));

            #endregion

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                "~/Content/bootstrap-3.3.4-dist/css/bootstrap-theme.css",
                "~/Content/bootstrap-3.3.4-dist/css/bootstrap.css"
                ));
        }
    }
}