using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntityFrameworkTest.Models;

namespace EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new パズルドラゴンズContext())
            {
                //Create（モンスターテーブルに行を追加）
                db.モンスター.Add(new モンスター
                {
                    モンスター名 = "プレシィ",
                    レア度 = 2,
                    最大Lv = 5,
                    スキル = "コールドブレス"
                });
                db.SaveChanges();

                //Read（モンスターテーブルの各行を表示）
                foreach (var m in db.モンスター)
                {
                    Console.WriteLine(m.モンスター名);
                }

                //Update（モンスターテーブルを一行更新）
                var ティラ = db.モンスター.Single(x => x.モンスター名 == "ティラ");
                ティラ.最大Lv = 6;
                db.SaveChanges();

                //Delete（モンスターテーブルから一行削除）
                var プレシィ = db.モンスター.Single(x => x.モンスター名 == "プレシィ");
                db.モンスター.Remove(プレシィ);
                db.SaveChanges();

                //動的クエリ生成（実行時に動的にクエリを生成して実行）
                System.Random rand = new Random();
                IQueryable<モンスター> ms = db.モンスター;
                if (rand.Next(3) < 1)
                {
                    ms = ms.Where(x => x.最大Lv < 20);
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

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
