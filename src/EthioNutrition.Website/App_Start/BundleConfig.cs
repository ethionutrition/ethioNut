using System.Web;
using System.Web.Optimization;

namespace EthioNutrition.Website.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/js/jquery-{version}.js",
                        "~/Content/js/jquery-{version}.min.js",
                        "~/Content/js/jquery-{version}.min.map"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/js/modernizr.*"));

            bundles.Add(new ScriptBundle("~/Content/js").Include(
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/less-1.7.0.min.js",
                      "~/Content/js/placeholdem.min.js",
                      "~/Content/js/scripts.js",
                      "~/Content/js/slick.min.js",
                      "~/Content/js/waypoints.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/slick.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/eco.css",
                      "~/Content/css/font-awesome.min.css"));
        }
    }
}