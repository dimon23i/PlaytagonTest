using System.Web.Optimization;

namespace PlaytagonTest.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js")
                 .Include(
                     "~/Scripts/*.js"
                 ));

            bundles.Add(new ScriptBundle("~/js/angular")
                .Include(
                    "~/Scripts/jQuery-{version}.js",
                    "~/Scripts/jQuery-ui-{version}.js",
                    "~/Scripts/angular.js"
                    )
                .IncludeDirectory("~/Scripts/angular-ui", "*.js", true)
                .IncludeDirectory("~/App", "*.js", true));

            bundles.Add(new StyleBundle("~/css").Include(
                "~/Content/*.css"
                ));
        }
    }
}
