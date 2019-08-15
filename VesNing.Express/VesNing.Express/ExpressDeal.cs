using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;
using VesNing.Express.Mapping;
using System.Diagnostics;

namespace VesNing.Express
{
    class ExpressDeal
    {
        /// <summary>
        /// 动态拼装
        /// 类似于动态sql，可以动态的执行代码
        /// 动态拼接二元计算
        /// </summary>
        public static void MontageBinaryExpress()
        {
            Func<int, int, int> func = (m, n) => { return m * n + n + 2; };
            Expression<Func<int, int, int>> expression = (m, n) => m * n + n + 2;
            Expression exp = null;
            //表示常量2
            ConstantExpression constantExpression = Expression.Constant(2, typeof(int));
            ParameterExpression mPE = Expression.Parameter(typeof(int), "m");
            ParameterExpression nPE = Expression.Parameter(typeof(int), "n");//表示参数
            exp = Expression.Multiply(mPE, nPE);//返回一个二元表达式
            exp = Expression.Add(exp, nPE);
            exp = Expression.Add(exp, constantExpression);
            Console.WriteLine(exp.ToString());
            LambdaExpression lambda = Expression.Lambda(exp, new ParameterExpression[] { mPE, nPE });
            Console.WriteLine($"表达式：{ exp.ToString()},结果：{lambda.Compile().DynamicInvoke(4, 5)}");
        }
        /// <summary>
        /// 动态组合实体属性
        /// 我需要拼接People中Age>10
        /// x.Age>10
        /// </summary>
        public static void MontageEntityPropertyExpress()
        {
            Expression<Func<People, bool>> expression = x => x.Age > 10 && x.Name.Contains("VesNing");
            var parameter = Expression.Parameter(typeof(People), "x");
            var constant10 = Expression.Constant(10);
            var plus1 = Expression.Property(parameter, "Age");
            var plus2 = Expression.GreaterThan(plus1, constant10);

            var plus3 = Expression.Property(parameter, "Name");
            var constantNing = Expression.Constant("VesNing");
            MethodInfo containsMethod = typeof(string).GetMethod("Contains");
            var plus4 = Expression.Call(plus3, containsMethod, new Expression[] { constantNing });


            var plus5 = Expression.AndAlso(plus2, plus4);
            LambdaExpression lambda = Expression.Lambda(plus5);
            Console.WriteLine($"表达式:{plus5.ToString()}");


        }
        /// <summary>
        /// 匹配映射比较
        /// 2个实体类做映射，将一个实体类的数据复制到另一个实体类上
        /// 在领域模型中BO与DTO的映射
        /// 可以使用：
        /// 1.硬编码
        /// 2.泛型+反射
        /// 3.泛型+表达式树
        /// </summary>
        public static void MapperCompare()
        {
            People p = new People()
            {
                Id=1001,
                Number=10,
                Name="VesNing",
                Age=28
            };
            var result1 = HardCodingMapper.Mapper(p);
            result1.ToString();

            var result2= ReflectionMapper.Mapper<People, PeopleCopy>(p);
            result2.ToString();

            var result3 = SerializeMapper.Mapper(p);
            result3.ToString();

            var result4= ExpressionMapper.Mapper<People, PeopleCopy>(p);

            StopWatchRun((m)=> { HardCodingMapper.Mapper(m); },p,"硬编码");
            StopWatchRun((m) => { ReflectionMapper.Mapper<People, PeopleCopy>(m); }, p, "泛型+反射");
            StopWatchRun((m) => { SerializeMapper.Mapper(m); }, p, "NewtoneSoft序列化");
            StopWatchRun((m) => { ExpressionMapper.Mapper<People, PeopleCopy>(m); }, p, "表达式树+字典缓存");

        }
        private static void StopWatchRun(Action<People> action,People p,string remark)
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            for (int i = 0; i < 1_000_000; i++)
            {
                action.Invoke(p);
            }
            sp.Stop();
            remark=$"{remark},运行时长：{sp.ElapsedMilliseconds}";
            Console.WriteLine(remark);
        }
    }
}
