using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SMS.DATA.EF.Metadata
{

    #region Course Metadata

    public class CourseMetadata
    {
        [Required(ErrorMessage = "*")]
        [StringLength(200, ErrorMessage = "The value must be 100 characters or less")]
        [Display(Name = "Course")]
        [UIHint("MultilineText")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(500, ErrorMessage = "Course Description must be 500 characters or less")]
        [UIHint("MultilineText")]
        [DisplayFormat(NullDisplayText = "[N/A]")]
        public string CourseDescription { get; set; }

        [DisplayAttribute(Name = "Class Active")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(CourseMetadata))]
    public partial class Course
    {

    }

    #endregion

    #region CourseCompletion Metadata

    public class CourseCompletionMetaData
    {
        [Required(ErrorMessage = "*")]
        [StringLength(128, ErrorMessage = "The value must be 128 characters or less")]
        public string UserID { get; set; }


        //public int CourseID { get; set; }

        [Display(Name = "Date Completed")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[N/A]")]
        public DateTime DateCompleted { get; set; }
    }

    [MetadataType(typeof(CourseCompletionMetaData))]
    public partial class CourseCompletion
    {

    }

    #endregion

    #region UserDetail Metadata

    public class UserDetailMetadata
    {
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(50, ErrorMessage = "First Name must be 50 characters or less")]
        [Display(Name = "First Name")]
        [UIHint("MultilineText")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(50, ErrorMessage = "Last Name must be 50 characters or less")]
        [Display(Name = "Last Name")]
        [UIHint("MultilineText")]
        public string LastName { get; set; }

        [DisplayAttribute(Name = "Officer")]
        public bool IsAOfficer { get; set; }

        [DisplayAttribute(Name = "NCO")]
        public bool IsNCO { get; set; }
    }

    [MetadataType(typeof(UserDetailMetadata))]
    public partial class UserDetail
    {
        //[Display(Name = "UserDetail"]
        //public string FullName
        //{
        //    get { return FirstName + " " + LastName; }
        //}
    }

    #endregion

    #region Lessons Metadata    

    public class LessonMetadata
    {
        [UIHint("MultilineText")]
        [Required(ErrorMessage = "*Title of Lesson Is Required*")]
        [StringLength(200, ErrorMessage = "Title of Lesson must be 200 characters or less")]
        [Display(Name = "Lesson")]
        public string LessonTitle { get; set; }

        [UIHint("MultilineText")]
        [Required(ErrorMessage = "*An Introduction Is Required*")]
        [StringLength(300, ErrorMessage = "An Introduction of the Lesson must be 200 characters or less")]
        [Display(Name = "Intro")]
        public string Introduction { get; set; }

        [UIHint("MultilineText")]
        [Required(ErrorMessage = "*A Training Video Is Required*")]
        [StringLength(250, ErrorMessage = "Video Url of 250 characters or less is required")]
        public string VideoURL { get; set; }

        [Required(ErrorMessage = "*PDF Required*")]
        [StringLength(100, ErrorMessage = "Training PDF is required")]
        [Display(Name = "Training Manual")]
        public string PdfFileName { get; set; }

        [DisplayAttribute(Name = "Lesson Status")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(LessonMetadata))]
    public partial class Lesson
    {

    }

    #endregion

    #region LessonsView Metadata


    public class LessonsViewMetadata
    {
        [Required(ErrorMessage = "Lesson is required")]
        public int LessonID { get; set; }

        [Display(Name = "Date Viewed")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "[N/A]")]
        public DateTime DateViewed { get; set; }
    }

    [MetadataType(typeof(LessonsViewMetadata))]
    public partial class LessonsView
    {

    }

    #endregion 

}