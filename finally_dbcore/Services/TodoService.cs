using finally_dbcore.Dto;
using finally_dbcore.Models.test;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace finally_dbcore.Services
{
    public class TodoService
    {

        private readonly testContext _testContext;

        public TodoService(testContext testContext)
        {
            _testContext = testContext;
        }


        public List<_3_line> 查詢多筆(TA param)
        {
            // 原生寫法 不戴參數
            //var data = _testContext._3_line.FromSqlRaw("SELECT * FROM [3_line]").ToList();

            // 原生寫法 戴參數  從外部傳來參數給 parameterValue  或是 自己去指定
            //var results = _testContext._3_line.FromSqlRaw("SELECT * FROM MyTable WHERE Column = {0}", parameterValue).ToList();


            //efcore
            var  data  = _testContext._3_line.ToList();

            // var  data  = _testContext._3_line.Where(e=> e.name == "bb").Select(x=>x).ToList();

            //var data = _testContext._3_line.Where(e => e.name == param.name).Select(x => new TA
            //{
            //    name = x.name,
            //    age = 110,
            //    description = "我不知道"
            //}).ToList();

            return data;
        }

    }
}
