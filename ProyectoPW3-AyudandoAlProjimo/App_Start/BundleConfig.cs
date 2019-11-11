using System.Web;
using System.Web.Optimization;

namespace ProyectoPW3_AyudandoAlProjimo
{
    public class BundleConfig
    {/*
    <link href="~/Content/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link href="~/Content/css/sb-admin-2.min.css" rel="stylesheet">
    <link href="~/Content/css/estilos.css" rel="stylesheet" type="text/css">



           <script src="~/Content/vendor/jquery/jquery.min.js"></script>

    <script src="~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <script src="~/Content/vendor/jquery-easing/jquery.easing.min.js"></script>

    <script src="~/Content/js/sb-admin-2.min.js"></script>
    <script src="~/Content/js/scripts.js"></script>
        */
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery3.4.1").Include(
                    "~/Scripts/jquery-3.4.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                        "~/Content/js/sb-admin-2.min.js",
                        "~/Content/js/scripts.js",
                        "~/Content/js/crearpropuesta.js"));

            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/vendor/fontawesome-free/css/all.min.css",
                "~/Content/css/sb-admin-2.min.css",
                      "~/Content/css/estilos.css"
                      ));
            //BundleTable.EnableOptimizations = true;
        }
    }
}
