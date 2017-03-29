using System.Web;
using System.Web.Optimization;

namespace AnimeDB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //AnimeDB applications

            //CORE: Basic applications, like jquery, bootstrap, angular, and angular boostrap.
            bundles.Add(new ScriptBundle("~/animedb/core").Include(
                "~/Assets/bower_components/jquery/dist/jquery.js",
                "~/Assets/bower_components/bootstrap/dist/js/bootstrap.js",
                "~/Assets/bower_components/angular/angular.js",
                "~/Assets/bower_components/angular-animate/angular-animate.js",
                "~/Assets/bower_components/angular-bootstrap/ui-bootstrap.js",
                "~/Assets/bower_components/angular-bootstrap/ui-bootstrap-tpls.js"
                ));

            //BOOTSTRAP CSS: additional features of boostrap, including the angular bootstrap.
            bundles.Add(new StyleBundle("~/animedb/bootstrap/css").Include(
                "~/Assets/bower_components/bootstrap/dist/css/bootstrap.css",
                "~/Assets/bower_components/angular-bootstrap/ui-bootstrap-csp.css"
              ));
        }
    }
}
