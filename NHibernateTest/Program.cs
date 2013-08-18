using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;

using NHibernateTest.Models;

namespace NHibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                //Create（モンスターテーブルに行を追加）
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(new Monster
                    {
                        Name = "プレシィ",
                        Rarity = 2,
                        Maxlv = 5,
                        Skill = "コールドブレス"
                    });
                    transaction.Commit();
                }

                //Read（モンスターテーブルの各行を表示）
                foreach (var m in session.Query<Monster>())
                {
                    Console.WriteLine(m.Name);
                }

                //Update（モンスターテーブルを一行更新）
                var ティラ = session.Query<Monster>().Single(x => x.Name == "ティラ");
                ティラ.Maxlv = 6;
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(ティラ);
                    transaction.Commit();
                }

                //Delete（モンスターテーブルから一行削除）
                var プレシィ = session.Query<Monster>().Single(x => x.Name == "プレシィ");
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(プレシィ);
                    transaction.Commit();
                }

                //動的クエリ生成（実行時に動的にクエリを生成して実行）
                System.Random rand = new Random();
                IQueryable<Monster> ms = session.Query<Monster>();
                if (rand.Next(3) < 1)
                {
                    ms = ms.Where(x => x.Maxlv < 20);
                }
                if (rand.Next(3) < 1)
                {
                    ms = ms.Where(x => x.Rarity > 3);
                }
                foreach (var m in ms)
                {
                    Console.WriteLine(m.Name);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(
                                  @"Data Source=localhost\sqlexpress;Initial Catalog=パズルドラゴンズ;Integrated Security=true;")
                              .ShowSql()
                )
                //Monsterクラスを含むアセンブリからMapping定義を読み込む
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Monster>()) 
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
