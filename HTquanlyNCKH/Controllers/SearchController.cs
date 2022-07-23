using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HTquanlyNCKH.Models;
using System.IO;
using PagedList;

namespace HTquanlyNCKH.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult TopicSearch(int? pageID, string key, FormCollection collection)
        {
            using (DBModel db = new DBModel())
            {
                var _TopicFull = from tpc in db.Topics                                        //Lấy bảng lớn Topic là đề tài nghiên cứu
                                join sct in db.Scientists on tpc.scientistID equals sct.scientistID     //Nối đến bảng nhà khoa học
                                join cls in db.Classifications on tpc.classifiID equals cls.classifiID  //Nối đến bảng xếp loại đề tài
                                join sts in db.Status on tpc.statusID equals sts.statusID               //Nối đến bảng trạng thái
                                join fie in db.Fields on tpc.fieldID equals fie.fieldID                 //Nối đến bảng lĩnh vực
                                select new TopicFull()     // [W-A-R-N-I-N-G] những chỗ có liên kết các trường là khoá ngoại ở trên không được để NULL, cho nên nếu các hàng có hậu tố Name bên dưới RỖNG sẽ sinh lỗi không load lên được cả hàng đó
                                {
                                    topicID = tpc.topicID,                                  //Mã số đề tài
                                    scientistID = sct.scientistID,
                                    scientistName = sct.sctFirstName + " " + sct.sctLastName,     //Tên đầy đủ nhà khoa học
                                    classifiName = cls.clsName,                             //Tên xếp loại
                                    statusName = sts.stsName,                               //Trạng thái
                                    fieldName = fie.fieName,                                //Lĩnh vực

                                    //Phía trên là nối bảng

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

                ViewBag.KiemTra = "0";
                if (!string.IsNullOrEmpty(key))
                {
                    ViewBag.key = key;

                    var TopicList = from p in _TopicFull.OrderByDescending(p => p.topicID)

                                .Where(p => p.tpcName.Contains(key) || p.tpcCode.Contains(key))
                                .OrderBy(p => p.topicID)
                                    select p;
                    ViewBag.Pages = TopicList;
                    //Đếm số lượng kết quả tìm kiếm
                    var _slkq = TopicList.Count();
                    ViewBag.slkq = _slkq;
                    //Phân trang
                    int pagesize = 4;
                    int pageindex = pageID ?? 1;
                    ViewBag.KiemTra = "1";
                    return View(TopicList.ToList().ToPagedList(pageindex, pagesize));
                }
                else 
                {
                    var TopicList = from p in _TopicFull.OrderByDescending(p => p.topicID) select p;
                    //Phân trang
                    int pagesize = 4;
                    int pageindex = pageID ?? 1;
                    ViewBag.KiemTra = "1";
                    return View(TopicList.ToList().ToPagedList(pageindex, pagesize));
                } 
            }
               
        }

        public ActionResult ScientistSearch(int? pageID, string key, FormCollection collection)
        {
            using (DBModel db = new DBModel())
            {
                var ScientistList = from sct in db.Scientists                                        //Lấy bảng nhà khoa học
                                    join pla in db.Places on sct.PlaceID equals pla.placeID          //Nối bảng địa chỉ (tỉnh)
                                    join deg in db.Degrees on sct.degreeID equals deg.degreeID       //Nối bảng học vị
                                    join unt in db.Units on sct.unitID equals unt.unitID             //Nối bảng phòng ban
                                    join fie in db.Fields on sct.fieldID equals fie.fieldID          //Nối bảng chuyên nghành
                                    join frg in db.Foreigns on sct.foreignID equals frg.foreignID //Nối bảng ngoại ngữ
                                    select new ScientistFull()      // [W-A-R-N-I-N-G] những chỗ có liên kết các trường dữ liệu là khoá ngoại ở trên không được để NULL. Tương ứng, nếu các hàng có hậu tố Name bên dưới RỖNG sẽ sinh lỗi không load lên được cả hàng đó
                                    {
                                        scientistID = sct.scientistID,              //Mã số nhà khoa học
                                        sctFirstName = sct.sctFirstName,            //Họ và tên đệm
                                        sctLastName = sct.sctLastName,              //Tên
                                       
                                        sctSex = sct.sctSex,                        //Giới tính
                                        sctBirthday = sct.sctBirthday,              //Ngày sinh                                                                            
                                        PlaceName = pla.plaName,                    //Địa chỉ (tỉnh)
                                        sctImage = sct.sctImage,                    //Ảnh chân dung
                                        degreeName = deg.degName,                   //Học vị vd: đại học, thạc sĩ
                                        unitName = unt.untName,                     //Phòng ban
                                        fieldName = fie.fieName,                    //Chuyên ngành
                                        sctWorkingProcess = sct.sctWorkingProcess,  //Quá trình công tác
                                        sctResult = sct.sctResult,                  //Kết quả nghiên cứu
                                        sctForeignName = frg.fgnName,               //Trình độ ngoại ngữ
                                        sctAddress = sct.sctAddress,                //Địa chỉ thường trú
                                        sctPhone = sct.sctPhone,                    //Số điện thoại
                                        sctEmail = sct.sctEmail,                    //Email
                                        sctCreateDate = sct.sctCreateDate,          //Thời gian khởi tạo
                                        sctModifierDate = sct.sctModifierDate,      //Thời gian thay đổi
                                        sctCreateUser = sct.sctCreateUser,          //Người khởi tạo
                                        sctModifierUser = sct.sctModifierUser,      //Người thay đổi

                                    };

                ViewBag.KiemTra = "0";
                if (!string.IsNullOrEmpty(key))
                {
                    ViewBag.key = key;

                    var sctList = from p in ScientistList.OrderByDescending(p => p.scientistID)
                                  
                                .Where(p => p.sctFirstName.Contains(key) || p.scientistID.ToString().Contains(key) || p.sctLastName.Contains(key))
                                .OrderBy(p => p.scientistID)
                                    select p;
                    ViewBag.Pages = sctList;

                    //Đếm số lượng kết quả tìm kiếm
                    ViewBag.slkq = sctList.Count(); 
                    
                    //Phân trang
                    int pagesize = 4;
                    int pageindex = pageID ?? 1;
                    ViewBag.KiemTra = "1";
                    return View(sctList.ToList().ToPagedList(pageindex, pagesize));
                }
                else
                {
                    var sctList = from p in ScientistList.OrderByDescending(p => p.scientistID) select p;
                    //Phân trang
                    int pagesize = 4;
                    int pageindex = pageID ?? 1;
                    ViewBag.KiemTra = "1";
                    return View(sctList.ToList().ToPagedList(pageindex, pagesize));
                }
            }

        }
    }
   
}