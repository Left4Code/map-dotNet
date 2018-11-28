using System.Web;
using System.Web.Optimization;

namespace Presentation
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery1", @"//ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js").Include(
                        "~/Scripts/jquery.easypiechart.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery", @"https://canvasjs.com/assets/script/canvasjs.min.js").Include(
                        "~/Scripts/jquery.easypiechart.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery3", @"https://code.jquery.com/jquery-3.3.1.js").Include(
                        "~/Scripts/jquery.easypiechart.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css", @"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/easypiechart.css",
                      "~/Content/bootstrap-extend.css",
                      "~/Content/morris.css",
                      "~/Content/master_style.css",
                      "~/Content/_all-skins.css"));

            bundles.Add(new StyleBundle("~/Content/template", @"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/easypiechart.css",
                     "~/Content/bootstrap-extend.css",
                     "~/Content/morris.css",
                     "~/Content/master_style.css",
                     "~/Content/_all-skins.css"
               ));
            bundles.Add(new ScriptBundle("~/bundles/template", @"https://code.jquery.com/jquery-3.3.1.js").Include(
                     "~/Scripts/popper.min.js",
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/echarts-en.min.js",
                     "~/Scripts/echarts-liquidfill.min.js",
                     "~/Scripts/ecStat.min.js",
                     "~/Scripts/raphael.min.js",
                     "~/Scripts/morris.min.js",
                     "~/Scripts/jquery.slimscroll.js",
                     "~/Scripts/fastclick.js",
                     "~/Scripts/template.js",
                     "~/Scripts/dashboard.js",
                     "~/Scripts/demo.js"
               ));
        }
    }
}
