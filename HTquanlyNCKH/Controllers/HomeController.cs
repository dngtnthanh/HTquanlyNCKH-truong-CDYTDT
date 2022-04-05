using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTquanlyNCKH.Models;
using System.Data.Entity;
using PagedList;
namespace HTquanlyNCKH.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();        
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public JsonResult GetCountries()
        //{
        //    var Countries = new List<string>();
        //    Countries.Add("Australia");
        //    Countries.Add("India");
        //    Countries.Add("Russia");
        //    return Json(Countries, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetCountries()    
        {
            using (DBModel db = new DBModel())
            {
                List<Classification> cls = db.Classifications.ToList<Classification>();
                var Countries = cls.Select(n => n.clsName);
                return Json(Countries, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GetStates(string country)
        {
            var States = new List<string>();
            if (!string.IsNullOrWhiteSpace(country))
            {
                if (country.Equals("Australia"))
                {
                    States.Add("Sydney");
                    States.Add("Perth");
                }
                if (country.Equals("India"))
                {
                    States.Add("Delhi");
                    States.Add("Mumbai");
                }
                if (country.Equals("Russia"))
                {
                    States.Add("Minsk");
                    States.Add("Moscow");
                }
            }
            return Json(States, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Topic(int? pageID)
        {
            using (DBModel db = new DBModel())
            {
                var TopicList = from tpc in db.Topics                                        //Nối từ bảng lớn Topic là đề tài đến các bảng nhỏ
                            join sct in db.Scientists on tpc.scientistID equals sct.scientistID     //Nối đến bảng nhà khoa học
                            join cls in db.Classifications on tpc.classifiID equals cls.classifiID  //Nối đến bảng xếp loại đề tài
                            join sts in db.Status on tpc.statusID equals sts.statusID               //Nối đến bảng trạng thái
                            join fie in db.Fields on tpc.fieldID equals fie.fieldID                 //Nối đến bảng lĩnh vực
                            select new TopicFull()                                      //lưu vào một bảng Full tất cả các thông tin đề tài
                            {
                                topicID = tpc.topicID,                                  //Mã số đề tài
                                scientistName = sct.sctFirstName + sct.sctLastName,     //Tên đầy đủ nhà khoa học
                                classifiName = cls.clsName,                             //Tên xếp loại
                                statusName = sts.stsName,                               //Trạng thái
                                fieldName = fie.fieName,                                //Lĩnh vực

                                tpcYear = tpc.tpcYear,                                  //Năm thực hiện
                                tpcName = tpc.tpcName,                                  //Tên đề tài
                                tpcSummary = tpc.tpcSummary,                            //Tóm tắt sơ lượt
                                tpcCode = tpc.tpcCode,                                  //Mã số
                                tpcStartDate = tpc.tpcStartDate,                        //Ngày bắt đầu thực hiện
                                tpcEndDate = tpc.tpcEndDate,                            //Ngày kết thúc
                                tpcDateOfAcceptance = tpc.tpcDateOfAcceptance,          //Ngày nghiệm thu
                                tpcProofFile = tpc.tpcProofFile,                        //Tệp minh chứng
                                tpcReviewBoard = tpc.tpcReviewBoard,                    //Hội đồng nghiệm thu
                                tpcCreateData = tpc.tpcCreateData,                      //Thời gian khởi tạo
                                tpcModifierData = tpc.tpcModifierData,                  //Thời gian thay đổi
                                tpcCreateUser = tpc.tpcCreateUser,                      //Người khởi tạo
                                tpcModifierUser = tpc.tpcModifierUser,                  //Người thay đổi
                                tpcDeleteData = tpc.tpcDeleteData,                      //Thời gian xoá
                                tpcDeleteUser = tpc.tpcDeleteUser,                      //Người xoá
                                tpcImage = tpc.tpcImage,                                //Ảnh bìa
                            };
                
                int pagesize = 4;                   //Hiển thị 4 đơn vị trên mỗi trang
                int pageindex = pageID ?? 1;        //Mặc định xem trang 1 đầu tiên
                return View(TopicList.ToList().ToPagedList(pageindex, pagesize));
            }
        }        
        public ActionResult Scientist(int? pageID)     //Trang nhà khoa học
        {
            using (DBModel db = new DBModel())
            {
                //var scientistList = from p in db.Scientists.OrderBy(n => n.scientistID) select p;       //Lấy danh sách nhà khoa học

                var scientistList = from sct in db.Scientists
                                    join pla in db.Places on sct.PlaceID equals pla.placeID
                                    join deg in db.Degrees on sct.degreeID equals deg.degreeID
                                    join unt in db.Units on sct.unitID equals unt.unitID
                                    join fie in db.Fields on sct.fieldID equals fie.fieldID
                                    join frg in db.Foreigns on sct.sctForeignID equals frg.foreignID
                                    select new ScientistFull()
                                    {
                                        scientistID = sct.scientistID,
                                        sctFirstName = sct.sctFirstName,
                                        sctLastName = sct.sctLastName,
                                        sctSex = sct.sctSex,
                                        sctBirthday = sct.sctBirthday,
                                        PlaceName = pla.plaName,
                                        degreeName = deg.degName,
                                        unitName = unt.untName,
                                        fieldName = fie.fieName,
                                        sctWorkingProcess = sct.sctWorkingProcess,
                                        sctResult = sct.sctResult,
                                        sctForeignName = frg.fgnName,
                                        sctAddress = sct.sctAddress,
                                        sctPhone = sct.sctPhone,
                                        sctEmail = sct.sctEmail,
                                        sctCreateDate = sct.sctCreateDate,
                                        sctModifierDate = sct.sctModifierDate,
                                        sctCreateUser = sct.sctCreateUser,
                                        sctModifierUser = sct.sctModifierUser,
                                    };

                int pagesize = 2;       //Hiển thị đơn vị dữ liệu trên mỗi trang (Phân trang)
                int pageindex = pageID ?? 1;        //Trang mặc định là 1 (Phân trang)
                return View(scientistList.ToList().ToPagedList(pageindex, pagesize));
            }
        }
    }
}