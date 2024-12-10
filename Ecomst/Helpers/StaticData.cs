namespace Ecomst.Helpers
{
    public static class StaticData
    {
        public const string Role_Customer = "Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        public static string GetEmptyImagePath()
        {
            return "files" + Path.DirectorySeparatorChar + "images" + Path.DirectorySeparatorChar + "empty.jpg";
        }

        public static string GetProductImageDir()
        {
            return "files" + Path.DirectorySeparatorChar + "images" + Path.DirectorySeparatorChar + "products";
        }
    }
}
