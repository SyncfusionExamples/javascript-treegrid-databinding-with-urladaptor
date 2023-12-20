using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RemoteSave.Models;
using Syncfusion.EJ2.Base;
using System.Collections;
using Syncfusion.EJ2.Linq;
using Syncfusion.EJ2.Navigations;

namespace RemoteSave.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UrlDatasource(DataManagerRequest dm)
        {
            if (TreeData.tree.Count == 0)
                TreeData.GetTree();
            IEnumerable DataSource = TreeData.tree;

            DataOperations operation = new DataOperations();
            if (dm.Where != null && dm.Where.Count > 0)
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, "and");
            }
            List<string> str = new List<string>();

            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            var count = DataSource.ToList<TreeData>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
        }

        public ActionResult Update(TreeData value)
        {
            var val = TreeData.tree.Where(ds => ds.TaskID == value.TaskID).FirstOrDefault();
            val.TaskName = value.TaskName;
            val.StartDate = value.StartDate;
            val.Duration = value.Duration;
            val.Priority = value.Priority;
            val.Progress = value.Progress;
            return Json(value);
        }

        public void Insert(TreeData value, int relationalKey)
        {
            var i = 0;
            for (; i < TreeData.tree.Count; i++)
            {
                if (TreeData.tree[i].TaskID == relationalKey)
                {
                    break;
                }
            }
            i += FindChildRecords(relationalKey);
            TreeData.tree.Insert(i + 1, value);
        }
        public int FindChildRecords(int? id)
        {
            var count = 0;
            for (var i = 0; i < TreeData.tree.Count; i++)
            {
                if (TreeData.tree[i].ParentItem == id)
                {
                    count++;
                    count += FindChildRecords(TreeData.tree[i].TaskID);
                }
            }
            return count;
        }

        public void Delete(int key)
        {
            TreeData.tree.Remove(TreeData.tree.Where(ds => ds.TaskID == key).FirstOrDefault());
        }

        // Remove method (batchUrl) will be triggered when we delete parent record.

        public void Remove(List<TreeData> changed, List<TreeData> added, List<TreeData> deleted)
        {
            for (var i = 0; i < deleted.Count; i++)
            {
                TreeData.tree.Remove(TreeData.tree.Where(ds => ds.TaskID == deleted[i].TaskID).FirstOrDefault());
            }
        }

        public class CustomBind : TreeData
        {
            public TreeData parentItem;
        }

        public class ICRUDModel
        {
            public TreeData value;
            public int key;
            public string action;
        }
    }
 }
