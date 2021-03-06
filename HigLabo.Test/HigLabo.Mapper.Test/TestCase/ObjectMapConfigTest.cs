﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.Core;
using System.Collections.Generic;

namespace HigLabo.Mapper.Test
{
    [TestClass]
    public class ObjectMapConfigTest
    {
        [TestMethod]
        public void ObjectMapConfig_Map_Object_Object()
        {
            var config = new ObjectMapConfig();

            var u1 = new User();

            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Name, u2.Name);
            Assert.AreEqual(u1.Int32, u2.Int32);
            Assert.AreEqual(u1.Decimal, u2.Decimal);
            Assert.AreEqual(u1.DateTime, u2.DateTime);
            Assert.AreEqual(u1.DayOfWeek, u2.DayOfWeek);

            Assert.AreEqual(u1.MapPoint.Latitude, u2.MapPoint.Latitude);
            Assert.AreEqual(u1.MapPoint.Longitude, u2.MapPoint.Longitude);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Dictionary_Object()
        {
            var config = new ObjectMapConfig();

            var d = new Dictionary<String, String>();
            d["Name"] = "N";
            d["Int32"] = "46";
            d["Decimal"] = "46.46";
            d["DateTime"] = "2014/12/17";
            d["DayOfWeek"] = "Friday";
            var u2 = config.Map(d, new User());

            Assert.AreEqual("N", u2.Name);
            Assert.AreEqual(46, u2.Int32);
            Assert.AreEqual(46.46m, u2.Decimal);
            Assert.AreEqual(new DateTime(2014, 12,17), u2.DateTime);
            Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Object_Dictionary()
        {
            var config = new ObjectMapConfig();

            var u1 = new User();
            var d = config.Map(u1, new Dictionary<String, Object>());

            Assert.AreEqual(u1.Name, d["Name"]);
            Assert.AreEqual(u1.Int32, d["Int32"]);
            Assert.AreEqual(u1.Decimal, d["Decimal"]);
            Assert.AreEqual(u1.DateTime, d["DateTime"]);
            Assert.AreEqual(u1.DayOfWeek, d["DayOfWeek"]);
            Assert.AreEqual(u1.MapPoint, d["MapPoint"]);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Object_Object_SetNullablePropertyToNull()
        {
            var config = new ObjectMapConfig();
            
            var u1 = new User();
            u1.DecimalNullable = null;
            var u2 = config.Map(u1, new User() { DecimalNullable = 23.4m });

            Assert.IsNull(u2.DecimalNullable);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Object_Object_Convert_Failure()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();

            var rule = new PropertyNameMappingRule();
            rule.PropertyNameMaps.Add("Value", "Decimal");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "abc";
            var u2 = config.Map(u1, new User());
            //Not changed...
            Assert.AreEqual(20.4m, u2.Decimal);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Dictionary_Object_Convert_Failure()
        {
            var config = new ObjectMapConfig();

            var d = new Dictionary<String, String>();
            d["Decimal"] = "abc";
            var u2 = config.Map(d, new User());
            //Not changed...
            Assert.AreEqual(20.4m, u2.Decimal);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_FromDecimalToInt32()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();

            var rule = new PropertyNameMappingRule();
            rule.PropertyNameMaps.Add("Int32", "Decimal");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Int32 = 23;
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(23m, u2.Decimal);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_List_List()
        {
            var config = new ObjectMapConfig();
            
            var l1 = new List<User>();
            l1.Capacity = 100;
            l1.Add(new User());
            var l2 = config.Map(l1, new List<User>());

            Assert.AreEqual(0, l2.Count);
            Assert.AreEqual(100, l2.Capacity);
        }
        [TestMethod]
        public void ObjectMapConfig_RemovePropertyMap()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();
            var rule = new SuffixPropertyMappingRule("Nullable");
            config.PropertyMapRules.Add(rule);
            config.RemovePropertyMap<User, User>(new String[] { "DecimalNullable", "DateTimeNullable", "DayOfWeekNullable" }, null);
            
            var u1 = new User();
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Name, u2.Name);
            Assert.AreEqual(u1.Int32, u2.Int32Nullable);
            Assert.IsNull(u2.DecimalNullable);
            Assert.IsNull(u2.DateTimeNullable);
            Assert.IsNull(u2.DayOfWeekNullable);

            Assert.AreEqual(u1.MapPoint.Latitude, u2.MapPoint.Latitude);
            Assert.AreEqual(u1.MapPoint.Longitude, u2.MapPoint.Longitude);
        }
        [TestMethod]
        public void ObjectMapConfig_CustomPropertyMappingRule()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();
            var rule = new SuffixPropertyMappingRule("Nullable");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Name, u2.Name);
            Assert.AreEqual(u1.Int32, u2.Int32Nullable);
            Assert.AreEqual(u1.Decimal, u2.DecimalNullable);
            Assert.AreEqual(u1.DateTime, u2.DateTimeNullable);
            Assert.AreEqual(u1.DayOfWeek, u2.DayOfWeekNullable);
        }
        [TestMethod]
        public void ObjectMapConfig_DefaultTypeConverter()
        {
            var config = new ObjectMapConfig();
            var rules = config.PropertyMapRules.ToArray();
            config.PropertyMapRules.Clear();

            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.PropertyNameMaps.Add("Value", "Int32");
            rule.PropertyNameMaps.Add("Value", "DateTime");
            rule.PropertyNameMaps.Add("Value", "Decimal");
            rule.PropertyNameMaps.Add("Value", "DayOfWeek");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            {
                u1.Value = "23";
                var u2 = config.Map(u1, new User());
                Assert.AreEqual(23, u2.Int32);
            }
            {
                u1.Value = "2014/12/17 00:00:00";
                var u2 = config.Map(u1, new User());
                Assert.AreEqual(new DateTime(2014, 12, 17), u2.DateTime);
            }
            {
                u1.Value = "23.4";
                var u2 = config.Map(u1, new User());
                Assert.AreEqual(23.4m, u2.Decimal);
            }
            {
                //u1.Value = "Friday";
                //var u2 = config.Map(u1, new User());
                //Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
            }
        }
        [TestMethod]
        public void ObjectMapConfig_CustomClassConverter()
        {
            var config = new ObjectMapConfig();
            config.AddConverter(MapPointConverter);

            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.PropertyNameMaps.Add("Value", "MapPoint");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "23, 45";
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(23m, u2.MapPoint.Latitude);
            Assert.AreEqual(45m, u2.MapPoint.Longitude);
        }
        [TestMethod]
        public void ObjectMapConfig_CustomStructConverter()
        {
            var config = new ObjectMapConfig();
            config.AddConverter(DayOfWeekConverter);

            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.PropertyNameMaps.Add("Value", "DayOfWeek");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "Friday";
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
        }

        private MapPoint MapPointConverter(Object obj)
        {
            if (obj is String && (String)obj != null)
            {
                var ss = obj.ToString().Split(',');
                if (ss.Length == 2)
                {
                    var p = new MapPoint();
                    p.Latitude = Decimal.Parse(ss[0].Trim());
                    p.Longitude = Decimal.Parse(ss[1].Trim());
                    return p;
                }
            }
            return null;
        }
        private DayOfWeek? DayOfWeekConverter(Object obj)
        {
            if (obj is String && (String)obj != null)
            {
                switch (obj.ToString())
                {
                    case "Monday": return DayOfWeek.Monday;
                    case "Tuesday": return DayOfWeek.Tuesday;
                    case "Wednesday": return DayOfWeek.Wednesday;
                    case "Thursday": return DayOfWeek.Thursday;
                    case "Friday": return DayOfWeek.Friday;
                    case "Saturday": return DayOfWeek.Saturday;
                    case "Sunday": return DayOfWeek.Sunday;
                    default: throw new InvalidOperationException();
                }
            }
            return null;
        }
    }
}
