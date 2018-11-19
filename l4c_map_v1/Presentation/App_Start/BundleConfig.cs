﻿using System.Web;
using System.Web.Optimization;

namespace Presentation
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

            bundles.Add(new StyleBundle("~/Content/template").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-extend.css",
                      "~/Content/morris.css",
                      "~/Content/master_style.css",
                      "~/Content/_all-skins.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/template").Include(
                      "~/Scripts/jquery.js",
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