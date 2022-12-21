using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMysql.Models;

namespace WebAppMysql.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();  // Add

        //
        // GET: Home
        //
        public ActionResult Index()
        {
            return View(db.Students.ToList()); //upd 
        }

        //
        // 表示
        //
        // GET: Student/Details/5
        public ActionResult Details(int? id) //ブル型（idが未設定の場合、nullが設定される）
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Student std = db.Students.Find(id);　// dbの検索
            if (std == null)
            {
                // 一致しない場合、４０４ページを出力
                return HttpNotFound();
            }
            return View(std); // 一致すればデータをVIEWに設定して返す。
        }
        //
        //  登録
        //
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student std)
        {
            db.Students.Add(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //
        // 修正
        //
        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Student std = db.Students.Find(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        // POST: Student/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StdId,StdName,StdAge,StdAddress")] Student std)
        {
            if (ModelState.IsValid)
            {
                db.Entry(std).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(std);
        }
        //
        //　削除
        //
        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Student std = db.Students.Find(id);
            if (std == null)
            {
                return HttpNotFound();
            }
            return View(std);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student std = db.Students.Find(id);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}