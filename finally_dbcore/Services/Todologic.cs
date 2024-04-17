using finally_dbcore.Dto;
using finally_dbcore.Models.Road;
using finally_dbcore.Models.test;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Runtime.CompilerServices;

namespace finally_dbcore.Services
{
    public class Todologic
    {

        private readonly testContext _testContext;

        public Todologic(testContext testContext)
        {
            _testContext = testContext;
        }



        public List<_3_line> 查詢多筆(TA param)
        {
            // 原生寫法 不戴參數
            //var data = _testContext._3_line.FromSqlRaw("SELECT * FROM [3_line]").ToList();


            // 原生寫法 戴參數  從外部傳來參數給 parameterValue  或是 自己去指定
            // var results = _testContext._3_line.FromSqlRaw("SELECT * FROM MyTable WHERE Column = {0}", param).ToList();

            var results = _testContext._3_line.ToList();
            //efcore
            //var data = _testContext._3_line.ToList();

            // var  data  = _testContext._3_line.Where(e=> e.name == "bb").Select(x=>x).ToList();

            //var data = _testContext._3_line.Where(e => e.name == param.name).Select(x => new TA
            //{
            //    name = x.name,
            //    age = 110,
            //    description = "我不知道"
            //}).ToList();

            return results;
        }

        public int 新增資料(Line e)
        {
            //1.透過DTO 客戶傳入參數  SEVER決定某幾個欄位的 方式
            //_3_line insert = new _3_line
            //{
            //    coli_id ="4",
            //    ssv="我"
            // };

            //SaveChanges  此表必須要有 pramiy key 
            //_testContext._3_line.Add( insert ).CurrentValues.SetValues(e);
            //_testContext.SaveChanges();


            //2.原生方式insert
            var 參數 = new object[]
             {
                new SqlParameter("@coli_id","7"),
                new SqlParameter("@name",e.name),
                new SqlParameter("@ssv","he")
             };

            var sql = @"INSERT INTO [dbo].[3_line] ([coli_id],[name],[ssv])
                         VALUES   (@coli_id,@name, @ssv)";
            var ans = _testContext.Database.ExecuteSqlRaw(sql, 參數);

            return ans;
        }

        public void 修改資料(_3_line value)
        {


            _testContext._3_line.Where(d => d.coli_id == value.coli_id)
               .ExecuteUpdate(s => s
                                 .SetProperty(p => p.ssv, "ooo")
                                 .SetProperty(p => p.name, value.name)
                                 );
        }
    }
}
