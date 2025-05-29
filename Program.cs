using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Channels;

namespace Task_3
{

    class Student
    {
        public string StudentId = string.Empty;
        public string StudentClass = string.Empty;
        public string StudentName = string.Empty;
        public string StudentBirthday = string.Empty;
        public int StudentAge = default;
        public string StudentEmail = string.Empty;
        public int StudentPhoneNumber = default;
        public string StudentAddres = string.Empty;
        public List<Course> Courses = new List<Course>();
        public static bool StudentInCourse(List<Student> Students, string Input, Student studentToFind)
        {
            if (studentToFind.Courses[0] is not null)
            {
                return (true);
            }
            else
            {
                return (false);
            }

        }
        public static void PrintStudentInfo(List<Student> Students, string Input, Student studentToFind)
        {


            Console.WriteLine("=====================================================================================");
            Console.WriteLine("Student Id : " + studentToFind.StudentId);
            Console.WriteLine("Student Class : " + studentToFind.StudentClass);
            Console.WriteLine("Student FullName : " + studentToFind.StudentName);
            Console.WriteLine("Student Birthday : " + studentToFind.StudentBirthday);
            Console.WriteLine("Student Age : " + studentToFind.StudentAge);
            Console.WriteLine("Student Email : " + studentToFind.StudentEmail);
            Console.WriteLine("Student Phone Number : " + studentToFind.StudentPhoneNumber);
            Console.WriteLine("Student Addres : " + studentToFind.StudentAddres);
            Console.WriteLine("Student Courses : ");

            if (studentToFind.Courses.Count >= 0)
            {
                for (int i = 0; i < studentToFind.Courses.Count(); i++)
                {
                    Console.Write(studentToFind.Courses[i]);
                    Console.Write(" - ");
                }
            }
            else
            {
                Console.Write("Student is not in any courses");
            }
            Console.WriteLine("=====================================================================================");

        }
        public static void PrintAllStudentInfo(List<Student> Students)
        {
            Console.WriteLine($"All Students ( {Students.Count+1} Students ) : ");
            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Student Id : " + Students[i].StudentId);
                Console.WriteLine("Student Class : " + Students[i].StudentClass);
                Console.WriteLine("Student FullName : " + Students[i].StudentName);
                Console.WriteLine("Student Birthday : " + Students[i].StudentBirthday);
                Console.WriteLine("Student Age : " + Students[i].StudentAge);
                Console.WriteLine("Student Email : " + Students[i].StudentEmail);
                Console.WriteLine("Student Phone Number : " + Students[i].StudentPhoneNumber);
                Console.WriteLine("Student Addres : " + Students[i].StudentAddres);
                Console.WriteLine("Student Courses : ");
                if (Students[i].Courses.Count>=0)
                {
                    for (int l = 0; l < Students[i].Courses.Count(); l++)
                    {
                        Console.Write(Students[i].Courses[i]);
                        Console.Write(" - ");
                    }
                }
                else
                {
                    Console.Write("Student is not in any courses");
                }
            }
            Console.WriteLine("=====================================================================================");
        }
    }
    class Instructor
    {
        public string InstructorId = string.Empty;
        public string InstructorName = string.Empty;
        public string InstructorEmail = string.Empty;
        public int InstructorPhoneNumber = default;
        public Course InstructorCourse = new Course();
        public static void PrintAllInstructorInfo(List<Instructor> Instructors)
        {
            Console.WriteLine($"All Instructors ({Instructors.Count()} Instructors ) : ");
            for (int i = 0; i < Instructors.Count; i++)
            {
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Instructor Id : " + Instructors[i].InstructorId);
                Console.WriteLine("Instructor Name : " + Instructors[i].InstructorName);
                Console.WriteLine("Instructor Email : " + Instructors[i].InstructorEmail);
                Console.WriteLine("Instructor Phone Number : " + Instructors[i].InstructorPhoneNumber);
                Console.WriteLine("Instructor Course : " + Instructors[i].InstructorCourse.CourseTitle);
                Console.WriteLine("=====================================================================================");
            }
        }
    }
    class Course
    {
        public string CourseId = string.Empty;
        public string CourseTitle = string.Empty;
        public Instructor CourseInstructor = new Instructor();
        public int CourseCount = default;
        public List<Student> StudentsInCourse = new List<Student>();
        public static void PrintAllCoursesInfo(List<Course> Courses)
        {
            Console.WriteLine($"All Courses ({Courses.Count()} Courses ) : ");
            for (int i = 0; i < Courses.Count; i++)
            {
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Course Id : " + Courses[i].CourseId);
                Console.WriteLine("Course Title : " + Courses[i].CourseTitle);
                Console.WriteLine("Course Instructor : " + Courses[i].CourseInstructor.InstructorName);
                Console.WriteLine("Course students : " + Courses[i].CourseCount + " Student ");
                Console.WriteLine("=====================================================================================");
            }
        }
    }

    class SchoolManger
    {
        public List<Student> Students = new List<Student>();
        public List<Instructor> Instructors = new List<Instructor>();
        public List<Course> Courses = new List<Course>();

        public static void SchoolMangerMenu(List<Student> Students, List<Instructor> Instructors, List<Course> Courses)
        {
            while (true)
            {
                Console.WriteLine("============================== School System Menu =============================");
                Console.WriteLine("|                          1 - Add a new Student                              |");
                Console.WriteLine("|                          2 - View all Students                              |");
                Console.WriteLine("|                          3 - Find Student by ID or Name                     |");
                Console.WriteLine("|                          4 - Update Student Information                     |");
                Console.WriteLine("|                          5 - Delete a Student                               |");
                Console.WriteLine("|                          6 - Add a new Course                               |");
                Console.WriteLine("|                          7 - Add a new Instructor                           |");
                Console.WriteLine("|                          8 - Enroll Student in a Course                     |");
                Console.WriteLine("|                          9 - View all Courses                               |");
                Console.WriteLine("|                         10 - View all Instructors                           |");
                Console.WriteLine("|                         11 - Find Instructor by Id or Name                  |");
                Console.WriteLine("|                         12 - Find Course by Id or Name                      |");
                Console.WriteLine("========================= 13 - Quit the system ================================");

                Console.Write("                              ");
                int Menu = Convert.ToInt32(Console.ReadLine()); 


                switch (Menu)
                {
                    case 1:
                        {
                            AddStudent(Students);
                            break;
                        }
                    case 2:
                        {
                            Student.PrintAllStudentInfo(Students);
                            break;
                        }
                    case 3:
                        {

                            Console.WriteLine("Enter the id or the name for the student you want to find : ");
                             
                            string Input = Console.ReadLine() ?? "";
                            Student StudentToFind = FindStudent(Students, Input);
                            if (Input == StudentToFind.StudentId || Input == StudentToFind.StudentName)
                            {
                                Console.Clear();
                                Student.PrintStudentInfo(Students, Input, StudentToFind);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("=====================================================================================");
                                Console.WriteLine("Unfound Student id or Student name ");

                            }

                            break;
                        }
                    case 4:
                        {

                            Student studentToUpdate = Students[0];
                            Console.WriteLine("Enter the id or the name for the student you want to update his Information : ");
                             
                            string Input = Console.ReadLine() ?? "";
                            UpdateInfo(studentToUpdate, Students, Input);
                            break;
                        }
                    case 5:
                        {
                            DeleteStudent(Students);
                            break;
                        }
                    case 6:
                        {
                            AddNewCourse(Courses);
                            break;
                        }
                    case 7:
                        {
                            AddNewInstructor(Instructors, Courses);
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Enter the id or the name for the student you want to enroll into a Course : ");
                             
                            string Input = Console.ReadLine() ?? "";
                            Student StudentToFind = FindStudent(Students, Input);
                            if (StudentToFind.StudentId == Input || StudentToFind.StudentName == Input)
                            {
                                EnrollStudentInCourse(StudentToFind, Courses);
                            }
                            else
                            {
                                Console.WriteLine("=====================================================================================");
                                Console.WriteLine("Student not found");
                            }  
                            break;
                        }
                    case 9:
                        {
                            Course.PrintAllCoursesInfo(Courses);
                            break;

                        }
                    case 10:
                        {
                            Instructor.PrintAllInstructorInfo(Instructors);
                            break;
                        }
                    case 11:
                        {
                            Console.WriteLine("Enter the ID or the Name for the Instructor you want to find : ");
                             
                            string Input = Console.ReadLine() ?? "";
                            Instructor InstructorToFind = Findinstructor(Instructors, Input);
                            PrintInstructorInfo(InstructorToFind, Input);
                            break;
                        }
                    case 12:
                        {
                            Console.WriteLine("Enter the ID or the Title for the Course you want to find : ");
                             
                            string Input = Console.ReadLine() ?? "";
                            Course CourseToFind = FindCourse(Courses, Input);
                            PrintCourseInfo(CourseToFind, Input);
                            break;
                        }
                    case 13:
                        {
                            Console.Clear();
                            Console.WriteLine("=========================================");
                            Console.WriteLine("|             see you later             |");
                            Console.WriteLine("=========================================");
                            return;

                        }

                }
            }
        }
        public static void AddStudent(List<Student> Students)
        {
            Student NewStudent = new Student();
            Console.WriteLine("Student information");
            Console.WriteLine("Enter Student Id : ");
             
            NewStudent.StudentId = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Student Class : ");
             
            NewStudent.StudentClass = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Student FullName : ");
             
            NewStudent.StudentName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Student Birthday : ");
             
            NewStudent.StudentBirthday = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Student Age : ");
             
            NewStudent.StudentAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Email : ");
             
            NewStudent.StudentEmail = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Student Phone Number : ");
             
            NewStudent.StudentPhoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Addres : ");
             
            NewStudent.StudentAddres = Console.ReadLine() ?? "";
            Console.Clear();
            Console.WriteLine($"Student {NewStudent.StudentName} has been add Succesfully.");
            Students.Add(NewStudent);
        }
        public static Student FindStudent(List<Student> Students, string Input)
        {
            Student studentToFind = Students[0];
            for (int i = 0; i < Students.Count; i++)
            {
                if (Input == Students[i].StudentId || Input == Students[i].StudentName)
                {
                    studentToFind = Students[i];
                }

            } 
            return studentToFind;
           
        }
        public static void DeleteStudent(List<Student> Students) 
        {
            Console.WriteLine("Enter the id or the name for the student you want to delete his Information : ");
             
            string Input = Console.ReadLine() ?? "";
            Student StudentToFind = FindStudent(Students, Input);
            Students.Remove(StudentToFind);
            Console.Clear();
            Console.WriteLine("=====================================================================================");
            Console.WriteLine("Student Information has been deleted succesfully.");
        }
        public static void UpdateInfo(Student studentToUpdate, List<Student> Students, string Input)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Input == Students[i].StudentId || Input == Students[i].StudentName)
                {
                    studentToUpdate = Students[i];
                }

            }
            Console.WriteLine("choose what do you want to update in this student Information : ");
            Console.WriteLine("1 - Id ,2 - Class ,3 - Name ,4 - Birthday ,5 - Age ,6 - Email ,7 - Phone Number ,8 - Addres ");
            int infoToUpdate = Convert.ToInt32(Console.ReadLine() ?? "".ToUpper());
            for (; ; )
            {
                if (infoToUpdate < 1 || infoToUpdate > 8)
                {
                    Console.WriteLine("invalid choice , please choice again");
                    Console.WriteLine("choose what do you want to update in this student Information : ");
                    Console.WriteLine("1 - Id ,2 - Class ,3 - Name ,4 - Birthday ,5 - Age ,6 - Email ,7 - Phone Number ,8 - Addres ");
                    infoToUpdate = Convert.ToInt32(Console.ReadLine() ?? "".ToUpper());
                }
                else
                {
                    break;
                }
            }
            switch (infoToUpdate)
            {
                case 1:
                    {
                        string ChangeTo = string.Empty;
                        Console.WriteLine("Enter the new Student Id :");
                         
                        ChangeTo = Console.ReadLine() ?? "";
                        studentToUpdate.StudentId = ChangeTo;
                        Console.Clear();
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("The Student Id has been updated succesfully.");
                        break;
                    }
                case 2:
                    {
                        string ChangeTo = string.Empty;
                        Console.WriteLine("Enter the new Student Class :");
                         
                        ChangeTo = Console.ReadLine() ?? "";
                        studentToUpdate.StudentClass = ChangeTo;
                        Console.Clear();
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("The Student Class has been updated succesfully.");
                        break;
                    }
                case 3:
                    {
                        string ChangeTo = string.Empty;
                        Console.WriteLine("Enter the new Student Name :");
                         
                        ChangeTo = Console.ReadLine() ?? "";
                        studentToUpdate.StudentName = ChangeTo;
                        Console.Clear();
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("The Student Name has been updated succesfully.");
                        break;
                    }
                case 4:
                    {
                        string ChangeTo = string.Empty;
                        Console.WriteLine("Enter the new Student Birthday :");
                         
                        ChangeTo = Console.ReadLine() ?? "";
                        studentToUpdate.StudentBirthday = ChangeTo;
                        Console.Clear();
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("The Student Birthday has been updated succesfully.");
                        break;
                    }
                case 5:
                    {
                        int ChangeTo = default;
                        Console.WriteLine("Enter the new Student Age :");
                         
                        ChangeTo = Convert.ToInt32(Console.ReadLine());
                        studentToUpdate.StudentAge = ChangeTo;
                        Console.Clear();
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("The Student Age has been updated succesfully.");
                        break;
                    }
                case 6:
                    {
                        string ChangeTo = string.Empty;
                        Console.WriteLine("Enter the new Student Email :");
                         
                        ChangeTo = Console.ReadLine() ?? "";
                        studentToUpdate.StudentEmail = ChangeTo;
                        Console.Clear();
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("The Student Email has been updated succesfully.");
                        break;
                    }
                case 7:
                    {
                        int ChangeTo = default;
                        Console.WriteLine("Enter the new Student Phone Number :");
                         
                        ChangeTo = Convert.ToInt32(Console.ReadLine());
                        studentToUpdate.StudentPhoneNumber = ChangeTo;
                        Console.Clear();
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("The Student Phone Number has been updated succesfully.");
                        break;
                    }
                case 8:
                    {
                        string ChangeTo = string.Empty;
                        Console.WriteLine("Enter the new Student Addres :");
                         
                        ChangeTo = Console.ReadLine() ?? "";
                        studentToUpdate.StudentAddres = ChangeTo;
                        Console.Clear();
                        Console.WriteLine("=====================================================================================");
                        Console.WriteLine("The Student Addres has been updated succesfully.");
                        break;
                    }

            }
        }
        public static Instructor Findinstructor(List<Instructor> Instructors, string Input)
        {
            Instructor InstructorToFind = Instructors[0];

            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Input == Instructors[i].InstructorId || Input == Instructors[i].InstructorName)
                {
                    InstructorToFind = Instructors[i];
                }

            }
            return InstructorToFind;

        }
        public static void PrintInstructorInfo(Instructor InstructorToFind, string Input)
        {
            Console.Clear();
            if (InstructorToFind.InstructorId == Input || InstructorToFind.InstructorName == Input)
            {
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Instructor Id : " + InstructorToFind.InstructorId);
                Console.WriteLine("Instructor Name : " + InstructorToFind.InstructorName);
                Console.WriteLine("Instructor Email : " + InstructorToFind.InstructorEmail);
                Console.WriteLine("Instructor Phone Number : " + InstructorToFind.InstructorPhoneNumber);
                Console.WriteLine("Instructor Course Name : " + InstructorToFind.InstructorCourse.CourseTitle);
            }
            else
            {
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Instructor not found");
            }

        }
        static Course FindCourse(List<Course> Courses, string Input)
        {
            Course CourseToFind = Courses[0];

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Input == Courses[i].CourseId || Input == Courses[i].CourseTitle)
                {
                    CourseToFind = Courses[i];
                }

            }
            return CourseToFind;
        }
        public static void PrintCourseInfo(Course CourseToFind, string Input)
        {
            Console.Clear();
            if (CourseToFind.CourseId == Input || CourseToFind.CourseTitle == Input)
            {
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Course Id : " + CourseToFind.CourseId);
                Console.WriteLine("Course Title : " + CourseToFind.CourseTitle);
                Console.WriteLine("Course Instructor Name : " + CourseToFind.CourseInstructor.InstructorName);
                Console.WriteLine("Course students : " + CourseToFind.CourseCount + " Students ");
                Console.WriteLine("=====================================================================================");
            }
            else
            {
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Course not found");
            }

        }
        public static void EnrollStudentInCourse(Student StudentToFind, List<Course> Courses)
        {
            Console.WriteLine("Enter the id or the title of the course you to enroll the student in : ");
             
            string Input1 = Console.ReadLine() ?? "";
            Course CourseToFind = FindCourse(Courses, Input1);

            if (CourseToFind.CourseId == Input1 || CourseToFind.CourseTitle == Input1)
            {
                CourseToFind.StudentsInCourse.Add(StudentToFind);
                CourseToFind.CourseCount++;
                Console.Clear();
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Student has been enroll in the course succesfully.");
            }
        
            else
            {
                Console.Clear();
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("Course not found");
            }

            }
        public static void AddNewCourse (List<Course> Courses)
        {
            Course NewCourse = new Course();
            Console.WriteLine("Add new course");
            Console.WriteLine("Enter course Id : ");
             
            NewCourse.CourseId = Console.ReadLine() ?? "";
            Console.WriteLine("Enter course Title : ");
             
            NewCourse.CourseTitle = Console.ReadLine() ?? "";
            Courses.Add(NewCourse);
            Console.Clear();
            Console.WriteLine("=====================================================================================");
            Console.WriteLine("New Course has been Add Succesfully.");
        }
        public static void AddNewInstructor(List<Instructor> Instructors, List<Course> Courses)
        {
            Instructor NewInstructor = new Instructor();
            Console.WriteLine("Add new Instructor");
            Console.WriteLine("Enter Instructor Id : ");
             
            NewInstructor.InstructorId = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Instructor Name : ");
             
            NewInstructor.InstructorName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Instructor Email : ");
             
            NewInstructor.InstructorEmail = Console.ReadLine() ?? "";
            Console.WriteLine("Enter Instructor Phone Number : ");
             
            NewInstructor.InstructorPhoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choese the Course for the Instructor by Course id :");
             
            string Input = Console.ReadLine() ?? "";
            Course CourseToFind = FindCourse(Courses, Input);
            if (Input == CourseToFind.CourseId)
            {
                NewInstructor.InstructorCourse = CourseToFind;
                CourseToFind.CourseInstructor = NewInstructor;
                Instructors.Add(NewInstructor);
                Console.Clear();
                Console.WriteLine("=====================================================================================");
                Console.WriteLine("New Instructor has been Add Succesfully.");
            }
            else
            {
                Console.WriteLine("Unfound id or name please Enter another id or another name ");
            }
            
        }
    }
    internal class Program
        {


            static void Main(string[] args)
            {
                SchoolManger manger1 = new SchoolManger();
                manger1.Students = new List<Student>();
                manger1.Courses = new List<Course>();
                manger1.Instructors = new List<Instructor>();
                SchoolManger.SchoolMangerMenu(manger1.Students, manger1.Instructors, manger1.Courses);


            }
        }
    
}
   
