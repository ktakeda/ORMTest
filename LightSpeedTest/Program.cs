using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Linq;

using LightSpeedTest.Model;

namespace LightSpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //contextの定義はapp.configに書くこともできる（たぶんそっちが推奨のやり方）
            var context = new LightSpeedContext
            {
                ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=パズルドラゴンズ;Integrated Security=True;",
                PluralizeTableNames = false,
                DataProvider = Mindscape.LightSpeed.DataProvider.SqlServer2005,
                IdentityMethod = IdentityMethod.IdentityColumn
            };

            using (var uow = context.CreateUnitOfWork())
            {
                //Create（モンスターテーブルに行を追加）
                uow.Add(new モンスター
                {
                    モンスター名 = "プレシィ",
                    レア度 = 2,
                    最大lv = 5,
                    スキル = "コールドブレス"
                });
                uow.SaveChanges();

                //Read（モンスターテーブルの各行を表示）
                foreach (var m in uow.Query<モンスター>())
                {
                    Console.WriteLine(m.モンスター名);
                }

                //Update（モンスターテーブルを一行更新）
                var ティラ = uow.Query<モンスター>().Single(x => x.モンスター名 == "ティラ");
                ティラ.最大lv = 6;
                uow.SaveChanges();

                //Delete（モンスターテーブルから一行削除）
                var プレシィ = uow.Query<モンスター>().Single(x => x.モンスター名 == "プレシィ");
                uow.Remove(プレシィ);
                uow.SaveChanges();

                //動的クエリ生成（実行時に動的にクエリを生成して実行）
                System.Random rand = new Random();
                IQueryable<モンスター> ms = uow.Query<モンスター>();
                if (rand.Next(3) < 1)
                {
                    ms = ms.Where(x => x.最大lv < 20);
                }
                if (rand.Next(3) < 1)
                {
                    ms = ms.Where(x => x.レア度 > 3);
                }
                foreach (var m in ms)
                {
                    Console.WriteLine(m.モンスター名);
                }
            }

            Console.WriteLine("Press the Enter key to exit");
            Console.ReadLine();
        }
    }
}

