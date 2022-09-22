using Microsoft.Extensions.Configuration.Json;
using WebApiBase.Models;

namespace WebApiBase.Utils
{
    public class ExtraDbHelper
    {
        private readonly IConfiguration _configuration;
        public ExtraDbHelper(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public List<DbInfoModel> Get()
        {
            var list = _configuration.GetSection("MultDbConn").AsEnumerable();
            List<DbInfoModel> modelList = new List<DbInfoModel>();
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.Value))
                {
                    var keyArr = item.Key.Split(':');
                    if (keyArr.Count() == 3 && keyArr[2] == "Type")
                    {
                        DbInfoModel model = new DbInfoModel();
                        model.DbName = keyArr[1];
                        model.ConnectionStrings = _configuration.GetSection("MultDbConn")[model.DbName + ":ConnectionStrings"];
                        string strType = _configuration.GetSection("MultDbConn")[model.DbName + ":Type"];
                        Enum.TryParse(strType, out DataBaseType type);
                        model.Type = type;
                        model.IsExtraDb = true;
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public DbInfoModel Get(string dbName)
        {
            return Get().Where(i => i.DbName == dbName).FirstOrDefault();
        }

        
    }
}
