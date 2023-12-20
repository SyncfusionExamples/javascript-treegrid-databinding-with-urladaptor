using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using url.Models;
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
    public class TreeData
    {
        public static List<TreeData> tree = new List<TreeData>();
        [System.ComponentModel.DataAnnotations.Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Progress { get; set; }
        public String Priority { get; set; }
        public int Duration { get; set; }
        public int? ParentItem { get; set; }
        public bool? isParent { get; set; }
        public TreeData() { }
        public static List<TreeData> GetTree()
        {
            if (tree.Count == 0)
            {
                int root = -1;
                for (var t = 1; t <= 5; t++)
                {
                    Random ran = new Random();
                    string math = (ran.Next() % 3) == 0 ? "High" : (ran.Next() % 2) == 0 ? "Release Breaker" : "Critical";
                    string progr = (ran.Next() % 3) == 0 ? "Started" : (ran.Next() % 2) == 0 ? "Open" : "In Progress";
                    root++;
                    int rootItem = tree.Count + root + 1;
                    tree.Add(new TreeData() { TaskID = rootItem, TaskName = "Parent Task " + rootItem.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), isParent = true, ParentItem = null, Progress = progr, Priority = math, Duration = (ran.Next(1, 50) * 5) });
                    int parent = tree.Count;
                    for (var c = 0; c < 3; c++)
                    {
                        root++;
                        string val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                        int parn = parent + c + 1;
                        progr = (ran.Next() % 3) == 0 ? "In Progress" : (ran.Next() % 2) == 0 ? "Open" : "Validated";
                        int iD = tree.Count + root + 1;
                        tree.Add(new TreeData() { TaskID = iD, TaskName = "Child Task " + iD.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), isParent = false, ParentItem = rootItem, Progress = progr, Priority = val, Duration = ran.Next(1, 50) });
                        if ((((parent + c + 1) % 2) == 0))
                        {
                            int immParent = tree.Count;
                            for (var s = 0; s < 2; s++)
                            {
                                root++;
                                string Prior = (immParent % 2 == 0) ? "Validated" : "Normal";
                                tree.Add(new TreeData() { TaskID = tree.Count + root + 1, TaskName = "Sub Task " + (tree.Count + root + 1).ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), isParent = false, ParentItem = iD, Progress = (immParent % 2 == 0) ? "On Progress" : "Closed", Priority = Prior, Duration = ran.Next(1, 50) });
                            }
                        }
                    }
                }
            }
            return tree;
        }
    }
}
