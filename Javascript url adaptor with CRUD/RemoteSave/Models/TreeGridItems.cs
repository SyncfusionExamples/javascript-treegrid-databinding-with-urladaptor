using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RemoteSave.Models
{
    public class TreeGridItems
    {
        public TreeGridItems() { }
        public int TaskId { get; set; }

        public string TaskName { get; set; }

        public DateTime USAActiveDate { get; set; }

        public DateTime USAInactiveDate { get; set; }

        public int Duration { get; set; }

        public int Progress { get; set; }
        public string Priority { get; set; }
        public bool Approved { get; set; }

        public DateTime InternationalActiveDate { get; set; }
        public DateTime InternationalInactiveDate { get; set; }

        public List<TreeGridItems> Children { get; set; }

        public int? ParentId { get; set; }

        public static List<TreeGridItems> GetTreeData()
        {
            List<TreeGridItems> BusinessObjectCollection = new List<TreeGridItems>();

            TreeGridItems Record1 = null;

            Record1 = new TreeGridItems()
            {
                TaskId = 1,
                TaskName = "Planning",
                USAActiveDate = new DateTime(2016, 06, 07),
                USAInactiveDate = new DateTime(2021, 08, 25),
                Progress = 100,
                Duration = 5,
                Priority = "Normal",
                Approved = false,
                InternationalActiveDate = new DateTime(2017, 02, 03),
                InternationalInactiveDate = new DateTime(2017, 02, 07),
                Children = new List<TreeGridItems>(),
            };

            TreeGridItems Child1 = new TreeGridItems()
            {
                TaskId = 2,
                TaskName = "Plan timeline",
                USAActiveDate = new DateTime(2016, 06, 07),
                USAInactiveDate = new DateTime(2021, 08, 25),
                Progress = 100,
                Duration = 5,
                Priority = "Normal",
                Approved = false,
                InternationalActiveDate = new DateTime(2017, 02, 03),
                InternationalInactiveDate = new DateTime(2017, 02, 07),
            };

            TreeGridItems Child2 = new TreeGridItems()
            {
                TaskId = 3,
                TaskName = "Plan budget",
                USAActiveDate = new DateTime(2016, 06, 07),
                USAInactiveDate = new DateTime(2021, 08, 25),
                Duration = 5,
                Priority = "Critical",
                Progress = 100,
                Approved = true,
                InternationalActiveDate = new DateTime(2017, 02, 03),
                InternationalInactiveDate = new DateTime(2017, 02, 07),
            };

            TreeGridItems Child3 = new TreeGridItems()
            {
                TaskId = 4,
                TaskName = "Allocate resources",
                USAActiveDate = new DateTime(2016, 06, 07),
                USAInactiveDate = new DateTime(2021, 08, 25),
                Duration = 5,
                Progress = 100,
                Priority = "Critical",
                InternationalActiveDate = new DateTime(2017, 02, 03),
                InternationalInactiveDate = new DateTime(2017, 02, 07),
                Approved = false
            };

            TreeGridItems Child4 = new TreeGridItems()
            {
                TaskId = 5,
                TaskName = "Planning complete",
                USAActiveDate = new DateTime(2021, 08, 25),
                USAInactiveDate = new DateTime(2021, 08, 25),
                Duration = 3,
                Progress = 25,
                Priority = "Low",
                InternationalActiveDate = new DateTime(2017, 02, 07),
                InternationalInactiveDate = new DateTime(2017, 02, 07),
                Approved = true
            };
            TreeGridItems Child5 = new TreeGridItems()
            {
                TaskId = 7,
                TaskName = "Software Specification",
                USAActiveDate = new DateTime(2021, 08, 25),
                USAInactiveDate = new DateTime(2024, 06, 27),
                Duration = 3,
                Progress = 60,
                Priority = "Normal",
                InternationalActiveDate = new DateTime(2017, 02, 10),
                InternationalInactiveDate = new DateTime(2017, 02, 12),
                Approved = false
            };


            Record1.Children.Add(Child1);
            Record1.Children.Add(Child2);
            Record1.Children.Add(Child3);
            Record1.Children.Add(Child4);
            Record1.Children.Add(Child5);

            BusinessObjectCollection.Add(Record1);
           

            return BusinessObjectCollection;
        }

        public static List<object> GetTemplateData()
        {
            List<Object> DataCollection = new List<object>();
            List<Object> Child111 = new List<object>();
            Child111.Add(new
            {
                Name = "Andrew Fuller",
                FullName = "AndrewFuller",
                Designation = "Sales Representative",
                EmployeeID = "4",
                EmpID = "EMP045",
                Address = "14 Garrett Hill, London",
                Contact = "(71) 555-4848",
                Country = "UK",
                DOB = new DateTime(1980, 9, 20)
            });
            Child111.Add(new
            {
                Name = "Anne Dodsworth",
                FullName = "AnneDodsworth",
                Designation = "Sales Representative",
                EmployeeID = "5",
                EmpID = "EMP091",
                Address = "4726 - 11th Ave. N.E., Seattle",
                Contact = "(206) 555-1189",
                Country = "USA",
                DOB = new DateTime(1989, 10, 19)
            });
            Child111.Add(new
            {
                Name = "Michael Suyama",
                FullName = "MichaelSuyama",
                Designation = "Sales Representative",
                EmployeeID = "6",
                EmpID = "EMP110",
                Address = "Coventry House Miner Rd., London",
                Contact = "(71) 555-3636",
                Country = "UK",
                DOB = new DateTime(1987, 11, 02)
            });
            Child111.Add(new
            {
                Name = "Janet Leverling",
                FullName = "JanetLeverling",
                Designation = "Sales Coordinator",
                EmployeeID = "7",
                EmpID = "EMP131",
                Address = "Edgeham Hollow Winchester Way, London",
                Contact = "(71) 555-3636",
                Country = "UK",
                DOB = new DateTime(1090, 11, 06)
            });
            List<Object> Child11 = new List<object>();
            Child11.Add(new
            {
                Name = "Nancy Davolio",
                FullName = "NancyDavolio",
                Designation = "Marketing Executive",
                EmployeeID = "3",
                EmpID = "EMP035",
                Address = "4110 Old Redmond Rd., Redmond",
                Contact = "(206) 555-8122",
                Country = "USA",
                DOB = new DateTime(1966, 3, 19),
                Children = Child111
            });
            List<Object> Child112 = new List<object>();
            Child112.Add(new
            {
                Name = "Margaret Peacock",
                FullName = "MargaretPeacock",
                Designation = "Sales Representative",
                EmployeeID = "9",
                EmpID = "EMP213",
                Address = "4726 - 11th Ave. N.E., California",
                Contact = "(206) 555-1989",
                Country = "USA",
                DOB = new DateTime(1986, 1, 21)
            });
            Child112.Add(new
            {
                Name = "Steven Buchanan",
                FullName = "StevenBuchanan",
                Designation = "Sales Representative",
                EmployeeID = "11",
                EmpID = "EMP197",
                Address = "200 Lincoln Ave, Salinas, CA 93901",
                Contact = "(831) 758-7408",
                Country = "USA",
                DOB = new DateTime(1987, 3, 23)
            });
            Child112.Add(new
            {
                Name = "Tedd Lawson",
                FullName = "TeddLawson",
                Designation = "Sales Representative",
                EmployeeID = "12",
                EmpID = "EMP167",
                Address = "200 Lincoln Ave, Salinas, CA 93901",
                Contact = "(831) 758-7368",
                Country = "USA",
                DOB = new DateTime(1989, 8, 9)
            });
            Child11.Add(new
            {
                Name = "Romey Wilson",
                FullName = "RomeyWilson",
                Designation = "Sales Executive",
                EmployeeID = "8",
                EmpID = "EMP039",
                Address = "7 Houndstooth Rd., London",
                Contact = "(71) 555-3690",
                Country = "UK",
                DOB = new DateTime(1980, 2, 2),
                Children = Child112
            });
            List<Object> Child1 = new List<object>();
            Child1.Add(new
            {
                Name = "David william",
                FullName = "DavidWilliam",
                Designation = "Vice President",
                EmployeeID = "2",
                EmpID = "EMP004",
                Address = "722 Moss Bay Blvd., Kirkland",
                Contact = "(206) 555-3412",
                Country = "USA",
                DOB = new DateTime(1971, 5, 20),
                Children = Child11
            });
            DataCollection.Add(new
            {
                Name = "Robert King",
                FullName = "RobertKing",
                Designation = "Chief Executive Officer",
                EmployeeID = "1",
                EmpID = "EMP001",
                Address = "507 - 20th Ave. E.Apt. 2A, Seattle",
                Contact = "(206) 555-9857",
                Country = "USA",
                DOB = new DateTime(1963, 2, 15),
                Children = Child1
            });
            return DataCollection;
        }
        public static List<TreeGridItems> GetSelfData()
        {
            List<TreeGridItems> BusinessObjectCollection = new List<TreeGridItems>();
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 1,
                TaskName = "Parent Task 1",
                USAActiveDate = new DateTime(2017, 10, 23),
                USAInactiveDate = new DateTime(2017, 11, 27),
                Duration = 10,
                Progress = 70,
                Priority = "Critical",
                ParentId = null
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 2,
                TaskName = "Child task 1",
                USAActiveDate = new DateTime(2017, 10, 23),
                USAInactiveDate = new DateTime(2017, 12, 25),
                Duration = 4,
                Progress = 80,
                Priority = "Low",
                ParentId = 1
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 3,
                TaskName = "Child Task 2",
                USAActiveDate = new DateTime(2017, 10, 24),
                USAInactiveDate = new DateTime(2018, 03, 19),
                Duration = 5,
                Progress = 65,
                Priority = "High",
                ParentId = 1
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 4,
                TaskName = "Child task 3",
                USAActiveDate = new DateTime(2017, 10, 25),
                USAInactiveDate = new DateTime(2018, 10, 26),
                Duration = 6,
                Progress = 77,
                Priority = "Low",
                ParentId = 1
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 5,
                TaskName = "Parent Task 2",
                USAActiveDate = new DateTime(2017, 10, 23),
                USAInactiveDate = new DateTime(2018, 10, 27),
                Duration = 10,
                Progress = 70,
                Priority = "Breaking",
                ParentId = null
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 6,
                TaskName = "Child task 1",
                USAActiveDate = new DateTime(2017, 10, 23),
                USAInactiveDate = new DateTime(2017, 12, 19),
                Duration = 4,
                Progress = 80,
                Priority = "Normal",
                ParentId = 5
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 7,
                TaskName = "Child Task 2",
                USAActiveDate = new DateTime(2017, 10, 24),
                USAInactiveDate = new DateTime(2017, 11, 20),
                Duration = 5,
                Priority = "High",
                Progress = 65,
                ParentId = 5
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 8,
                TaskName = "Child task 3",
                USAActiveDate = new DateTime(2017, 10, 25),
                USAInactiveDate = new DateTime(2018, 11, 20),
                Duration = 6,
                Priority = "High",
                Progress = 77,
                ParentId = 5
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 9,
                TaskName = "Child task 4",
                USAActiveDate = new DateTime(2017, 10, 25),
                USAInactiveDate = new DateTime(2018, 03, 19),
                Duration = 6,
                Progress = 77,
                Priority = "Low",
                ParentId = 5
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 10,
                TaskName = "Parent Task 3",
                USAActiveDate = new DateTime(2017, 10, 23),
                USAInactiveDate = new DateTime(2018, 03, 25),
                Duration = 10,
                Progress = 70,
                Priority = "Normal",
                ParentId = null
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 11,
                TaskName = "Child task 1",
                USAActiveDate = new DateTime(2017, 10, 23),
                Duration = 4,
                USAInactiveDate = new DateTime(2017, 10, 30),
                Priority = "Low",
                Progress = 80,
                ParentId = 10
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 12,
                TaskName = "Child Task 2",
                USAActiveDate = new DateTime(2017, 10, 24),
                USAInactiveDate = new DateTime(2018, 11, 19),
                Duration = 5,
                Progress = 65,
                Priority = "Critical",
                ParentId = 10
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 13,
                TaskName = "Child task 3",
                USAActiveDate = new DateTime(2017, 10, 25),
                USAInactiveDate = new DateTime(2017, 11, 10),
                Duration = 6,
                Progress = 77,
                Priority = "Critical",
                ParentId = 10
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 14,
                TaskName = "Child task 4",
                USAActiveDate = new DateTime(2017, 10, 25),
                USAInactiveDate = new DateTime(2017, 11, 12),
                Duration = 6,
                Progress = 77,
                Priority = "High",
                ParentId = 10
            });
            BusinessObjectCollection.Add(new TreeGridItems()
            {
                TaskId = 15,
                TaskName = "Child task 5",
                USAActiveDate = new DateTime(2017, 10, 25),
                USAInactiveDate = new DateTime(2017, 11, 23),
                Duration = 6,
                Progress = 77,
                Priority = "Low",
                ParentId = 10
            });

            return BusinessObjectCollection;
        }

    }
}
