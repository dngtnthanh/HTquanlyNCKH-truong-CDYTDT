using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTquanlyNCKH.Models;

namespace HTquanlyNCKH.Models
{


    public class TopicFull      //Đầy đủ thông tin đề tài
    {
        public int topicID { get; set; }
        public int scientistID { get; set; }
        public string scientistName { get; set; }
        public string classifiName { get; set; }
        public string statusName { get; set; }
        public string acceptsName { get; set; }
        public string fieldName { get; set; }

        public string tpcYear { get; set; }
        public string tpcName { get; set; }
        public string tpcSummary { get; set; }
        public string tpcCode { get; set; }
        public Nullable<System.DateTime> tpcStartDate { get; set; }
        public Nullable<System.DateTime> tpcEndDate { get; set; }
        public Nullable<System.DateTime> tpcDateOfAcceptance { get; set; }
        public string tpcProofFile { get; set; }
        public string tpcReviewBoard { get; set; }
        public Nullable<System.DateTime> tpcCreateData { get; set; }
        public Nullable<System.DateTime> tpcModifierData { get; set; }
        public Nullable<int> tpcCreateUser { get; set; }
        public Nullable<int> tpcModifierUser { get; set; }
        public Nullable<System.DateTime> tpcDeleteData { get; set; }
        public Nullable<int> tpcDeleteUser { get; set; }
        public string tpcImage { get; set; }
    }

    public class ScientistFull      //Đầy đủ thông tin nhà khoa học

    {
        public int scientistID { get; set; }
        public string sctFirstName { get; set; }
        public string sctLastName { get; set; }

        public string sctSex { get; set; }
        public Nullable<System.DateTime> sctBirthday { get; set; }
        public string sctImage { get; set; }
        public string PlaceName { get; set; }
        public string degreeName { get; set; }
        public string unitName { get; set; }
        public string fieldName { get; set; }
        public string sctWorkingProcess { get; set; }
        public string sctResult { get; set; }
        public string sctForeignName { get; set; }
        public string sctAddress { get; set; }
        public string sctPhone { get; set; }
        public string sctEmail { get; set; }
        public Nullable<System.DateTime> sctCreateDate { get; set; }
        public Nullable<System.DateTime> sctModifierDate { get; set; }
        public Nullable<int> sctCreateUser { get; set; }
        public Nullable<int> sctModifierUser { get; set; }
    }

    public partial class ArticleFull        //Thông tin đầy đủ bài báo quốc tế
    {
        public int articlesID { get; set; }
        public string atlName { get; set; }
        public Nullable<int> scientistID { get; set; }
        public string scientistName { get; set; }
        public string nationName { get; set; }
        public string atlSummary { get; set; }
        public string keyName { get; set; }
        public Nullable<int> magazineName { get; set; }
        public string Point { get; set; }
        public Nullable<int> statusName { get; set; }
        public string atlLink { get; set; }
        public string typeName { get; set; }
        public string atlPublication { get; set; }
        public string fieldName { get; set; }
        public string atlNumber { get; set; }
        public string atlPageToPage { get; set; }
        public Nullable<System.DateTime> atlPublicationDate { get; set; }
        public Nullable<System.DateTime> atlCreateDate { get; set; }
        public Nullable<System.DateTime> atlModifierDate { get; set; }
        public Nullable<int> atlCreateUser { get; set; }
        public Nullable<int> atlModifierUser { get; set; }
    }

    public class TableFull
    {
        //public static IQueryable<TopicFull> TopicList()
        //{
        //    using(DBModel db = new DBModel())
        //    {
        //        var topicList = from tpc in db.Topics                                        //Lấy bảng lớn Topic là đề tài nghiên cứu
        //                        join sct in db.Scientists on tpc.scientistID equals sct.scientistID     //Nối đến bảng nhà khoa học
        //                        join cls in db.Classifications on tpc.classifiID equals cls.classifiID  //Nối đến bảng xếp loại đề tài
        //                        join sts in db.Status on tpc.statusID equals sts.statusID               //Nối đến bảng trạng thái
        //                        join fie in db.Fields on tpc.fieldID equals fie.fieldID                 //Nối đến bảng lĩnh vực
        //                        select new TopicFull()     // [W-A-R-N-I-N-G] những chỗ có liên kết các trường là khoá ngoại ở trên không được để NULL, cho nên nếu các hàng có hậu tố Name bên dưới RỖNG sẽ sinh lỗi không load lên được cả hàng đó
        //                        {
        //                            topicID = tpc.topicID,                                  //Mã số đề tài
        //                            scientistID = sct.scientistID,
        //                            scientistName = sct.sctFirstName + " " + sct.sctLastName,     //Tên đầy đủ nhà khoa học
        //                            classifiName = cls.clsName,                             //Tên xếp loại
        //                            statusName = sts.stsName,                               //Trạng thái
        //                            fieldName = fie.fieName,                                //Lĩnh vực

        //                            //Phía trên là nối bảng

        //                            tpcYear = tpc.tpcYear,                                  //Năm thực hiện
        //                            tpcName = tpc.tpcName,                                  //Tên đề tài
        //                            tpcSummary = tpc.tpcSummary,                            //Tóm tắt sơ lượt
        //                            tpcCode = tpc.tpcCode,                                  //Mã số
        //                            tpcStartDate = tpc.tpcStartDate,                        //Ngày bắt đầu thực hiện
        //                            tpcEndDate = tpc.tpcEndDate,                            //Ngày kết thúc
        //                            tpcDateOfAcceptance = tpc.tpcDateOfAcceptance,          //Ngày nghiệm thu
        //                            tpcProofFile = tpc.tpcProofFile,                        //Tệp minh chứng
        //                            tpcReviewBoard = tpc.tpcReviewBoard,                    //Hội đồng nghiệm thu
        //                            tpcCreateData = tpc.tpcCreateData,                      //Thời gian khởi tạo
        //                            tpcModifierData = tpc.tpcModifierData,                  //Thời gian thay đổi
        //                            tpcCreateUser = tpc.tpcCreateUser,                      //Người khởi tạo
        //                            tpcModifierUser = tpc.tpcModifierUser,                  //Người thay đổi
        //                            tpcDeleteData = tpc.tpcDeleteData,                      //Thời gian xoá
        //                            tpcDeleteUser = tpc.tpcDeleteUser,                      //Người xoá
        //                            tpcImage = tpc.tpcImage,                                //Ảnh bìa
        //                        };
        //        return topicList;
        //    }
        //}
    }
}