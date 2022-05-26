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
        public ActionResult Index(int? pageID)
        {
            using (DBModel db = new DBModel())
            {
                var TopicList = from tpc in db.Topics                                        //Lấy bảng lớn Topic là đề tài nghiên cứu
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

                int pagesize = 4;                   //Hiển thị 4 đơn vị trên mỗi trang  (phân trang)
                int pageindex = pageID ?? 1;        //Mặc định xem trang 1 đầu tiên (phân trang)
                return View(TopicList.OrderByDescending(n => n.topicID).ToList().ToPagedList(pageindex, pagesize));   //Trả về danh sách đề tài có có (phân trang)
            }
                 
        }

       

        public ActionResult Topic(int? pageID)  // Trang danh sách đề tài (truyền vào mã số phân trang)
        {
            using (DBModel db = new DBModel())
            {
                var TopicList = from tpc in db.Topics                                        //Lấy bảng lớn Topic là đề tài nghiên cứu
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
                
                int pagesize = 4;                   //Hiển thị 4 đơn vị trên mỗi trang  (phân trang)
                int pageindex = pageID ?? 1;        //Mặc định xem trang 1 đầu tiên (phân trang)
                
                return View(TopicList.OrderByDescending(n => n.topicID).ToList().ToPagedList(pageindex, pagesize));   //Trả về danh sách đề tài có có (phân trang)
            }
        }        
        public ActionResult Scientist(int? pageID)     //Trang danh sách nhà khoa học (truyền vào mã số phân trang)
        {
            using (DBModel db = new DBModel())
            {
                var ScientistList = from sct in db.Scientists                                        //Lấy bảng nhà khoa học
                                    join pla in db.Places on sct.PlaceID equals pla.placeID          //Nối bảng địa chỉ (tỉnh)
                                    join deg in db.Degrees on sct.degreeID equals deg.degreeID       //Nối bảng học vị
                                    join unt in db.Units on sct.unitID equals unt.unitID             //Nối bảng phòng ban
                                    join fie in db.Fields on sct.fieldID equals fie.fieldID          //Nối bảng chuyên nghành
                                    join frg in db.Foreigns on sct.foreignID equals frg.foreignID //Nối bảng ngoại ngữ
                                    
                                    select new ScientistFull()      // [W-A-R-N-I-N-G] những chỗ có liên kết các trường dữ liệu là khoá ngoại ở trên không được để NULL, nếu các hàng có hậu tố Name bên dưới RỖNG sẽ sinh lỗi không load lên được cả hàng đó
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

                int pagesize = 4;       //Hiển thị 4 đơn vị dữ liệu trên mỗi trang (Phân trang)
                int pageindex = pageID ?? 1;        //Trang mặc định là 1 (Phân trang)
                return View(ScientistList.OrderByDescending(n => n.scientistID).ToList().ToPagedList(pageindex, pagesize));   //Trả về danh sách nhà khoa học có (Phân trang)
            }
        }
        [HttpGet]
        public ActionResult TopicInfor(int? id)     //Hiện Popup thông tin đề tài (truyền vào mã số topicID đề tài nghiên)
        {
            using (DBModel db = new DBModel())
            {
                var TopicList = from tpc in db.Topics                                        //Lấy bảng lớn Topic là đề tài nghiên cứu
                                join sct in db.Scientists on tpc.scientistID equals sct.scientistID     //Nối đến bảng nhà khoa học
                                join cls in db.Classifications on tpc.classifiID equals cls.classifiID  //Nối đến bảng xếp loại đề tài
                                join sts in db.Status on tpc.statusID equals sts.statusID               //Nối đến bảng trạng thái
                                join fie in db.Fields on tpc.fieldID equals fie.fieldID                 //Nối đến bảng lĩnh vực
                                where(tpc.topicID == id)
                                select new TopicFull()     // [W-A-R-N-I-N-G] những chỗ có liên kết các trường là khoá ngoại ở trên không được để NULL, cho nên nếu các hàng có hậu tố Name bên dưới RỖNG sẽ sinh lỗi không load lên được cả hàng đó
                                {
                                    topicID = tpc.topicID,                                  //Mã số đề tài
                                    scientistID = sct.scientistID,
                                    scientistName = sct.sctFirstName + " " + sct.sctLastName,     //Tên đầy đủ nhà khoa học
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


                var topicob = db.Topics.SingleOrDefault(n => n.topicID == id); //lấy thông tin đề tài nghiên cứu
                
                if (topicob.tpcStartDate != null)
                {
                    ViewBag.ngaybatdau = Convert.ToDateTime(topicob.tpcStartDate).ToString("yyyy-MM-dd");
                }
                else
                {
                    ViewBag.ngaybatdau = null;
                }

                if (topicob.tpcDateOfAcceptance != null)
                {
                    ViewBag.ngaynghiemthu = Convert.ToDateTime(topicob.tpcDateOfAcceptance).ToString("yyyy-MM-dd");
                }
                else
                {
                    ViewBag.ngaynghiemthu = null;
                }

                if (topicob.tpcEndDate != null)
                {
                    ViewBag.ngayketthuc = Convert.ToDateTime(topicob.tpcEndDate).ToString("yyyy-MM-dd");
                }
                else
                {
                    ViewBag.ngayketthuc = null;
                }

                return View(TopicList.Single(n => n.topicID == id));                        //Trả về đề tài có mã số tương ứng ID truyền vào
            }

        }

        public ActionResult ScientistInfor(int? id)     //Hiện Popup thông tin nhà khoa học (truyền vào mã số scientistID nhà khoa học
        {
            using (DBModel db = new DBModel())
            {
                var ScientistList = from sct in db.Scientists                                        //Lấy bảng nhà khoa học
                                    join pla in db.Places on sct.PlaceID equals pla.placeID          //Nối bảng địa chỉ (tỉnh)
                                    join deg in db.Degrees on sct.degreeID equals deg.degreeID       //Nối bảng học vị
                                    join unt in db.Units on sct.unitID equals unt.unitID             //Nối bảng phòng ban
                                    join fie in db.Fields on sct.fieldID equals fie.fieldID          //Nối bảng chuyên nghành
                                    join frg in db.Foreigns on sct.foreignID equals frg.foreignID //Nối bảng chức vụ
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
                //var TpcList = db.Topics.Where(n => n.scientistID == id);
                //string sctTopic = "";
                //foreach (var item in TpcList)
                //{
                //    sctTopic +=  "<a href='https://localhost:44386/Home/TopicInfor/"+ item.topicID +"'>" + item.tpcName + " </a> "   + "</br> ";
                //}
                //ViewBag.sctDeTai =  sctTopic;
                //var TpcList = db.Topics.Where(n => n.scientistID == id);
                //var ArtList = db.Articles.Where(n => n.scientistID == id);
                //ViewBag.tpcNumber = TpcList.Count() + 1;

                //ViewBag.artNumber = ArtList.Count() + 1;

                var scientistob = db.Scientists.SingleOrDefault(n => n.scientistID == id); //lấy thông tin nhà khoa học

                if (scientistob.sctBirthday != null)
                {
                    ViewBag.ngaysinh = Convert.ToDateTime(scientistob.sctBirthday).ToString("dd-MM-yyyy");
                }
                else
                {
                    ViewBag.ngaysinh = null;
                }
                ViewBag.maso = "KH" + scientistob.scientistID.ToString();

                return View(ScientistList.Single(n => n.scientistID == id));        //Trả về thông tin nhà khoa học tương ứng mã số ID truyền vào
            }
        }
        public ActionResult ArticlesInfor(int id)
        {
            using (DBModel db = new DBModel())
            {
                var ArticlesList = from arl in db.Articles
                                   join sct in db.Scientists on arl.scientistID equals sct.scientistID //Noi bang nha khoa hoc
                                   join nat in db.Nations on arl.nationID equals nat.nationID           //Noi bang quoc gia
                                   join key in db.KeyWords on arl.keyID equals key.keyID                //noi bang tu khoa
                                   join tpe in db.ArtTypes on arl.typeID equals tpe.typeID              //noi bang loai bai viet
                                   join fie in db.Fields on arl.fieldID equals fie.fieldID              //noi bang linh vuc nghien cuu
                                   select new ArticleFull()
                                   {
                                       articlesID = arl.articlesID,
                                       scientistID = sct.scientistID,
                                       atlName = arl.atlName,
                                       scientistName = sct.sctFirstName + " " + sct.sctLastName,
                                       nationName = nat.natName,
                                       atlSummary = arl.atlSummary,
                                       keyName = key.keyName,
                                       typeName = tpe.typName,
                                       Point = arl.Point,
                                       atlLink = arl.atlLink,
                                       atlPublication = arl.atlPublication,
                                       atlPublicationDate = arl.atlPublicationDate,
                                       atlNumber = arl.atlNumber,
                                       atlPageToPage = arl.atlPageToPage,
                                       atlCreateDate = arl.atlCreateDate,
                                       atlModifierDate = arl.atlModifierDate,
                                       atlCreateUser = arl.atlCreateUser,
                                       atlModifierUser = arl.atlModifierUser,


                                   };
                return View(ArticlesList.Single(n => n.articlesID == id));
            }
            
        }
        //Quản lý bài báo quốc tế của nhà khoa học
        public ActionResult ArticlesGetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Article> articlesList = db.Articles.ToList<Article>();
                return Json(new { data = articlesList },
                    JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Articles()
        {
            return View();
        }
        public ActionResult ArticlesPopup(int id)
        {

            using (DBModel db = new DBModel())
            {
                var ArticlesList = from arl in db.Articles
                                   join sct in db.Scientists on arl.scientistID equals sct.scientistID //Noi bang nha khoa hoc
                                   join nat in db.Nations on arl.nationID equals nat.nationID           //Noi bang quoc gia
                                   join key in db.KeyWords on arl.keyID equals key.keyID                //noi bang tu khoa
                                   join tpe in db.ArtTypes on arl.typeID equals tpe.typeID              //noi bang loai bai viet
                                   join fie in db.Fields on arl.fieldID equals fie.fieldID              //noi bang linh vuc nghien cuu
                                   select new ArticleFull()
                                   {
                                       articlesID = arl.articlesID,
                                       scientistID = sct.scientistID,
                                       atlName = arl.atlName,
                                       scientistName = sct.sctFirstName + " " + sct.sctLastName,
                                       nationName = nat.natName,
                                       atlSummary = arl.atlSummary,
                                       keyName = key.keyName,
                                       typeName = tpe.typName,
                                       Point = arl.Point,
                                       atlLink = arl.atlLink,
                                       atlPublication = arl.atlPublication,
                                       atlPublicationDate = arl.atlPublicationDate,
                                       atlNumber = arl.atlNumber,
                                       atlPageToPage = arl.atlPageToPage,
                                       atlCreateDate = arl.atlCreateDate,
                                       atlModifierDate = arl.atlModifierDate,
                                       atlCreateUser = arl.atlCreateUser,
                                       atlModifierUser = arl.atlModifierUser,


                                   };
                return View(ArticlesList.Single(n => n.articlesID == id));
            }

        }

        public ActionResult Index2()
        {
            List<SelectListItem> customerList = GetCustomers();
            ViewBag.mn = customerList.ToList();
            return View(customerList);
        }

        [HttpPost]
        public ActionResult Index2(string ddlCustomers)
        {
            List<SelectListItem> customerList = GetCustomers();
            if (!string.IsNullOrEmpty(ddlCustomers))
            {
                SelectListItem selectedItem = customerList.Find(p => p.Value == ddlCustomers);
                ViewBag.Message = "Name: " + selectedItem.Text;
                ViewBag.Message += "\\nID: " + selectedItem.Value;
            }
            return View(customerList);
        }

        private static List<SelectListItem> GetCustomers()
        {
            DBModel entities = new DBModel();
             
            List<SelectListItem> customerList = (from p in entities.Scientists.AsEnumerable()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.sctFullName,
                                                     Value = p.scientistID.ToString()
                                                 }).ToList();

            
            //Add Default Item at First Position.
            customerList.Insert(0, new SelectListItem { Text = "--Select Customer--", Value = "" });

            return customerList;
        }
    }
}
